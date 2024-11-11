using Calculate.Common;
using Calculate.Loggers;

public class Performer
{
    private readonly ILogger _logger;
    private readonly GenericMath _genericMath;

    public Performer(ILogger logger, GenericMath genericMath)
    {
        _logger = logger;
        _genericMath = genericMath;
    }

    public void Perform(ref double currentResult, string operation, List<double> results)
    {
        if (results.Count == 0)
        {
            _logger.Log("No previous results to operate on.");
            return;
        }

        double operand = currentResult;
        _logger.Log("Enter the next operand: ");
        var input = Console.ReadLine();
        if (input.Length >= 9)
        {
            _logger.Log("Incorrect input, string must be less or equal than 9 symbols");
            return;
        }
        else if (double.TryParse(input, out double nextOperand))
        {
            currentResult = _genericMath.PerformOperation(operand, nextOperand, operation);
        }
        else
        {
            _logger.Log("Invalid operand. Please try again.");
            return;
        }
    }
}

