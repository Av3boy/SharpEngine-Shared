namespace SharpEngine.Shared.Dto.Primitives;

/// <summary>
///     Represents a unique identifier for a comment within the SharpEngine ecosystem.
/// </summary>
/// <param name="Value">The unique value for the comment identifier.</param>
public readonly record struct CommentId(Guid Value)
{
    /// <summary>
    ///     Gets a new instance of <see cref="CommentId"/> with a unique value generated using <see cref="Guid.NewGuid()"/>.
    /// </summary>
    /// <returns>A new <see cref="CommentId"/> instance.</returns>
    public static CommentId New() => new(Guid.NewGuid());

    /// <summary>
    ///     Converts an <see cref="CommentId"/> to a <see cref="Guid"/> implicitly.
    /// </summary>
    /// <param name="id">The <see cref="CommentId"/> to be converted to a <see cref="Guid"/>.</param>
    public static implicit operator Guid(CommentId id) => id.Value;

    /// <summary>
    ///     Converts a <see cref="Guid"/> to an <see cref="CommentId"/> implicitly.
    /// </summary>
    /// <param name="value">The <see cref="Guid"/> to be converted to an <see cref="CommentId"/>.</param>
    public static implicit operator CommentId(Guid value) => new(value);
}
