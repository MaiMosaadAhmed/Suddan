using SuddanApplication.Application.Common.Models;

namespace SuddanApplication.Application.Common.Interfaces;
public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userId);

    Task<dynamic> GetUserByNameAsync(string userName);

    Task<dynamic> GetUserByIdAsync(string userId);

    Task<bool> CheckPassword(string userName, string Password);

    Task<(Result Result, string UserId)> ChangePassword(string userId, string oldPassword, string newPassword);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<(Result Result, string UserId, string Role)> AddToRoleAsync(string userId, string role);

    Task<(Result Result, string UserId)> CreateUserAsync(string userName, string Email, string password);

    Task<Result> DeleteUserAsync(string userId);
}
