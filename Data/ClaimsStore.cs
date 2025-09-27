using System.Security.Claims;

namespace Project.Data
{
    public static class ClaimsStore
    {
        public static List<Claim> claimsList =
            [
            new Claim("Create","Create"),
            new Claim("Edit","Edit"),
            new Claim("Delete","Delete")

            ];
    }
}
