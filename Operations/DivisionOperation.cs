using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Operations
{
    public class DivisionOperation : IOperation
    {
        public double Execute(double x, double y)
        {
            if (y == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return x / y;
        }
    }
}
