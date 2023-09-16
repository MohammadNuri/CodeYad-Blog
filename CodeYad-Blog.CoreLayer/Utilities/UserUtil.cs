using CodeYad_Blog.DataLayer.Entities;
using System.Security.Claims;

namespace CodeYad_Blog.CoreLayer.Utilities;

public static class UserUtil
{
    public static int GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return Convert.ToInt32(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
    }
    public static string GetUsername(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return principal.FindFirst(ClaimTypes.Name)?.Value;
    }
    public static string GetUserRole(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        var roleClaim = principal.FindFirst(ClaimTypes.Role)?.Value;

        // Map the role claim value to your enum
        if (Enum.TryParse<UserRole>(roleClaim, out var role))
        {
            return role.ToString();
        }

        return string.Empty;
    }
}