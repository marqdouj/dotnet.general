using Marqdouj.DotNet.General.Extensions;
using System.Numerics;

namespace Marqdouj.DotNet.General
{
    public class NStringValue<T>(T value = default!) where T : INumber<T>
    {
        /// <summary>
        /// Value that gets wrapped by <see cref="StringValue"/>
        /// </summary>
        public virtual T Value { get; protected set; } = value;

        /// <summary>
        /// Minimum value.
        /// </summary>
        public double? Min { get; private set; }

        /// <summary>
        /// Maximum value.
        /// </summary>
        public double? Max { get; private set; }

        /// <summary>
        /// Sets the Min/Max range for the Value.
        /// Coerces the value to fit within the range (if Min or Max is not null).
        /// </summary>
        /// <param name="min"><see cref="Min"/></param>
        /// <param name="max"><see cref="Max"/></param>
        /// <exception cref="Exception"></exception>
        public void SetMinMax(double? min, double? max)
        {
            
            if (min.HasValue && max.HasValue)
            {
                var x = T.CreateChecked(min.Value);
                if (min.Value > max.Value)
                    throw new Exception($"{nameof(SetMinMax)}: min [{min.Value}] can not be greater than max [{max.Value}].");
            }

            Min = min;
            Max = max;

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

        private T CheckValueForMinMax(string? value)
        {
            var result = value.ToNumber(Value);

            if (Min is null && Max is null)
                return result;

            var checkedValue = Convert.ToDouble(result);
            var okMin = Min is null || checkedValue >= Min.Value;
            var okMax = Max is null || checkedValue <= Max.Value;

            if (okMin && okMax)
            {
                return result;
            }
            else if (Min.HasValue && checkedValue <= Min.Value)
            {
                return T.CreateChecked(Min.Value);
            }
            else if (Max.HasValue && checkedValue >= Max.Value)
            {
                return T.CreateChecked(Max.Value);
            }
            else
            {
                return result;
            }
        }
    }
}
