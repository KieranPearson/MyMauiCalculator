using UIKit;

namespace MyMauiApp1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

	#if WINDOWS
		MainPage = new AppShell();
	#endif
	}

#if MACCATALYST
    protected override Window CreateWindow(IActivationState? activationState)
    {
		var window = new Window(new AppShell());

		window.HandlerChanged += WindowHandlerChanged;
		var rootPage = new MainPage();
		window.Page = rootPage;

		int windowWidthPixels = WindowProperties.GetWindowWidthPixels();
		int windowHeightPixels = WindowProperties.GetWindowHeightPixels();

		window.MinimumWidth = windowWidthPixels;
		window.MaximumWidth = windowWidthPixels;
		window.MinimumHeight = windowHeightPixels;
		window.MaximumHeight = windowHeightPixels;

		Dispatcher.Dispatch(() => {
			window.MinimumWidth = windowWidthPixels;
			window.MaximumWidth = windowWidthPixels;
			window.MinimumHeight = windowHeightPixels;
			window.MaximumHeight = windowHeightPixels;
		});

        return window;
    }


	private void WindowHandlerChanged(object sender, EventArgs e)
	{
		var win = sender as Microsoft.Maui.Controls.Window;
		try
		{
			var uiWin = win.Handler.PlatformView as UIWindow;

			if (uiWin != null)
			{
				uiWin.WindowScene.Titlebar.TitleVisibility = UITitlebarTitleVisibility.Hidden;
			}
		}
		catch (NullReferenceException ex)
		{
			Console.WriteLine("Error - UIWindow was null");
		}
	}
#endif
}