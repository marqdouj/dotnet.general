namespace Marqdouj.DotNet.General
{
    /// <summary>
    /// String wrapper for a bool. Useful in binding scenarios that require a string.
    /// </summary>
    public class BStringValue(bool value = default)
    {
        public virtual bool Value { get; protected set; } = value;

        /// <summary>
        /// Wraps the <see cref="Value"/> property.
        /// </summary>
        public virtual string? StringValue
        {
            get => Value.ToString();
            set
            {
                if (bool.TryParse(value, out var result))
                    Value = result;
            }
        }
    }
}
