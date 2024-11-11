using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Commands
{
    public class ExitCommand : ICommand
    {
        public bool CanExecute(string input) => input.ToLower() == "exit";

        public void Execute(string input)
        {
            Environment.Exit(0);
        }
    }
}
