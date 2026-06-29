namespace AssetStore.Api.v1.DTO.Payload;

/// <summary>
///     Represents the payload for creating a new asset in the asset store.
/// </summary>
public sealed class CreateAssetPayloadDto
{
    /// <summary>Gets or sets the name of the asset.</summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>Gets or sets the description of the asset.</summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>Gets or sets the price of the asset in USD.</summary>
    public decimal PriceUsd { get; set; }

    /// <summary>Gets or sets the keywords associated with the asset.</summary>
    public IReadOnlyList<string> KeyWords { get; set; } = [];

    // (e.g., model, texture, sound, etc.)
    // public AssetType

    /// <summary>
    ///     Gets or sets the URI of the blob storage where the asset file is stored.
    /// </summary>
    /// <example>
    ///     {Blob storage base url}/{container}/{blobName}/{author}/{assetId}/{version}/{assetId}
    /// </example>
    public required string BlobUri { get; set; }

    /// <summary>
    ///     Gets or sets the size of the asset file in bytes.
    /// </summary>
    /// <remarks>
    ///     This is used for validating the file size before upload and for display purposes in the asset store.
    /// </remarks>
    public required int FileSizeBytes { get; set; }

    /// <summary>
    ///     Gets or sets the SHA-256 hash checksum of the asset file for integrity verification.
    /// </summary>
    public required string Checksum { get; set; }

    /// <summary>
    ///     Gets or sets the URL of the asset's thumbnail image for display.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;
}
