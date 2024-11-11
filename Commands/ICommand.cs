using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Commands
{
    public interface ICommand
    {
        bool CanExecute(string input);
        void Execute(string input);
    }

}
