using System.Collections.Generic;
using static HungarianCalculator.OperatorService;

namespace HungarianCalculator
{
    public interface IArithmeticExpression
    {
        Queue<Operator> Operators { get; set; }
        Queue<double> Values { get; set; }
        //bool CheckExpression
    }
}