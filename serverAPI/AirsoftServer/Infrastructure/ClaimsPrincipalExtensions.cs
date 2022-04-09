namespace Infrastructure
{
    using System.Security.Claims;

    public static class ClaimsPrincipalExtensions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.Claims.First(x => x.Type == "UserId").Value;
    }
}