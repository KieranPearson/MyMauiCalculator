using System.Windows.Input;

namespace MyMauiApp1;

public class MainViewModel
{
    private double result = 0;

    public delegate void ResultChangedHandler(double result);
    public static event ResultChangedHandler? ResultChanged;

    public MainViewModel()
    {
        ClearCommand = new Command(
            execute: () =>
            {
                Result = 0;
            });

        OperationCommand = new Command(
            execute: () =>
            {
                Result = 1;
            });

        DigitCommand = new Command(
            execute: () =>
            {
                Result = 2;
            });
    }

    public double Result
    {
        private set 
        { 
            result = value; 
            ResultChanged?.Invoke(result);
        }
        get
        {
            return result;
        }
    }

    public ICommand ClearCommand { private set; get; }
    public ICommand OperationCommand { private set; get; }
    public ICommand DigitCommand { private set; get; }
}