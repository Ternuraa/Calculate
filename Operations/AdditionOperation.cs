using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Operations
{
    public class AdditionOperation : IOperation
    {
        public double Execute(double x, double y) => x + y;
    }
}
