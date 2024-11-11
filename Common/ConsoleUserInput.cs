using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Common
{
    public class ConsoleUserInput : IUserInput
    {
        public string ReadLine() => Console.ReadLine();
    }

}
