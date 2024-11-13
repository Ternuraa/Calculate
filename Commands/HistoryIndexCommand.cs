using Calculate.Loggers;
using Calculate.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Commands
{
    public class HistoryIndexCommand : ICommand
    {
        private readonly IStorage _storage;
        private readonly ILogger _logger;
        private readonly List<double> _results;


        public HistoryIndexCommand(IStorage storage, ILogger logger, List<double> results)
        {
            _storage = storage;
            _logger = logger;
            _results = results;
        }


        public bool CanExecute(string input) => input.StartsWith("#");

        public void Execute(string input)
        {
            int index = int.Parse(input.Substring(1)) - 1;
            if (index >= 0 && index < _results.Count)
            {
                var number = _results[index];
                _logger.Log("Using previous result: " + number);
                _results.Add(number);
                _storage.Save(number);
                
            }
            else
            {
                _logger.Log("Invalid result number.");
            }
        }
    }
}