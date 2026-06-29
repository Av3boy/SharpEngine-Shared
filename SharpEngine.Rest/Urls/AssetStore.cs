using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Urls;

/// <summary>
///     Contains REST API endpoint URLs for the asset store.
/// </summary>
public static class AssetStore
{
    /// <summary>
    ///     The base URL for the asset store API, which is used as the starting point for constructing all API endpoint URLs.
    /// </summary>
    public const string BaseUrl = "https://assetstore.sharpengine.com/";

    /// <summary>
    ///     Gets the base route for version 1 of the asset store API
    /// </summary>
    /// <remarks>
    ///     Used as a prefix for all API endpoints related to assets, comments, checkout, and other operations in the asset store.
    /// </remarks>
    // TODO: Figure out a smart way of controlling the versioning.
    public const string Apiv1Route = "api/v1";

    /// <summary>
    ///     Gets the route for asset-related operations in the asset store API.
    /// </summary>
    public const string AssetsRoute = Apiv1Route + "/assets";

    /// <summary>
    ///     Gets the route for comment-related operations in the asset store API.
    /// </summary>
    public const string CommentsRoute = Apiv1Route + "/comments";

    /// <summary>
    ///     Gets the route for checkout-related operations in the asset store API.
    /// </summary>
    public const string ChecoutRoute = Apiv1Route + "/checkout";

    /// <summary>
    ///     Gets the URL for retrieving an asset by its unique identifier.
    /// </summary>
    /// <param name="assetId">The unique identifier of the asset to retrieve.</param>
    /// <returns>The URL for the requested asset.</returns>
    public static string GetById(Guid assetId) => $"assets/{assetId}";

    /// <summary>
    ///     Gets the URL for retrieving all assets that match a specific keyword.
    /// </summary>
    /// <remarks>
    ///     Used as a constant in e.g. controller attributes.
    /// </remarks>
    public const string GET_ALL_BY_KEYWORD = "/keyword";

    /// <summary>
    ///     Gets the URL for retrieving all assets created by a specific author, identified by their user ID.
    /// </summary>
    /// <param name="authorId">The unique identifier of the author whose assets to retrieve.</param>
    /// <returns>The URL for the requested assets.</returns>
    public static string GetAllByAuthor(UserId authorId) => $"/author/{authorId.Value}";

    /// <summary>
    ///     Gets the URL for retrieving all assets created by a specific author, identified by their user ID.
    /// </summary>
    /// <remarks>
    ///     Used as a constant in e.g. controller attributes.
    ///     Use <see cref="GetAllByAuthor"/> for constructing URLs with specific author IDs."/>
    /// </remarks>
    public const string GET_ALL_BY_AUTHOR = "/author/{authorId}";

    /// <summary>
    ///     Gets the URL for retrieving all comments associated with a specific asset, identified by its unique identifier.
    /// </summary>
    /// <remarks>Used as a constant in e.g. controller attributes.</remarks>
    public const string GET_ALL_ASSET_COMMENTS = "/{assetId}/comment";
}