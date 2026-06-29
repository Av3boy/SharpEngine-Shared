namespace SharpEngine.Shared.Dto;

/// <summary>
///     Represents the social media links associated with a user in the SharpEngine ecosystem.
/// </summary>
public class SocialMediaDto
{
    /// <summary>
    ///     Gets or sets the URL to the user's Instagram profile.
    /// </summary>
    public string? InstagramLink { get; set; }

    /// <summary>
    ///     Gets or sets the URL to the user's X (formerly Twitter) profile.
    /// </summary>
    public string? XLink { get; set; }
    /// <summary>
    ///     Gets or sets the URL to the user's LinkedIn profile.
    /// </summary>
    public string? LinkedInLink { get; set; }
    /// <summary>
    ///     Gets or sets the URL to the user's GitHub profile.
    /// </summary>
    public string? GitHubLink { get; set; }
}