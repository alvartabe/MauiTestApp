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
			builder.Services.AddSingleton<LoginViewModel>();
			builder.Services.AddSingleton<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
