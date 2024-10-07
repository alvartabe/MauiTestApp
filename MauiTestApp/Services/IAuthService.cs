using System.Threading.Tasks;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Results;

namespace MauiTestApp.Services
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync();
        Task<RefreshTokenResult> RefreshTokenAsync();
    }
}
