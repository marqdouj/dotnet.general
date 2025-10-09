using System.Numerics;

namespace Marqdouj.DotNet.General.Extensions
{
    public static class Numbers
    {
        /// <summary>
        /// Converts a delimited string to a List of numbers (NList).
        /// The numbers must be convertable to INumber<typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"><see cref="INumber{TSelf}"/></typeparam>
        /// <param name="value">delimited string</param>
        /// <param name="deliminator">Character the string is delimited with.</param>
        /// <returns>
        /// Values are limited to Min/Max for a <see langword="double"/>.
        /// Throws FormatException is delimited items are not converted.
        /// </returns>
        /// <remarks>
        /// Designed and tested with Int/Double. 
        /// Not tested with other numeric types, but in theory should work 
        /// as long as the values are convertable from double to INumber<typeparamref name="T"/>
        /// </remarks>
        public static List<T> ToNList<T>(this string value, char deliminator = ',') where T : INumber<T>
        {
            var items = new List<T>();
            if (string.IsNullOrWhiteSpace(value)) return items;

            var sep = new char[] { deliminator };
            var values = value.Split(sep, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            foreach (var item in values)
            {
                var n = Convert.ToDouble(item);
                items.Add(T.CreateChecked(n));
            }

            return items;
        }

        /// <summary>
        /// Checks if the underlying type code is a number.
        /// TypeCodes: UInt16,UInt32,UInt64,Int16,Int32,Int64,Decimal,Double,Single, and Byte/SByte if includeByte = true.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="includeByte">Flag to include Byte/SByte as a number. Default is false.</param>
        /// <returns></returns>
        public static bool IsNumberTypeCode(this object? obj, bool includeByte = false)
        {
            if (obj == null) return false;

            var typeCode = Type.GetTypeCode(obj.GetType());

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                    return includeByte;
            }

            //Check using IsAssignableFrom (double)
            if (typeof(INumber<double>).IsAssignableFrom(obj.GetType()))
            {
                return true;
            }

            //Fallback from IsAssignableFrom
            switch (Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}
