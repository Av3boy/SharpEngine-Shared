using Microsoft.AspNetCore.Mvc;

namespace SharpEngine.Rest.ValidationAttributes;

/// <summary>
///     Contains helper methods for filter attributes.
/// </summary>
public static class FilterAttributeUtils
{
    /// <summary>
    ///     Create IActionResult with status code and content.
    /// </summary>
    /// <param name="statusCode">The response status code of the API.</param>
    /// <param name="content">Content of the response.</param>
    /// <returns>The possible content and the Status Code of an exception.</returns>
    public static IActionResult CreateResult(int statusCode, object? content = null)
        => content is null ?
            new StatusCodeResult(statusCode) :
            new ObjectResult(content) { StatusCode = statusCode };
}
