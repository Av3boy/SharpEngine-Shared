using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Launcher.Enums;
using SharpEngine.IO;
using SharpEngine.Shared.Attributes;

namespace SharpEngine.Shared.Dto;

/// <summary>
///     Represents a SharpEngine project.
/// </summary>
public class ProjectDto : SaveableFile<ProjectDto>
{
    public const string ProjectFileExtension = "sharpproject";

    /// <summary>
    ///     An identifier for the current project within the launcher UI.
    /// </summary>
    public readonly Guid Id = Guid.NewGuid();

    /// <summary>Gets or sets the version of SharpEngine used by the project.</summary>
    [GridElement(Title = "Engine Version")]
    public EngineVersionDto EngineVersion { get; init; } = new();

    /// <summary>
    ///     Gets or sets the name of the project.
    /// </summary>
    [Required]
    [GridElement(Title = "Project Name")]
    public string? Name { get; set; }

    /// <summary>Gets or sets the URI of the repository where the project is hosted.</summary>
    [GridElement(Icon = SvgIcon.VersionControl)]
    public string? RepositoryUrl { get; set; }

    // TODO: Repository type (e.g., GitHub, GitLab, Bitbucket, etc.)
    public RepositoryType RepositoryType { get; set; }

    /// <summary>
    ///     Gets or sets the path to the project file.
    /// </summary>
    [Required]
    public string? Path { get; set; }

    /// <summary>
    ///     Gets or sets when the project was last modified.
    /// </summary>
    [JsonIgnore]
    [DisplayName("Last Modified")]
    public DateTime LastModified { get; set; } = DateTime.Now;

    /// <summary>
    ///     Gets or sets the list of scene files associated with the project.
    /// </summary>
    public List<string> SceneFiles { get; set; } = [];

    /// <summary>
    ///     Loads the given project file.
    /// </summary>
    /// <param name="projectFile">The file containing the project to load.</param>
    /// <returns>The loaded project. If unable to load, <see langword="null" />.</returns>
    public static ProjectDto? LoadProject(string projectFile)
    {
        var json = File.ReadAllText(projectFile);
        var project = JsonSerializer.Deserialize<ProjectDto>(json);

        if (project is not null)
            project.LastModified = File.GetLastWriteTime(projectFile);

        return project;
    }
}

public enum RepositoryType
{
    GitHub,
    GitLab,
    Bitbucket,
    Other
}

public static class RepositoryTypeExtensions
{
    public static RepositoryType FromUrl(string url)
    {
        if (url.Contains("github.com"))
            return RepositoryType.GitHub;

        if (url.Contains("gitlab.com"))
            return RepositoryType.GitLab;

        if (url.Contains("bitbucket.org"))
            return RepositoryType.Bitbucket;

        return RepositoryType.Other;
    }
}