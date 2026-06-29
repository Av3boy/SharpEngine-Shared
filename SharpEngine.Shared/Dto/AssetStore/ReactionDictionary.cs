using SharpEngine.Shared.Obsessions;

namespace SharpEngine.Shared.Dto.AssetStore;

/// <summary>
///     Represents a collection of reactions, where each reaction type is associated with a count of how many times that reaction has been made.
/// </summary>
public sealed class ReactionDictionary : CountedStringCollection<Reaction>
{
    /// <summary>
    ///     Initializes an empty instance of the <see cref="ReactionDictionary"/>.
    /// </summary>
    public ReactionDictionary() : base() { }

    /// <summary>
    ///     Initializes a new instance of the <see cref="ReactionDictionary"/> with the specified reactions.
    /// </summary>
    /// <param name="reactions">The reactions to initialize the dictionary with.</param>
    public ReactionDictionary(IEnumerable<string> reactions) : base(reactions) { }

    /// <summary>
    ///    Initializes a new instance of the <see cref="ReactionDictionary"/> with the specified reactions and their counts.
    /// </summary>
    /// <param name="reactions">The reactions to initialize the dictionary with.</param>
    public ReactionDictionary(IEnumerable<Reaction> reactions) : base(reactions) { }

    /// <inheritdoc />
    protected override Reaction CreateItem(string value, int count)
        => new(value, count);

    /// <inheritdoc />
    protected override string GetValue(Reaction item)
        => item.ReactionType;

    /// <inheritdoc />
    protected override int GetCount(Reaction item)
        => item.Count;
}
