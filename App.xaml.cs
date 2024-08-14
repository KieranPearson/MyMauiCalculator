
namespace MyMauiApp1;

public partial class App : Application
{
	private const int WINDOW_WIDTH_PIXELS = 400;
	private const int WINDOW_HEIGHT_PIXELS = 500;

	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState? activationState)
    {
		var window = base.CreateWindow(activationState);

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
}