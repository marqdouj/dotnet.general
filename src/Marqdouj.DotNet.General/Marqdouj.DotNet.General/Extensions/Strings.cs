namespace Marqdouj.DotNet.General.Extensions
{
    public static class Strings
    {
        public const string CRLF = "\r\n";
        public const string LF = "\n";
        public const string CR = "\r";
        public const string ELLIPSIS = "…";

        /// <summary>
        /// Converts all line endings in the specified string to carriage return and line feed (CRLF) format.
        /// </summary>
        /// <remarks>This method replaces all existing line endings (LF, CR, or CRLF) in the input string
        /// with CRLF sequences. It is useful for ensuring consistent line endings, for example, when preparing text for
        /// environments that require CRLF formatting.</remarks>
        /// <param name="value">The string whose line endings will be normalized to CRLF format. If <paramref name="value"/> is <see
        /// langword="null"/> or consists only of white-space characters, the original value is returned.</param>
        /// <returns>A string in which all line endings have been replaced with CRLF sequences. Returns the original value if it
        /// is <see langword="null"/> or contains only white-space.</returns>
        public static string ToCrLf(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;

            value = value.Replace(CRLF, LF);
            value = value.Replace(CR, LF);
            value = value.Replace(LF, CRLF);

            return value;
        }

        /// <summary>
        /// Converts line endings in the specified string to <see cref="Environment.NewLine"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToNewLine(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;
            value = value.ToCrLf();
            value = value.Replace(CRLF, Environment.NewLine);
            return value;
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
