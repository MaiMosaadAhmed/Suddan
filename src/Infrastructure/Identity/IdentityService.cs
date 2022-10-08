using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuddanApplication.Application.Common.Interfaces;
using SuddanApplication.Application.Common.Models;

namespace SuddanApplication.Infrastructure.Identity;
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
    }

    public async Task<string> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<dynamic> GetUserByNameAsync(string userName)
    {
        var user = await _userManager.Users.FirstAsync(u => u.UserName == userName);

        return user;
    }

    public async Task<dynamic> GetUserByIdAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user;
    }

    public async Task<bool> CheckPassword(string userName, string Password)
    {
        var user = await _userManager.Users.FirstAsync(u => u.UserName == userName);

        //var s = await _userManager.ChangePasswordAsync(user, Password, "1!AaCc2@");
        return await _userManager.CheckPasswordAsync(user, Password);
        //return user.UserName;
    }

    public async Task<(Result Result, string UserId)> ChangePassword(string userId, string oldPassword, string newPassword)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        return (result.ToApplicationResult(), user.Id);
        //return user.UserName;
    }

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string Email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = Email,
        };

        var result = await _userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<(Result Result, string UserId, string Role)> AddToRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        var result = await _userManager.AddToRolesAsync(user, new[] { role });
       
        return (result.ToApplicationResult(), user.Id, role);

    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }
}
