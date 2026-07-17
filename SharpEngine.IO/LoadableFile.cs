using System.Text.Json;

namespace SharpEngine.IO;

/// <summary>
///     Represents a file that can be loaded from disk.
/// </summary>
public abstract class LoadableFile<T> where T : LoadableFile<T>, new()
{
    private string? _fileFullPath;

    /// <summary>Gets or sets the name derived from the file path.</summary>
    public string Name { get; protected set; } = string.Empty;

    /// <summary>
    ///     Sets the full path and name of the file.
    /// </summary>
    /// <param name="filePath">The full path of the file to be set and processed for name extraction.</param>
    public void SetFileFullPath(string filePath)
    {
        _fileFullPath = filePath;
        Name = Path.GetFileNameWithoutExtension(filePath);
    }

    /// <summary>
    ///     Gets the full path of the file.
    /// </summary>
    /// <returns>The full path; <see langword="null"/> if not yet set.</returns>
    public string? GetFileFullPath()
        => _fileFullPath;

    /// <summary>
    ///     Loads the file from the given <paramref name="filePath"/>.
    /// </summary>
    /// <param name="filePath">The path of the file to load.</param>
    /// <returns>The deserialized instance; <see langword="null"/> if deserialization fails.</returns>
    public static T? Load(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var loaded = JsonSerializer.Deserialize<T>(json);

        if (loaded is not null)
        {
            loaded.SetFileFullPath(filePath);
            return loaded;
        }

        return null;
    }
}
