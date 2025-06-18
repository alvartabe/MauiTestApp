#if IOS
using WebKit;
using Microsoft.Maui.Handlers;
using Foundation;

public class InspectableWebViewHandler : WebViewHandler
{
    protected override void ConnectHandler(WKWebView platformView)
        {
            base.ConnectHandler(platformView);

            // enable Safari Web Inspector
             platformView.Inspectable = true;
        }
    }

#endif
