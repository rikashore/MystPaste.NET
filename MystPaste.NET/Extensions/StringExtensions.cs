using System;
using System.Drawing;
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
        
        public static Color ParseColor(this string hexadecimal)
        {
            hexadecimal = hexadecimal.TrimStart('#');
            Color result;
            if (hexadecimal.Length == 6)
            {
                result = Color.FromArgb(
                    255,
                    int.Parse(hexadecimal.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(hexadecimal.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(hexadecimal.Substring(4, 2), NumberStyles.HexNumber));
            }
            else
            {
                result = Color.FromArgb(
                    int.Parse(hexadecimal.Substring(0, 2), NumberStyles.HexNumber),
                    int.Parse(hexadecimal.Substring(2, 2), NumberStyles.HexNumber),
                    int.Parse(hexadecimal.Substring(4, 2), NumberStyles.HexNumber),
                    int.Parse(hexadecimal.Substring(6, 2), NumberStyles.HexNumber));
            }
            return result;
        }
    }
}