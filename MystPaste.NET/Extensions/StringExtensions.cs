using System;
using System.Globalization;

namespace MystPaste.NET
{
    internal static class StringExtensions
    {
        internal static Uri FormatUri(this string pattern, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            return new Uri(string.Format(CultureInfo.InvariantCulture, pattern, args), UriKind.Relative);
        }
    }
}