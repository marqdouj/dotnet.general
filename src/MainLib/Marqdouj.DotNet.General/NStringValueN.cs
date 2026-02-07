using Marqdouj.DotNet.General.Extensions;
using System.Numerics;

namespace Marqdouj.DotNet.General
{
    /// <summary>
    /// String wrapper for a number; allows for null. Useful in binding scenarios that require a string.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    public class NStringValueN<T>(T? value = default) where T : struct, INumber<T>
    {
        public virtual T? Value { get; protected set; } = value;

        /// <summary>
        /// Minimum value (if not null).
        /// </summary>
        public T? Min { get; private set; }

        /// <summary>
        /// Maximum value (if not null).
        /// </summary>
        public T? Max { get; private set; }

        /// <summary>
        /// Sets the Min/Max range for the Value.
        /// Coerces the value to fit within the range (if Min or Max is not null).
        /// </summary>
        /// <param name="min"><see cref="Min"/></param>
        /// <param name="max"><see cref="Max"/></param>
        /// <exception cref="Exception"></exception>
        public void SetMinMax(T? min, T? max)
        {
            if (min.HasValue && max.HasValue)
            {
                if (min.Value > max.Value)
                    throw new Exception($"{nameof(SetMinMax)}: min [{min.Value}] can not be greater than max [{max.Value}].");

                Min = min.Value;
                Max = max.Value;
            }
            else
            {
                Min = min;
                Max = max;
            }

            //Reset value to ensure it's within Min/Max (if applicable)
            StringValue = Value?.ToString();
        }

        /// <summary>
        /// Wraps the <see cref="Value"/> property.
        /// </summary>
        public virtual string? StringValue 
        {
            get => Value?.ToString();
            set
            {
                Value = CheckValueForMinMax(value);
            }
        }

        private T? CheckValueForMinMax(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var result = value?.ToNumberN(Value);
            var okMin = Min is null || result >= Min.Value;
            var okMax = Max is null || result <= Max.Value;

            if (okMin && okMax)
            {
                return result;
            }
            else if (Min.HasValue && result <= Min.Value)
            {
                return Min.Value;
            }
            else if (Max.HasValue && result >= Max.Value) 
            { 
                return Max.Value;
            }
            else
            {
                return result;
            }
        }
    }
}
