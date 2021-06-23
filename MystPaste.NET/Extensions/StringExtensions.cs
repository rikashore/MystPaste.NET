using System;
using System.Globalization;

namespace MystPaste.NET.Extensions
{
    public static class StringExtensions
    {
        public static Uri FormatUri(this string pattern, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                throw new ArgumentNullException(nameof(pattern));

            return new Uri(string.Format(CultureInfo.InvariantCulture, pattern, args), UriKind.Relative);
        }
    }
}