using System.Text.Json;
using System.Text.Json.Serialization;

namespace SharpEngine.IO;

/// <summary>
///     Represents a file that can be saved to and loaded from disk.
/// </summary>
public abstract class SaveableFile<T> : LoadableFile<T> where T : SaveableFile<T>, new()
{
    /// <summary>Gets or sets whether the file has unsaved changes.</summary>
    [JsonIgnore]
    public bool HasUnsavedChanges { get; set; }

    /// <summary>
    ///     Determines whether the file has been saved before and has a save file.
    /// </summary>
    /// <returns><see langword="true"/> if the file has a save path; otherwise, <see langword="false"/>.</returns>
    public bool HasSaveFile()
        => GetFileFullPath() is not null;

    // TODO: No!!!! Fix this!!
    /// <summary>
    ///     Saves the file synchronously.
    /// </summary>
    public void Save()
        => SaveAsync().GetAwaiter().GetResult();

    /// <summary>
    ///     Saves the file to its current path.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing an asynchronous operation.</returns>
    public async Task SaveAsync()
        => await SaveAsync(GetFileFullPath()!);

    /// <summary>
    ///     Saves the file to the given <paramref name="fileName"/>.
    /// </summary>
    /// <param name="fileName">The path of the file to save to.</param>
    /// <returns>A <see cref="Task"/> representing an asynchronous operation.</returns>
    public async Task SaveAsync(string fileName)
    {
        var json = JsonSerializer.Serialize(this, GetType());
        await File.WriteAllTextAsync(fileName, json);

        HasUnsavedChanges = false;
    }
}
