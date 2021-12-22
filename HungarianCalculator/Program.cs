using System;

namespace HungarianCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticExpression ae = new ArithmeticExpression();
            ae.Values.Enqueue(123);

            
            Calculator c = new Calculator();
            //var a =c.ProcessInput("134 +2");
           // var b = c.Calculate(a);

            var a1 = c.ProcessInput("134 +2 /2");
            var b1 = c.Calculate(a1);
            Console.ReadLine();
        }
    }
}
