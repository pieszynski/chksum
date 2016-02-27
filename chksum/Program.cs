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
            string sFilePath = string.Empty;
            string sChecksumToVerify = string.Empty;

            if (null == args || 0 == args.Length)
            {
                Console.WriteLine("Brak sciezki do pliku");
                Console.WriteLine();
                Console.WriteLine("\t\\> chksum.exe sciezka_do_pliku");
                Console.WriteLine("lub");
                Console.WriteLine("\t\\> chksum.exe HASH sciezka_do_pliku");
                return 404;
            }

            if (1 == args.Length)
            {
                sFilePath = args[0];
            }
            else if (1 < args.Length)
            {
                sChecksumToVerify = args[0];
                sFilePath = args[1];
            }

            if (!File.Exists(sFilePath))
            {
                Console.WriteLine($"Plik nie istnieje - \"{sFilePath}\"");
                return 404;
            }

            CalculationHost cHost = new CalculationHost();
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
