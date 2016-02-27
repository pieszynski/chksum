using chksum.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace chksum
{
    class Program
    {
        static int Main(string[] args)
        {
            string sMode = "-sha1";
            string sFilePath = string.Empty;
            string sChecksumToVerify = string.Empty;

            if (null == args || 0 == args.Length)
            {
                Console.WriteLine("Brak sciezki do pliku");
                Console.WriteLine();
                Console.WriteLine("\t\\> chksum.exe sciezka_do_pliku");
                Console.WriteLine("lub");
                Console.WriteLine("\t\\> chksum.exe HASH sciezka_do_pliku");
                Console.WriteLine("lub ogolnie");
                Console.WriteLine("\t\\> chksum.exe [MODE] [HASH] sciezka_do_pliku");
                Console.WriteLine();
                Console.WriteLine("tryby (MODE):");
                Console.WriteLine("\t-sha1\t(domyslny) wyliczanie SHA1");
                Console.WriteLine("\t-sha256\twyliczanie SHA256");
                return 404;
            }

            if (1 == args.Length)
            {
                sFilePath = args[0];
            }
            else if (2 == args.Length)
            {
                string sWhatIsFirst = args[0];
                if ('-' == sWhatIsFirst[0])
                    sMode = sWhatIsFirst;
                else
                    sChecksumToVerify = sWhatIsFirst;
                    
                sFilePath = args[1];
            }
            else if (2 < args.Length)
            {
                sMode = args[0];
                sChecksumToVerify = args[1];
                sFilePath = args[2];
            }

            if (!File.Exists(sFilePath))
            {
                Console.WriteLine($"Plik nie istnieje - \"{sFilePath}\"");
                return 404;
            }

            CalculationHost cHost = new CalculationHost(sMode);
            string sChecksum = cHost.CalculateChecksum(sFilePath);
            
            string sChecksumOut = $"{sChecksum}\t*{Path.GetFileName(sFilePath)}";

            if (!string.IsNullOrEmpty(sChecksumToVerify))
            {
                bool isTheSame = cHost.CompareChecksums(sChecksum, sChecksumToVerify);
                Console.WriteLine($"[{(isTheSame ? "OK" : "ERR")}]\t{sChecksumOut}");
                if (!isTheSame)
                    return 500;
            }
            else
            {
                Console.WriteLine(sChecksumOut);
            }

            return 0;
        }
    }
}
