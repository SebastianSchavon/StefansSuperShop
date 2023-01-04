using System.Linq;
using System.Security.Principal;

namespace StefansSuperShop.Helpers;

public static class UserExtensions
{
    public static bool IsInAnyRole(this IPrincipal principal, params string[] roles)
    {
        return roles.Any(principal.IsInRole);
    }
}