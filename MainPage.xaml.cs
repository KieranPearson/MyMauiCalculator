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

    private void HandleResultChanged(double result)
    {
        UpdateDisplayText(result.ToString());
    }

    private void UpdateDisplayText(string text)
	{
		DisplayLabel.Text = text;
	}
}