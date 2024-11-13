using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Commands
{
    public class HistoryCommand : ICommand
    {
        private readonly Display _display;
        private readonly List<double> _results;
        private Display display;
        private Task<List<double>> results;

        public HistoryCommand(Display display, List<double> results)
        {
            _display = display;
            _results = results;
        }

        public HistoryCommand(Display display, Task<List<double>> results)
        {
            this.display = display;
            this.results = results;
        }

        public bool CanExecute(string input) => input.ToLower() == "history";

        public void Execute(string input)
        {
            _display.DisplayHistory(_results);
        }
    }
}