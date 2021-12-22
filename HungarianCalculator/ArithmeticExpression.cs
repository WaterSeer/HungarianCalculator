using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HungarianCalculator.Calculator;
using static HungarianCalculator.OperatorService;

namespace HungarianCalculator
{
    public class ArithmeticExpression : IArithmeticExpression
    {        
        public Queue<Operator> Operators { get; set; }
        public Queue<double> Values { get; set; }

        public ArithmeticExpression()
        {
            Operators = new Queue<Operator>();
            Values = new Queue<double>();
        }
    }
}
