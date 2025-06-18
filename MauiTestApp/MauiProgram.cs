using Microsoft.Extensions.Logging;
using MauiTestApp.Services;
using MauiTestApp.ViewModel;
namespace MauiTestApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IAuthService, AuthService>();
		builder.Services.AddSingleton<MainPageViewModel>();
		builder.Services.AddSingleton<MainPage>();

#if IOS
		builder.ConfigureMauiHandlers(handlers =>
		{
    		handlers.AddHandler<Microsoft.Maui.Controls.WebView, InspectableWebViewHandler>();
		});
#endif
#if DEBUG
		//builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

