using System.Security.Claims;

namespace AdBoard.Infrastructure.Extentions;

public static class ClaimsPrincipalExtention
{
    public static string GetClaimValue(this ClaimsPrincipal user, string claimType)
    {
        return user.FindFirst(claimType)?.Value ?? string.Empty;
    }

    public static string GetUserId(this ClaimsPrincipal user)
    {
        return user.GetClaimValue(ClaimTypes.NameIdentifier);
    }

    public static string GetUserEmail(this ClaimsPrincipal user)
    {
        return user.GetClaimValue(ClaimTypes.Email);
    }

    public static string GetUserRole(this ClaimsPrincipal user)
    {
        return user.GetClaimValue(ClaimTypes.Role);
    }

    public static DateOnly GetUserDateOfBirth(this ClaimsPrincipal user)
    {
        return DateOnly.Parse(user.GetClaimValue(ClaimTypes.DateOfBirth));
    }
}
