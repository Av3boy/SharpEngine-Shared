namespace SharpEngine.Shared.Dto.Primitives;

/// <summary>
///     Represents a unique identifier for a user within the SharpEngine ecosystem.
/// </summary>
/// <param name="Value">The unique value for the user identifier.</param>
public readonly record struct UserId(Guid Value)
{
    /// <summary>
    ///     Gets a new instance of <see cref="UserId"/> with a unique value generated using <see cref="Guid.NewGuid()"/>.
    /// </summary>
    /// <returns>A new <see cref="UserId"/> instance.</returns>
    public static UserId New() => new(Guid.NewGuid());

    /// <summary>
    ///     Converts an <see cref="UserId"/> to a <see cref="Guid"/> implicitly.
    /// </summary>
    /// <param name="id">The <see cref="UserId"/> to be converted to a <see cref="Guid"/>.</param>
    public static implicit operator Guid(UserId id) => id.Value;

    /// <summary>
    ///     Converts a <see cref="Guid"/> to an <see cref="UserId"/> implicitly.
    /// </summary>
    /// <param name="value">The <see cref="Guid"/> to be converted to an <see cref="UserId"/>.</param>
    public static implicit operator UserId(Guid value) => new(value);
}
