using Calculate.Loggers;
using Calculate.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Commands
{
    public class NumberCommand : ICommand
    {
        private readonly IStorage _storage;
        private readonly ILogger _logger;
        private readonly List<double> _results;

        public NumberCommand(IStorage storage, ILogger logger, List<double> results)
        {
            _storage = storage;
            _logger = logger;
            _results = results;
        }

        public bool CanExecute(string input) => double.TryParse(input, out _);

        public void Execute(string input)
        {
            if (double.TryParse(input, out double number))
            {
                _results.Add(number);
                _storage.Save(number);
                _logger.Log($"[# {_results.Count}] = {number}");
            }
        }
    }
}
