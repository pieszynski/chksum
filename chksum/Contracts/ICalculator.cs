using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace chksum.Contracts
{
    /// <summary>
    /// Interfejs do wyznaczania sum kontrolnych.
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Wyliczenie sumy kontrolnej.
        /// </summary>
        /// <param name="data">Strumień danych.</param>
        /// <returns>Suma kontrolna dla strumienia danych.</returns>
        string CalculateChecksum(Stream data);
    }
}
