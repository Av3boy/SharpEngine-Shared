namespace SharpEngine.Identity;

/// <summary>
///     Defines methods for interacting with Auth0 for authentication and authorization.
/// </summary>
public interface IAuth0Client
{
    /// <summary>
    ///     Retrieves an access token from Auth0.
    /// </summary>
    /// <param name="token">A cancellation token to cancel the operation.</param>
    /// <returns>
    ///     A <see cref="Task{Auth0TokenResponseDto}"/> that represents the asynchronous operation.
    ///     The <see cref="Task{Auth0TokenResponseDto}.Result"/> contains the access token response.
    /// </returns>
    Task<Auth0TokenResponseDto?> GetAccessTokenAsync(CancellationToken token = default);
}