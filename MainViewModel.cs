using System.Windows.Input;
using Foundation;

namespace MyMauiApp1;

public class MainViewModel
{
    private string result = "0";
    private double firstValue = 0;
    private string lastOperator = "";

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

                    case "+": case "-": case "*": case "/":
                        lastOperator = arg;
                        StoreResultAsFirstValue();
                        break;

                    case "=":
                        CalculateResult();
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

    private void CalculateResult()
    {
        if (string.IsNullOrEmpty(lastOperator)) return;

        double secondValue = GetResultAsDouble();
        double calculationValue = 0;

        switch (lastOperator)
        {
            case "+":
                calculationValue = (firstValue + secondValue);
                break;
            
            case "-":
                calculationValue = (firstValue - secondValue);
                break;
            
            case "*":
                calculationValue = (firstValue * secondValue);
                break;
            
            case "/":
                if (secondValue != 0) calculationValue = (firstValue / secondValue);
                break;

            default:
                break;
        }

        firstValue = calculationValue;
        Result = calculationValue.ToString();
        lastOperator = "";
    }

    private double GetDoubleFromString(string stringValue)
    {
        double doubleToReturn = 0;

        try
        {
            doubleToReturn = Convert.ToDouble(result);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error - result is of incorrect format to convert to Double");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Error - result is too large to convert to Double (overflow)");
        }

        return doubleToReturn;
    }

    private double GetResultAsDouble()
    {
        return GetDoubleFromString(Result);
    }

    private void StoreResultAsFirstValue()
    {
        firstValue = GetResultAsDouble();
        Result = "0";
    }

    private void Clear()
    {
        Result = "0";
        firstValue = 0;
    }
}