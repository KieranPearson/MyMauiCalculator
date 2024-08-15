namespace MyMauiApp1;

public static class WindowProperties
{
    private const int WINDOW_WIDTH_PIXELS = 400;
	private const int WINDOW_HEIGHT_PIXELS = 500;

    public static int GetWindowWidthPixels()
    {
        return WINDOW_WIDTH_PIXELS;
    }

    public static int GetWindowHeightPixels()
    {
        return WINDOW_HEIGHT_PIXELS;
    }
}