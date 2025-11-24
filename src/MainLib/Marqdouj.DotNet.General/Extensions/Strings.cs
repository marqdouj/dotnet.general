using System.Data.SqlTypes;
using System.Globalization;
using System.Numerics;

namespace Marqdouj.DotNet.General.Extensions
{
    public static class Strings
    {
        public const string CRLF = "\r\n";
        public const string LF = "\n";
        public const string CR = "\r";
        public const string ELLIPSIS = "…";

        /// <summary>
        /// Converts a string to a number.
        /// </summary>
        /// <typeparam name="T">Type of INumber<typeparamref name="T"/></typeparam>
        /// <param name="value">string to parse to INumber<typeparamref name="T"/></param>
        /// <param name="defaultValue">value to return if unable to parse to INumber<typeparamref name="T"/></param>
        /// <returns>INumber<typeparamref name="T"/> if converted; otherwise typeparam<paramref name="defaultValue"/></returns>
        public static T? ToNumber<T>(this string? value, T? defaultValue = default) 
            where T : INumber<T>
        {
            if (T.TryParse(value, NumberStyles.Any, null, out var result))
                return result;

            return defaultValue;
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the left side of a string, 
        /// + suffix (if value was actually truncated)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">number of chars to return; not including the suffix</param>
        /// <param name="suffix">value to append if string is truncated. default is …</param>
        /// <returns>truncated value + suffix (if applicable). Note: if value.IsNullOrEmpty returns value</returns>
        public static string? Truncate(this string value, int length, string suffix = ELLIPSIS)
        {
            if (string.IsNullOrEmpty(value)) return value;
            if (length >= value.Length) return value;

            var result = value[..length] + suffix;
            return result;
        }
    }
}
