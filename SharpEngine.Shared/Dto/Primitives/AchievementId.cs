namespace SharpEngine.Shared.Dto.Primitives;

/// <summary>
///     Represents a unique identifier for an achievement within the SharpEngine ecosystem.
/// </summary>
/// <param name="Value">The unique value for the achievement identifier.</param>
public readonly record struct AchievementId(Guid Value)
{
    /// <summary>
    ///     Gets a new instance of <see cref="AchievementId"/> with a unique value generated using <see cref="Guid.NewGuid()"/>.
    /// </summary>
    /// <returns>A new <see cref="AchievementId"/> instance.</returns>
    public static AchievementId New() => new(Guid.NewGuid());

    /// <summary>
    ///     Converts an <see cref="AchievementId"/> to a <see cref="Guid"/> implicitly.
    /// </summary>
    /// <param name="id">The <see cref="AchievementId"/> to be converted to a <see cref="Guid"/>.</param>
    public static implicit operator Guid(AchievementId id) => id.Value;

    /// <summary>
    ///     Converts a <see cref="Guid"/> to an <see cref="AchievementId"/> implicitly.
    /// </summary>
    /// <param name="value">The <see cref="Guid"/> to be converted to an <see cref="AchievementId"/>.</param>
    public static implicit operator AchievementId(Guid value) => new(value);
}
