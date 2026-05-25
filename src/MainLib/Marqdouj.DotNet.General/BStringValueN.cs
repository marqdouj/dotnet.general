namespace Marqdouj.DotNet.General
{
    /// <summary>
    /// String wrapper for a nullable bool. Useful in binding scenarios that require a string.
    /// </summary>
    /// <param name="value"></param>
    public class BStringValueN(bool? value = default) : StateModel
    {
        public virtual bool? Value { get; protected set { SetValue(ref field, value); } } = value;

        /// <summary>
        /// Wraps the <see cref="Value"/> property.
        /// </summary>
        public virtual string? StringValue
        {
            get => Value?.ToString();
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    Value = null;
                else if (bool.TryParse(value, out var result))
                    Value = result;
            }
        }
    }
}
