using System.Runtime.CompilerServices;

namespace Marqdouj.DotNet.General
{
    /// <summary>
    /// Provides a base class for models that support state change notification and suppression of notifications.
    /// Enables derived types to implement property change patterns and notify observers when state changes occur.
    /// </summary>
    /// <remarks>StateModel is designed to facilitate change notification in scenarios such as view models or
    /// data-binding contexts. It provides mechanisms to update values, determine whether a change will occur, and
    /// notify listeners when state changes. Notifications can be suppressed during batch updates by setting
    /// SuppressNotifications to true. Override NotifyStateChanged to customize notification dispatching behavior in
    /// derived classes.</remarks>
    public abstract class StateModel
    {
        /// <summary>
        /// Attempts to update the specified value and notify listeners if the value was changed
        /// and <see cref="SuppressNotifications"/> is <see langword="false"/>.
        /// </summary>
        /// <remarks>
        /// This method is typically used in property setters to implement change notification patterns.
        /// It only updates the value and triggers notification if the new value differs from the current value.
        /// </remarks>
        /// <typeparam name="T">The type of the value to be updated.</typeparam>
        /// <param name="oldValue">
        /// A reference to the current value. If the update is successful, this value will be set to <paramref name="newValue"/>.
        /// </param>
        /// <param name="newValue">The new value to assign if it differs from the current value.</param>
        /// <param name="memberName">
        /// The name of the method associated with the value change, typically a property setter. 
        /// This parameter is optional and is automatically supplied by the compiler.
        /// </param>
        /// <returns><see langword="true"/> if the value was updated; otherwise, <see langword="false"/>.</returns>
        protected virtual bool SetValue<T>(ref T oldValue, T newValue, [CallerMemberName] string memberName = "")
        {
            if (!StateWillChange(oldValue, newValue))
                return false;

            oldValue = newValue;
            NotifyStateChanged(memberName);
            return true;
        }

        /// <summary>
        /// Occurs when the state changes, providing the method name that triggered the change.
        /// </summary>
        public event Action<string>? StateChanged;

        /// <summary>
        /// Raises the state changed notification for the specified member, allowing observers to respond to changes.
        /// </summary>
        /// <remarks>Override this method to customize how state change notifications are dispatched.
        /// Notifications are suppressed if the SuppressNotifications property is set to true.</remarks>
        /// <param name="memberName">The name of the member whose state has changed. If not specified, the caller member's name is used.</param>
        protected virtual void NotifyStateChanged([CallerMemberName] string memberName = "")
        {
            if (SuppressNotifications) return;
            StateChanged?.Invoke(memberName);
        }

        /// <summary>
        /// Determines whether the specified value will be changed by <see cref="SetValue{T}(ref T, T, string)"/>.
        /// </summary>
        /// <param name="oldValue">The original value to compare.</param>
        /// <param name="newValue">The new value to compare against the original value.</param>
        /// <returns><see langword="true"/> if the new value will cause a state change; otherwise, <see langword="false"/>.</returns>
        public static bool StateWillChange<T>(T oldValue, T newValue)
        {
            if (oldValue != null) 
                return !oldValue.Equals(newValue);

            if (newValue != null) 
                return !newValue.Equals(oldValue);

            return false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether change notifications are suppressed.
        /// </summary>
        /// <remarks>When set to <see langword="true"/>, change notifications will not be raised. This can
        /// be useful when performing batch updates to avoid triggering multiple notifications. Set this property to
        /// <see langword="false"/> to resume normal notification behavior.</remarks>
        public bool SuppressNotifications { get; set; }
    }
}
