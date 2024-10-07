using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Results;
using System;
using System.Threading.Tasks;

namespace MauiTestApp.Services
{

    public class AuthService: IAuthService
    {
        private readonly OidcClient _oidcClient;
        private string _refreshToken;

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
                Console.WriteLine($"Refresh Token: {result.RefreshToken}");
                // Update the refresh token
                _refreshToken = result.RefreshToken;
            }

            return result;
        }

        public async Task<RefreshTokenResult> RefreshTokenAsync()
        {
            if (string.IsNullOrEmpty(_refreshToken))
            {
                throw new InvalidOperationException("No refresh token available. Please log in first.");
            }

            var result = await _oidcClient.RefreshTokenAsync(_refreshToken);
            if (result.IsError)
            {
                // Handle error
                Console.WriteLine(result.Error);
            }
            else
            {
                // Successful token refresh
                Console.WriteLine($"New Access Token: {result.AccessToken}");
                Console.WriteLine($"New Refresh Token: {result.RefreshToken}");
                _refreshToken = result.RefreshToken;

            }

            return result;
        }
    }

}