using IdentityModel.OidcClient.Browser;
using Microsoft.Maui.Authentication;
using System.Threading;
using System.Threading.Tasks;
using IBrowser = IdentityModel.OidcClient.Browser.IBrowser;

public class WebAuthenticatorBrowser : IBrowser
{
    public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
    {
        try
        {
            var authResult = await WebAuthenticator.Default.AuthenticateAsync(
                new Uri(options.StartUrl),
                new Uri(options.EndUrl)
            );

            return new BrowserResult
            {
                Response = $"{options.EndUrl}#access_token={authResult?.AccessToken}",
                ResultType = BrowserResultType.Success
            };
        }
        catch (TaskCanceledException)
        {
            return new BrowserResult
            {
                ResultType = BrowserResultType.UserCancel
            };
        }
        catch (Exception ex)
        {
            return new BrowserResult
            {
                Error = ex.Message,
                ResultType = BrowserResultType.UnknownError
            };
        }
    }
}
