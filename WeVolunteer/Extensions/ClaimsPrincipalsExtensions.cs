using System.Security.Claims;

namespace WeVolunteer.Extensions
{
    public static class ClaimsPrincipalsExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
