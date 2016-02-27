using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace chksum.Helpers
{
    /// <summary>
    /// Formatowanie wyników sum kontrolnych.
    /// </summary>
    public static class SumFormatter
    {
        /// <summary>
        /// Zamiana ciągu bajtów na ciąg liczb w formacie szestnastkowym
        /// </summary>
        /// <param name="checksum">Wyliczona suma kontrolna.</param>
        /// <returns>Sformatowana suma kontrolna.</returns>
        public static string ToHexString(this byte[] checksum)
        {
            if (null == checksum || 0 == checksum.Length)
                return string.Empty;

            string response = string.Join(
                string.Empty, 
                checksum.Select(s => s.ToString("X2")
                ));

            return response;
        }
    }
}
