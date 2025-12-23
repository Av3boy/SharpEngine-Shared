using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Shared.Dto;

public class Achievement
{
    public required string Title { get; init; }
    public required string Description { get; init; }
    public DateTime? UnlockedAt { get; init; }
    public required string IconUrl { get; init; }

    public bool IsAchieved => UnlockedAt.HasValue;
    public int Progress { get; set; }
    public AchievementId Id { get; set; }
}
