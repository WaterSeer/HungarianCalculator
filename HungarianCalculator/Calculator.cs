using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungarianCalculator
{
    public class Calculator : ICalculator
    {        
        private IArithmeticRegular _arithmeticRegular;

        public Calculator(IArithmeticRegular arithmeticRegular)
        {
            _arithmeticRegular = arithmeticRegular;            
        }

        public double Calculate()
        {
            return double.NaN;
        }

        

    }
}
