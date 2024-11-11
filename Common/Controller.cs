using Calculate.Commands;
using Calculate.Loggers;
using Calculate.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Common
{
    public class Controller
    {
        private readonly List<ICommand> _commands;
        private readonly ILogger _logger;
        private readonly IUserInput _userInput;

        public Controller(List<ICommand> commands, ILogger logger, IUserInput userInput)
        {
            _commands = commands;
            _logger = logger;
            _userInput = userInput;
        }

        public void Run()
        {
            _logger.Log("Welcome to the Calculator!");
            _logger.Log("Instructions:");
            _logger.Log("1. Enter a number to input an operand.");
            _logger.Log("2. Enter an operation (+, -, *, /) to perform a calculation.");
            _logger.Log("3. Enter the result number (#1) to use a previous result.");
            _logger.Log("4. Type 'exit' to quit the program.");
            _logger.Log("5. Type 'history' to view the history of operations.");

            while (true)
            {
                _logger.Log("> ");
                string input = _userInput.ReadLine();

                if (input == "exit")
                    break;

                var command = _commands.Find(c => c.CanExecute(input));
                if (command != null)
                {
                    command.Execute(input);
                }
                else
                {
                    _logger.Log("Incorrect input, try again!");
                }
            }
        }
    }
}