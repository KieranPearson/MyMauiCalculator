using System.Windows.Input;
using Foundation;

namespace MyMauiApp1;

public class MainViewModel
{
    private string result = "0";
    private double firstValue = 0;

    public delegate void ResultChangedHandler(string result);
    public static event ResultChangedHandler? ResultChanged;

    public ICommand ClearCommand { private set; get; }
    public ICommand OperationCommand { private set; get; }
    public ICommand DigitCommand { private set; get; }

    public MainViewModel()
    {
        ClearCommand = new Command(
            execute: () =>
            {
                Clear();
            });

        OperationCommand = new Command<string>(
            execute: (string arg) =>
            {
                switch (arg)
                {
                    case ".":
                        if (!Result.Contains(arg)) Result = Result + arg;
                        break;

                    case "+":
                        StoreResultAsFirstValue();
                        break;

                    default:
                        Console.WriteLine("Error - Unknown OperationCommand arg type!");
                        Clear();
                        break;
                }
            });

        DigitCommand = new Command<string>(
            execute: (string arg) =>
            {
                if (Result.Equals("0"))
                {
                    Result = arg;
                }
                else
                {
                    Result = Result + arg;
                }
            });
    }

    public string Result
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

    private void StoreResultAsFirstValue()
    {
        try
        {
            firstValue = Convert.ToDouble(result);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error - result is of incorrect format to convert to Double");
            Clear();
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error - result is too large to convert to Double (overflow)");
            Clear();
        }

        Result = "0";
    }

    private void Clear()
    {
        Result = "0";
        firstValue = 0;
    }
}