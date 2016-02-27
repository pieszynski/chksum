using chksum.Contracts;
using chksum.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace chksum.ChecksumCalculators
{
    /// <summary>
    /// Wyliczanie sumy kontrolnej w formacie SHA256.
    /// </summary>
    [Export(typeof(ICalculator))]
    public class Sha256Checksum : ICalculator
    {
        /// <summary>
        /// Wyliczenie sumy kontrolnej SHA256.
        /// </summary>
        /// <param name="data">Strumień danych.</param>
        /// <returns>Suma kontrolna dla strumienia danych.</returns>
        public string CalculateChecksum(Stream data)
        {
            using (SHA256Managed shaM = new SHA256Managed())
            {
                byte[] bHash = shaM.ComputeHash(data);
                string response = bHash.ToHexString();
                return response;
            }
        }
    }
}
