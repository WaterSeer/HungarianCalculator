using System;

namespace HungarianCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticExpression ae = new ArithmeticExpression();
            Calculator c = new Calculator();
            

            
           

            var a1 = c.ProcessInput("1-10-3/0");
            var b1 = c.Calculate(a1);
            Console.ReadLine();
        }
    }
}
