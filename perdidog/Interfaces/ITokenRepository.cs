using Microsoft.AspNetCore.Identity;

namespace perdidog.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);

    }
}
