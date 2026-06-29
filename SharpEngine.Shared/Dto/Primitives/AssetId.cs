namespace SharpEngine.Shared.Dto.Primitives;

/// <summary>
///     Represents a unique identifier for an asset within the SharpEngine ecosystem.
/// </summary>
/// <param name="Value">The unique value for the asset identifier.</param>
public readonly record struct AssetId(Guid Value)
{
    /// <summary>
    ///     Gets a new instance of <see cref="AssetId"/> with a unique value generated using <see cref="Guid.NewGuid()"/>.
    /// </summary>
    /// <returns>A new <see cref="AssetId"/> instance.</returns>
    public static AssetId New() => new(Guid.NewGuid());

    /// <summary>
    ///     Converts an <see cref="AssetId"/> to a <see cref="Guid"/> implicitly.
    /// </summary>
    /// <param name="id">The <see cref="AssetId"/> to be converted to a <see cref="Guid"/>.</param>
    public static implicit operator Guid(AssetId id) => id.Value;

    /// <summary>
    ///     Converts a <see cref="Guid"/> to an <see cref="AssetId"/> implicitly.
    /// </summary>
    /// <param name="value">The <see cref="Guid"/> to be converted to an <see cref="AssetId"/>.</param>
    public static implicit operator AssetId(Guid value) => new(value);
}