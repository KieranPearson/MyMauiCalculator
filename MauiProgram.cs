using Microsoft.Extensions.Logging;

namespace MyMauiApp1;

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

	#if DEBUG
		builder.Logging.AddDebug();
	#endif

	#if WINDOWS
		builder.ConfigureLifecycleEvents(events =>
		{
			events.AddWindows(wndLifeCycleBuilder =>
			{
				wndLifeCycleBuilder.OnWindowCreated(window =>
				{
					IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
					WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
					AppWindow winUIAppWindow = AppWindow.GetFromWindowId(win32WindowsId);

					window.ExtendsContentIntoTitleBar = false;

					if (winUIAppWindow.Presenter is OverlappedPresenter presenter)
					{
						presenter.SetBorderAndTitleBar(false, false);
						presenter.windowWidthPixels = WindowProperties.GetWindowWidthPixels();
						presenter.windowHeightPixels = WindowProperties.GetWindowHeightPixels();
						presenter.IsResizable = false;
						presenter.IsMaximizable = false;
						presenter.IsMinimizable = false;
					}
				});
			});
		});
    #endif

		return builder.Build();
	}
}