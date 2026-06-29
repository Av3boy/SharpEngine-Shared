using SharpEngine.Shared.Dto.AssetStore;
using SharpEngine.Shared.Dto.Primitives;

namespace AssetStore.Api.v1.DTO.Payload;

/// <summary>
///     Represents a REST API payload for creating a comment.
/// </summary>
public class CreateCommentPayloadDto
{
    /// <summary>
    ///     Gets or initializes the asset Id to which the comment belongs.
    /// </summary>
    public AssetId AssetId { get; init; }

    /// <summary>
    ///     Gets or initializes the content of the comment.
    /// </summary>
    public required string Content { get; init; }

    /// <summary>
    ///     Gets or initializes the unique Id of the parent comment.
    /// </summary>
    public CommentId? ParentCommentId { get; init; }
}
