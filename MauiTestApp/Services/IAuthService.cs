using System.Threading.Tasks;
using IdentityModel.OidcClient;

namespace MauiTestApp.Services
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync();
    }
}
