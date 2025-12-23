using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Shared.Dto;

/// <summary>
///     Represents a user profile in the SharpEngine system.
/// </summary>
public class UserProfile
{
    public UserId? UserId { get; init; }
    public string Username { get; init; } = default!;
    public string? Email { get; init; } = default!;
    public required string Auth0Identifier { get; init; }

    // TODO: What user details do we need from Auth0?

    public SocialMedia LinkedSocialMedia { get; init; } = new();

    public IEnumerable<Project> Projects { get; init; } = [];

    public IEnumerable<Achievement> Achievements { get; init; } = [];

    public UserSettings Settings { get; init; } = new();

    public DateTime FirstLogin { get; init; }
}

public class UserSettings
{
}