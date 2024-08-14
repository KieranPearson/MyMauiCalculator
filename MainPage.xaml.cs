using System.Windows.Input;

namespace MyMauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		MainViewModel.EntryChanged += HandleEntryChanged;

		InitializeComponent();
	}

	~MainPage()
	{
		MainViewModel.EntryChanged -= HandleEntryChanged;
	}

    private void HandleEntryChanged(string entry)
    {
        UpdateDisplayText(entry);
    }

    private void UpdateDisplayText(string text)
	{
		DisplayLabel.Text = text;
	}
}