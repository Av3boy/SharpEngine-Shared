using System.Collections;
using System.Runtime.InteropServices;

namespace SharpEngine.Shared.Obsessions;

/// <summary>
///    Represents a collection of string values where each value is associated with a count.
/// </summary>
/// <typeparam name="TItem">The type of items in the collection.</typeparam>
public abstract class CountedStringCollection<TItem> : IReadOnlyCollection<TItem>
{
    private readonly Dictionary<string, int> _counts;

    /// <summary>
    ///     Initializes an empty instance of the <see cref="CountedStringCollection{TItem}"/>.
    /// </summary>
    protected CountedStringCollection() : this(StringComparer.Ordinal) { }

    /// <summary>
    ///    Initializes an empty instance of the <see cref="CountedStringCollection{TItem}"/> with a specified string comparer.
    /// </summary>
    /// <param name="comparer">The string comparer to use.</param>
    protected CountedStringCollection(IEqualityComparer<string> comparer)
    {
        _counts = new Dictionary<string, int>(comparer);
    }

    /// <summary>
    ///    Initializes a new instance of the <see cref="CountedStringCollection{TItem}"/> with the specified values.
    /// </summary>
    /// <param name="values">The values to initialize the collection with.</param>
    protected CountedStringCollection(IEnumerable<string> values) : this()
    {
        AddRange(values);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="CountedStringCollection{TItem}"/> with the specified items.
    /// </summary>
    /// <param name="items">The items to initialize the collection with.</param>
    /// <param name="comparer">The string comparer to use.</param>
    protected CountedStringCollection(IEnumerable<TItem> items, IEqualityComparer<string>? comparer = null)
        : this(comparer ?? StringComparer.Ordinal)
    {
        AddRange(items);
    }

    /// <inheritdoc cref="IReadOnlyCollection{TItem}.Count"/>
    public int Count => _counts.Count;

    /// <summary>
    ///    Creates an item of type <typeparamref name="TItem"/> from the specified value and count.
    /// </summary>
    /// <param name="value">The value to create the item from.</param>
    /// <param name="count">The count to create the item with.</param>
    /// <returns>The created item.</returns>
    protected abstract TItem CreateItem(string value, int count);

    /// <summary>
    ///     Gets the string value associated with the specified item.
    /// </summary>
    /// <param name="item">The item to get the value for.</param>
    /// <returns>The string value.</returns>
    protected abstract string GetValue(TItem item);

    /// <summary>
    ///    Gets the count associated with the specified item.
    /// </summary>
    /// <param name="item">The item to get the count for.</param>
    /// <returns>The count.</returns>
    protected abstract int GetCount(TItem item);

    /// <summary>
    ///     Validates the specified string value. This method is called before adding a value to the collection.
    /// </summary>
    /// <param name="value">The value to validate.</param>
    protected virtual void ValidateValue(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
    }

    /// <summary>
    ///     Adds a string value to the collection, incrementing its count if it already exists.
    /// </summary>
    /// <param name="value">The value to add.</param>
    public void Add(string value)
    {
        ValidateValue(value);

        ref int count = ref CollectionsMarshal.GetValueRefOrAddDefault(_counts, value, out _);

        count++;
    }

    /// <summary>
    ///     Adds a string value to the collection with a specified count, incrementing its count if it already exists.
    /// </summary>
    /// <param name="value">The value to add.</param>
    /// <param name="count">The count to add.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the count is not greater than zero.</exception>
    public void Add(string value, int count)
    {
        ValidateValue(value);

        if (count <= 0)
            throw new ArgumentOutOfRangeException(nameof(count), "Count must be greater than zero.");

        ref int current = ref CollectionsMarshal.GetValueRefOrAddDefault(_counts, value, out _);

        current += count;
    }

    /// <summary>
    ///     Adds an item to the collection.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void Add(TItem item)
        => Add(GetValue(item), GetCount(item));

    /// <summary>
    ///    Adds a range of string values to the collection, incrementing their counts if they already exist.
    /// </summary>
    /// <param name="values">The values to add.</param>
    public void AddRange(IEnumerable<string> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        foreach (string value in values)
        {
            Add(value);
        }
    }

    /// <summary>
    ///    Adds a range of items to the collection.
    /// </summary>
    /// <param name="items">The items to add.</param>
    public void AddRange(IEnumerable<TItem> items)
    {
        ArgumentNullException.ThrowIfNull(items);

        foreach (TItem item in items)
            Add(item);
    }

    /// <summary>
    ///    Removes a string value from the collection.
    /// </summary>
    /// <param name="value">The value to remove.</param>
    /// <returns><see langword="true"/> if the value was removed; otherwise, <see langword="false"/>.</returns>
    public bool Remove(string value)
    {
        ValidateValue(value);

        return _counts.Remove(value);
    }

    /// <summary>
    ///    Gets the count associated with the specified string value, or returns zero if the value does not exist in the collection.
    /// </summary>
    /// <param name="value">The value to get the count for.</param>
    /// <returns>The count of the specified value, or zero if it does not exist.</returns>
    public int GetCountOrDefault(string value)
    {
        ValidateValue(value);

        return _counts.GetValueOrDefault(value);
    }

    /// <summary>
    ///    Tries to get the count associated with the specified string value.
    /// </summary>
    /// <param name="value">The value to get the count for.</param>
    /// <param name="count">When this method returns, contains the count of the specified value, or zero if it does not exist.</param>
    /// <returns><see langword="true"/> if the value was found; otherwise, <see langword="false"/>.</returns>
    public bool TryGetCount(string value, out int count)
    {
        ValidateValue(value);

        return _counts.TryGetValue(value, out count);
    }

    /// <inheritdoc cref="IEnumerable{T}.GetEnumerator"/>
    public IEnumerator<TItem> GetEnumerator()
    {
        foreach (KeyValuePair<string, int> pair in _counts)
        {
            yield return CreateItem(pair.Key, pair.Value);
        }
    }

    /// <inheritdoc cref="IEnumerable.GetEnumerator"/>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}