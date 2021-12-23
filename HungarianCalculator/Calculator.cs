using System.Collections.Generic;
using System.Linq;
using System.Text;
using static HungarianCalculator.OperatorService;

namespace HungarianCalculator
{
    public class Calculator : ICalculator
    {
        public double Calculate(IArithmeticExpression ar)
        {
            double a = 0, b = 0, buffer = double.NaN;
            Operator currentOp = Operator.NotAOperator, bufferOp = Operator.NotAOperator;

            if (!ar.Values.TryDequeue(out a))
                return double.NaN;

            while (ar.Values.TryDequeue(out b) & ar.Operators.TryDequeue(out currentOp))
            {
                if ((ar.Operators.Count() > 0 && currentOp.GetPrecedence() > ar.Operators.Peek().GetPrecedence()) || (ar.Operators.Count() == 0))
                {
                    a = Compute(currentOp, a, b);
                    if (buffer is not double.NaN)
                    {
                        a = Compute(bufferOp, buffer, a);
                        buffer = double.NaN;
                    }
                }
                else
                {
                    //the next operator have increase precedence - need to bufferezed arguments for deferred computation
                    buffer = a;
                    a = b;
                    bufferOp = currentOp;
                }
            }

            if (ar.Operators.Count() == 0 && ar.Values.Count() == 0)
                return a;
            else
                return double.NaN;
        }

        public double Compute(Operator op, double a, double b)
        {
            switch (op)
            {
                case Operator.Multiplication:
                    return a * b;
                case Operator.Division:
                    return a / b;
                case Operator.Sum:
                    return a + b;
                case Operator.Subtraction:
                    return a - b;
                default:
                    return double.NaN;
            }
        }

        public ArithmeticExpression ProcessInput(string ArithmeticString)
        {
            ArithmeticExpression result = new();
            int numberCounter = 0;
            bool isNumber = false;
            double addNumber;
            char[] tokens = ArithmeticString.ToCharArray();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (char.IsDigit(tokens[i]))
                {
                    isNumber = true;
                    numberCounter++;
                }
                else
                {
                    if (isNumber)
                    {
                        double.TryParse(ArithmeticString.Substring(i - numberCounter, numberCounter), out addNumber);
                        result.Values.Enqueue(addNumber);
                        numberCounter = 0;
                        isNumber = false;
                    }
                }

                if (tokens[i].isOperator())
                    result.Operators.Enqueue(tokens[i].ToOperator());

                if (string.IsNullOrWhiteSpace(tokens[i].ToString()))
                    continue;

                if (i == tokens.Length - 1)
                {
                    double.TryParse(ArithmeticString.Substring(i - numberCounter + 1, numberCounter), out addNumber);
                    result.Values.Enqueue(addNumber);
                }
            }
            return result;
        }

        public int[,] FindBrakets(string ArithmeticString)
        {
            Stack<int> curles = new Stack<int>();
            Dictionary<int, int> result = new Dictionary<int, int>();
            

            char[] tokens = ArithmeticString.ToCharArray();
            int[,] r = new int[2, tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i] == '(')
                {
                    result.Add(i, 0);
                    r[0,i]
                    curles.Push(i);
                }
                if (tokens[i] == ')')
                {
                    result[curles.Peek()] = i;
                    curles.Pop();
                }
            }
            if (curles.Count != 0)                
                return null;
            foreach (var item in result)
            {

            }
        }

        public IArithmeticExpression OpenBrakets(string AritmeticsString, Dictionary<int, int> curles)
        {
            Calculator c = new Calculator();
            StringBuilder sb;            
            int key;
            while(curles.Count != 0)
            {
                key = curles.Last().Key;
                sb = new StringBuilder(AritmeticsString, key, curles[key], );
                c.Calculate(c.ProcessInput(sb.ToString()));
                sb = (key != 0 ? new StringBuilder(AritmeticsString, key, curles[key] - key, ))
            }
        }
    }
}
