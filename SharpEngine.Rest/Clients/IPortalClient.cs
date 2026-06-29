using SharpEngine.Shared.Dto;
using SharpEngine.Shared.Dto.Primitives;

namespace SharpEngine.Rest.Clients;

internal interface IPortalClient
{
    Task<UserProfileDto> CreateUser(UserProfileDto user);
    Task GetUserAchievements(UserId userId);
    Task<UserProfileDto> GetUserDetails(UserId userId);
}