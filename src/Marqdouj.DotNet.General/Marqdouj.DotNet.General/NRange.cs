using System.Globalization;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Marqdouj.DotNet.General
{
    /// <summary>
    /// Represents a numeric range (NRange) with a minimum and maximum value, 
    /// and maintains a value constrained within that range.
    /// </summary>
    /// <remarks>The range enforces that its value always remains between the specified minimum and maximum
    /// bounds. Assigning a value outside the range will automatically coerce it to the nearest valid boundary. This
    /// type is useful for scenarios where values must be restricted to a specific numeric interval, such as sliders,
    /// progress bars, or bounded counters.</remarks>
    /// <typeparam name="T">The numeric type of the range values. Must implement <see cref="INumber{T}"/>.</typeparam>
    public class NRange<T> : StateModel where T : INumber<T>
    {
        /// <summary>
        /// Initializes a new instance with the specified minimum and maximum values.
        /// </summary>
        /// <param name="min">The minimum value of the range. This value is assigned to both the Min property and the initial value of the
        /// range.</param>
        /// <param name="max">The maximum value of the range.</param>
        public NRange(T min, T max)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(min, max);
            ArgumentOutOfRangeException.ThrowIfEqual(min, max);

            Min = min;
            Max = max;
            _value = min;
        }

        /// <summary>
        /// Initializes a new instance with the specified minimum, maximum, and value. 
        /// The value is coerced to ensure it falls within the defined range.
        /// </summary>
        /// <param name="min">The minimum allowed value for the range.</param>
        /// <param name="max">The maximum allowed value for the range.</param>
        /// <param name="value">The initial value to assign. If the value is outside the range defined by min and max, it will be coerced to
        /// fit within the range.</param>
        [JsonConstructor]
        public NRange(T min, T max, T value) : this(min, max)
        {
            _value = CoerceValue(value);
        }

        #region Value

        private T _value;

        /// <summary>
        /// Gets or sets the current value.
        /// </summary>
        public T Value
        {
            get => _value;
            set => SetValue(ref _value, CoerceValue(value));
        }

        /// <summary>
        /// Returns a value constrained to the inclusive range defined by the Min and Max properties.
        /// </summary>
        /// <remarks>If the specified value is less than Min, Min is returned. If the value is greater
        /// than Max, Max is returned. Otherwise, the original value is returned.</remarks>
        /// <param name="value">The value to be coerced within the allowed range.</param>
        /// <returns>The value, adjusted if necessary, so that it is not less than Min and not greater than Max.</returns>
        private T CoerceValue(T value)
        {
            if (value < Min)
                value = Min;
            if (value > Max)
                value = Max;
            return value;
        }

        #endregion

        /// <summary>
        /// The minimum value in the range.
        /// </summary>
        public T Min { get; }

        /// <summary>
        /// The maximum value in the range.
        /// </summary>
        public T Max { get; }

        /// <summary>
        /// Gets the width represented by the difference between the maximum and minimum values.
        /// </summary>
        public T Width => Max - Min;

        /// <summary>
        /// Gets the value at the center of the range.
        /// </summary>
        public double Center => Convert.ToDouble(Min) + (Convert.ToDouble(Width) / 2.0);

        /// <summary>
        ///The increment value used for each step in a sequence or calculation (if applicable).
        /// </summary>
        public T Step { get; set; } = T.CreateChecked(1);

        /// <summary>
        /// String wrapper to Value property. Useful in binding secenarios that require a string.
        /// </summary>
        /// <remarks>If value does not parse it will be ignored.</remarks>
        public string? StringValue
        {
            get => Value.ToString();
            set
            {
                if (T.TryParse(value, NumberStyles.Any, null, out var result))
                    Value = result;
            }
        }

        public override string ToString() => Value?.ToString() ?? string.Empty;
    }
}
