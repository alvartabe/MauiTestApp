using IdentityModel.OidcClient.Browser;
using IBrowser = IdentityModel.OidcClient.Browser.IBrowser;

public class WebAuthenticatorBrowser : IBrowser
{
    public async Task<BrowserResult> InvokeAsync(BrowserOptions options, CancellationToken cancellationToken = default)
    {
        var result = await WebAuthenticator.AuthenticateAsync(new Uri(options.StartUrl), new Uri(options.EndUrl));
        var authorizeResponse = ToRawIdentityUrl(options.EndUrl, result);
        return new BrowserResult
        {
            Response = authorizeResponse
        };
    }

    public string ToRawIdentityUrl(string redirectUrl, WebAuthenticatorResult result)
    {
        IEnumerable<string> parameters = result.Properties.Select(pair => $"{pair.Key}={pair.Value}");
        var values = string.Join("&", parameters);

        return $"{redirectUrl}#{values}";
    }
}
