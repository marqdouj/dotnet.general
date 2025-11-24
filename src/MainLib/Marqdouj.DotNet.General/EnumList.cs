using System.Collections.ObjectModel;

namespace Marqdouj.DotNet.General
{
    /// <summary>
    /// Manages a list of Enum (no duplicates).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EnumList<T> where T : Enum
    {
        private readonly List<T> items = [];

        public EnumList()
        { Items = new ReadOnlyCollection<T>(items); }

        public EnumList(IEnumerable<T> values)
            : this()
        { AddValues(values); }

        /// <summary>
        /// Gets the collection of items contained in the current instance.
        /// </summary>
        public IReadOnlyCollection<T> Items { get; }

        /// <summary>
        /// Adds the specified item to the collection.
        /// </summary>
        /// <remarks>Duplicates and null values are ignored.</remarks>
        /// <param name="item">The item to add to the collection.</param>
        /// <returns>true if item was added; otherwise false</returns>
        public bool AddValue(T item)
        {
            if (item == null)
                return false;

            if (!items.Contains(item))
            {
                items.Add(item);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Attempts to add each element in the specified collection to the current instance.
        /// <see cref="AddValue(T)"/>
        /// </summary>
        /// <param name="values">The collection of values to add.</param>
        public void AddValues(IEnumerable<T> values)
        {
            if (values == null)
                return;

            foreach (var item in values)
            {
                AddValue(item);
            }
        }

        /// <summary>
        /// Adds one or more values to the collection.
        /// <see cref="AddValue(T)"/>
        /// </summary>
        /// <param name="values">An array of values to add to the collection.</param>
        public void AddValues(params T[] values)
        {
            foreach (var item in values)
            {
                AddValue(item);
            }
        }

        /// <summary>
        /// <see cref="List{T}.Contains(T)"/>
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true if item was found in the list; otherwise false</returns>
        public bool Contains(T value) { return items.Contains(value); }

        /// <summary>
        /// Removes the first occurrence of the specified item from the collection.
        /// </summary>
        /// <param name="value">The item to remove from the collection. If the item is not found, no action is taken.</param>
        /// <returns>true if the item was successfully removed; otherwise false.</returns>
        public bool RemoveItem(T value) => items.Remove(value);

        /// <summary>
        /// Removes each item in the collection from the current set.
        /// </summary>
        /// <remarks>If an item in the collection does not exist, it is ignored and not counted
        /// toward the return value. The method processes each item in the order provided by the collection.</remarks>
        /// <param name="values">A collection of items to remove from the set. Each item will be removed if it exists; duplicate items in the
        /// collection are removed once per occurrence.</param>
        /// <returns>The number of items successfully removed from the set.</returns>
        public int RemoveItems(IEnumerable<T> values)
        {
            var count = 0;

            foreach (var item in values)
            {
                if (RemoveItem(item))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Removes all occurrences of the specified items from the collection.
        /// </summary>
        /// <remarks>If an item in <paramref name="values"/> does not exist in the collection, it is
        /// ignored. The method processes each value independently and may remove the same value multiple times if it
        /// appears more than once in the input array.</remarks>
        /// <param name="values">An array of items to remove from the collection. Each item will be removed if present; duplicate values are
        /// removed for each occurrence.</param>
        /// <returns>The number of items successfully removed from the collection.</returns>
        public int RemoveItems(params T[] values)
        {
            var count = 0;

            foreach (var item in values)
            {
                if (RemoveItem(item))
                    count++;
            }

            return count;
        }

        /// <summary>
        /// Returns a list of string representations of the items in the collection, optionally sorted in ascending
        /// order.
        /// </summary>
        /// <param name="sorted">true to return the names sorted in ascending order; false to preserve the original order.</param>
        /// <returns>A list of strings containing the names of all items in the collection. The list will be empty if the
        /// collection contains no items.</returns>
        public List<string> GetNames(bool sorted = true)
        {
            return sorted
                ? [.. items.Select(e => e.ToString()).OrderBy(e => e)]
                : [.. items.Select(e => e.ToString())];
        }
    }
}
