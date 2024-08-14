using System.ComponentModel;
using System.Windows.Input;

namespace MyMauiApp1;

public class MainViewModel : INotifyPropertyChanged
{
    private string entry = "0";

	public event PropertyChangedEventHandler PropertyChanged;

    public delegate void EntryChangedHandler(string entry);
    public static event EntryChangedHandler? EntryChanged;

    public MainViewModel()
    {
        ClearCommand = new Command(
            execute: () =>
            {
                Entry = "CLEAR";
            });

        OperationCommand = new Command(
            execute: () =>
            {
                Entry = "OPERATOR";
            });

        DigitCommand = new Command(
            execute: () =>
            {
                Entry = "DIGIT";
            });
    }

    public string Entry
    {
        private set 
        { 
            entry = value; 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Entry"));
            EntryChanged?.Invoke(entry);
        }
        get
        {
            return entry;
        }
    }

    public ICommand ClearCommand { private set; get; }
    public ICommand OperationCommand { private set; get; }
    public ICommand DigitCommand { private set; get; }
}