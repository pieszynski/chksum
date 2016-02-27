using chksum.ChecksumCalculators;
using chksum.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace chksum.Helpers
{
    public class CalculationHost
    {
        /// <summary>
        /// Wyznaczenie sumy kontrolnej dla pliku.
        /// </summary>
        /// <param name="sFilePath">Ścieżka do pliku.</param>
        /// <returns>Suma kontrolna.</returns>
        public string CalculateChecksum(string sFilePath)
        {
            if (!File.Exists(sFilePath))
                return string.Empty;

            using (Stream fileStream = File.OpenRead(sFilePath))
            {
                ICalculator sumCalc = new Sha1Checksum();
                string response = sumCalc.CalculateChecksum(fileStream);
                return response;
            }
        }

        /// <summary>
        /// Porównanie sum kontrolnych
        /// </summary>
        /// <param name="sFileChecksum">Suma kontrola wyliczona z pliku.</param>
        /// <param name="sChecksumToVerify">Suma kontrolna dostarczona.</param>
        /// <returns>TRUE jeśli obie sumy są takie same.</returns>
        public bool CompareChecksums(string sFileChecksum, string sChecksumToVerify)
        {
            sChecksumToVerify = sChecksumToVerify?.ToUpperInvariant()?.Trim();
            sFileChecksum = sFileChecksum?.ToUpperInvariant()?.Trim();

            bool response = string.Equals(
                sChecksumToVerify,
                sFileChecksum,
                StringComparison.InvariantCultureIgnoreCase
                );

            return response;
        }

        /// <summary>
        /// Sprawdzenie poprawności sumy kontrolnej.
        /// </summary>
        /// <param name="sChecksumToVerify">Suma kontrolna w formacie szesnastkowym.</param>
        /// <param name="sFilePath">Ścieżka do pliku.</param>
        /// <returns>TRUE jeśli suma jest zgodna z zawartością pliku.</returns>
        public bool VerifyChecksum(string sChecksumToVerify, string sFilePath)
        {
            string sFileChecksum = this.CalculateChecksum(sFilePath);

            bool response = this.CompareChecksums(sFileChecksum, sChecksumToVerify);

            return response;
        }
    }
}
