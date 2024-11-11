using Calculate.Loggers;
using Calculate.Operations;

namespace Calculate.Common
{
    public class GenericMath
    {
        private readonly Dictionary<string, IOperation> operations = new()
        {
            { "+", new AdditionOperation() },
            { "-", new SubtractionOperation() },
            { "*", new MultiplicationOperation() },
            { "/", new DivisionOperation() }
        };

        public double PerformOperation(double currentResult, double nextOperand, string operation)
        {
            if (operations.TryGetValue(operation, out var operationInstance))
            {
                return operationInstance.Execute(currentResult, nextOperand);
            }
            throw new InvalidOperationException("Operation not supported.");
        }
    }
}
