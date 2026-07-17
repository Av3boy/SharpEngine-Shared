using SharpEngine.Shared.Dto;
using SharpEngine.Shared.Dto.Primitives;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpEngine.Rest.Clients.Portal;

internal interface IUserClient
{
    /// <summary>
    ///     Gets the details of a user by their ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="token">An optional cancellation token for cancelling the request when needed.</param>
    /// <returns>The user's profile details, or <see langword="null"/> if not found.</returns>
    Task<UserProfileDto?> GetUserDetailsAsync(UserId userId, CancellationToken token = default);

    /// <summary>
    ///     Creates a new user.
    /// </summary>
    /// <param name="user">The user details to create.</param>
    /// <param name="token">An optional cancellation token for cancelling the request when needed.</param>
    /// <returns>The created user's profile details, or <see langword="null"/> if creation failed.</returns>
    Task<UserProfileDto?> CreateUserAsync(UserProfileDto user, CancellationToken token = default);
}
