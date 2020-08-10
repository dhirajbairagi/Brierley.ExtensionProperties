using System;
using System.Security.Claims;

namespace Repository.Utilities
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid UserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var loggedInUserId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Guid.Parse(loggedInUserId);
        }

        public static string TenantId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            var tenant = principal.FindFirst("tenant")?.Value;

            return tenant;
        }
        public static string UserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            return principal.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static string UserEmail(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            return principal.FindFirst(ClaimTypes.Email)?.Value;
        }
    }
}