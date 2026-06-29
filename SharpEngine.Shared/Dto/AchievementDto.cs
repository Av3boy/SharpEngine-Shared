using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Shared.Dto;

/// <summary>
///     Represents an achievement that can be unlocked by users based on specific criteria or milestones within the SharpEngine ecosystem.
/// </summary>
public class AchievementDto
{
    /// <summary>
    ///     Gets or initializes the title of the achievement.
    /// </summary>
    /// <remarks>
    ///     A brief and descriptive name that represents the accomplishment or milestone associated with the achievement.
    /// </remarks>
    public required string Title { get; init; }
    
    /// <summary>
    ///     Gets or initializes the description of the achievement.
    /// </summary>
    /// <remarks>
    ///     A detailed explanation of the achievement and the criteria required to unlock it.
    /// </remarks>
    public required string Description { get; init; }

    /// <summary>
    ///     Gets or initializes the date and time when the achievement was unlocked.
    /// </summary>
    /// <remarks>
    ///     <see langword="null" /> when the achievement has not been unlocked yet. 
    ///     Once the achievement is unlocked, this property will be set to the date and time of unlocking.
    /// </remarks>
    public DateTime? UnlockedAt { get; init; }
    
    /// <summary>
    ///     Gets or initializes the URL of the icon representing the achievement.
    /// </summary>
    public required string IconUrl { get; init; }

    /// <summary>
    ///     Gets whether the achievement has been unlocked by the user.
    /// </summary>
    public bool IsAchieved => UnlockedAt.HasValue;

    /// <summary>
    ///     Gets or sets the progress towards unlocking the achievement, represented as a percentage (0 to 100).
    /// </summary>
    public int Progress { get; set; }

    /// <summary>
    ///     Gets or sets the unique identifier for the achievement.
    /// </summary>
    public AchievementId Id { get; set; }
}
