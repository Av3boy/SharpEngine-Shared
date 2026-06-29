namespace SharpEngine.Shared;

/// <summary>
///     Defines the type of the asset.
/// </summary>
public enum AssetType
{
    /// <summary>
    ///     The asset is a shader.
    /// </summary>
    /// <remarks>
    ///     Shaders can be used to create various visual effects, such as lighting, shadows, and post-processing effects.
    /// </remarks>
    Shader,

    /// <summary>
    ///     The asset is a 3D model.
    /// </summary>
    /// <remarks>
    ///     3D models are geometric representations of objects in three-dimensional space.
    /// </remarks>
    Model,

    /// <summary>
    ///     The asset is a texture.
    /// </summary>
    /// <remarks>
    ///     Textures are images that are applied to the surface of 3D models to give them color, detail, and other visual properties.
    /// </remarks>
    Texture,
}
