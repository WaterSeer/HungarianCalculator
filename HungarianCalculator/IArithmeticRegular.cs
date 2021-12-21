using System.Collections.Generic;
using static HungarianCalculator.OperatorService;

namespace HungarianCalculator
{
    public interface IArithmeticRegular
    {
        Queue<Operator> Operators { get; set; }
        Queue<double> Values { get; set; }
    }
}