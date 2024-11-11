using Calculate.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Commands
{
    public class MathOperationCommand : ICommand
    {
        private readonly Performer _performer;
        private readonly ILogger _logger;
        private readonly List<double> _results;
        private Performer performer;
        private ILogger logger;
        private Task<List<double>> results;

        public MathOperationCommand(Performer performer, ILogger logger, List<double> results)
        {
            _performer = performer;
            _logger = logger;
            _results = results;
        }


        public bool CanExecute(string input) => input == "+" || input == "-" || input == "*" || input == "/";

        public void Execute(string input)
        {
            if (_results == null ||_results.Count == 0)
            {
                _logger.Log("History is empty, input number first");
                return;
            }

            double currentResult = _results[_results.Count - 1];
            bool success = false;
            while (!success)
            {
                try
                {
                    _performer.Perform(ref currentResult, input, _results);
                    success = true;
                }
                catch
                {
                    _logger.Log("Cannot divide by zero, type another number");
                }
            }
            _results.Add(currentResult);
            _logger.Log($"[# {_results.Count}] = {currentResult}");
        }
    }
}
