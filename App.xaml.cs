using UIKit;

namespace MyMauiApp1;

public partial class App : Application
{
	private const int WINDOW_WIDTH_PIXELS = 400;
	private const int WINDOW_HEIGHT_PIXELS = 500;

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

		window.MinimumWidth = WINDOW_WIDTH_PIXELS;
		window.MaximumWidth = WINDOW_WIDTH_PIXELS;
		window.MinimumHeight = WINDOW_HEIGHT_PIXELS;
		window.MaximumHeight = WINDOW_HEIGHT_PIXELS;

		window.Height = WINDOW_WIDTH_PIXELS;
		window.Width = WINDOW_HEIGHT_PIXELS;

		Dispatcher.Dispatch(() => {
			window.MinimumWidth = WINDOW_WIDTH_PIXELS;
			window.MaximumWidth = WINDOW_WIDTH_PIXELS;
			window.MinimumHeight = WINDOW_HEIGHT_PIXELS;
			window.MaximumHeight = WINDOW_HEIGHT_PIXELS;
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