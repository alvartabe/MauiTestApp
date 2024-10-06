using IdentityModel.OidcClient;
using System;
using System.Threading.Tasks;

namespace MauiTestApp.Services
{

    public class AuthService: IAuthService
    {
        private readonly OidcClient _oidcClient;

        public AuthService()
        {
            var options = new OidcClientOptions
            {
                Authority = "https://auth.livetula.com",
                ClientId = "mobile-client",
                RedirectUri = "myapp://callback",
                Scope = "scope openid offline_access gateway-api",
                Browser = new WebAuthenticatorBrowser()
            };

            _oidcClient = new OidcClient(options);
        }

        public async Task<LoginResult> LoginAsync()
        {
            var result = await _oidcClient.LoginAsync(new LoginRequest());
            if (result.IsError)
            {
                // Handle error
                Console.WriteLine(result.Error);
            }
            else
            {
                // Successful authentication
                Console.WriteLine($"Access Token: {result.AccessToken}");
            }

            return result;
        }
    }

}