namespace SharpEngine.Shared.Dto.Primitives;

public readonly record struct AchievementId(Guid Value)
{
    public static AchievementId New() => new(Guid.NewGuid());
    public static implicit operator Guid(AchievementId id) => id.Value;
    public static implicit operator AchievementId(Guid value) => new(value);
}
