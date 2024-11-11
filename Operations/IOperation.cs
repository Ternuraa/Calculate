using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Operations
{
    public interface IOperation
    {
        double Execute(double x, double y);
    }

}
