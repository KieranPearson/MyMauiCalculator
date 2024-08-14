namespace MyMauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		MainViewModel.ResultChanged += HandleResultChanged;

		InitializeComponent();
	}

	~MainPage()
	{
		MainViewModel.ResultChanged -= HandleResultChanged;
	}

    private void HandleResultChanged(string result)
    {
        UpdateDisplayText(result);
    }

    private void UpdateDisplayText(string text)
	{
		DisplayLabel.Text = text;
	}
}