using System.Collections.Generic;
using System.Linq;
using static HungarianCalculator.OperatorService;

namespace HungarianCalculator
{
    public class Calculator : ICalculator
    {
        public double Calculate(IArithmeticExpression ar)
        {
            if (ar.Values.Count != ar.Operators.Count + 1)
                return double.NaN;
            
            double buffer = double.NaN;
            Operator currentOp = Operator.NotAOperator, bufferOp = Operator.NotAOperator;
            double a, b;
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
            Stack<char> brackets = new Stack<char>();
            int numberCounter = 0;
            bool isNumber = false;
            double addNumber;
            char[] tokens = ArithmeticString.ToCharArray();
            for (int i = 0; i < tokens.Length; i++)
            {
                var ab = tokens[i];
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

                if (tokens[i] == '(')
                {
                    var str = ArithmeticString.Substring(i + 1, tokens.Length - i - 1);
                    var pi = ProcessInput(str);
                    var numberInBrackets = Calculate(pi);
                    result.Values.Enqueue(numberInBrackets);

                    brackets.Push('(');
                    for (int j = 0; j < str.Length; j++)
                    {
                        if (brackets.Count == 0)
                        {
                            break;
                        }
                        if (str[j] == '(')
                            brackets.Push('(');
                        if (str[j] == ')')
                        {
                            brackets.Pop();
                            if (brackets.Count == 0)
                            {
                                i = i + j + 1;
                                break;
                            }
                        }
                    }
                    continue;
                    ////TODO :неверное количество скобок
                }                

                if (tokens[i].isOperator())
                    result.Operators.Enqueue(tokens[i].ToOperator());

                if (string.IsNullOrWhiteSpace(tokens[i].ToString()))
                    continue;

                if (tokens[i] == ')')
                {
                    return result;
                }

                if (i == tokens.Length - 1)
                {
                    double.TryParse(ArithmeticString.Substring(i - numberCounter + 1, numberCounter), out addNumber);
                    result.Values.Enqueue(addNumber);
                }
            }
            return result;
        }
    }
}
