﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Operations
{
    public class SubtractionOperation : IOperation
    {
        public double Execute(double x, double y) => x - y;
    }
}