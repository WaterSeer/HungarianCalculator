using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HungarianCalculator.OperatorService;

namespace HungarianCalculator
{
    public class Calculator : ICalculator
    {    
        public double Calculate(IArithmeticRegular arithmeticRegular)
        {
            return double.NaN;
        }

        private void processOperator(Operator op)
        {
            double a = 0, b = 0;
            //if (!arithmeticRegular.Values.TryDequeue(out a))
            //{
            //    //isError = true;
            //    return;
            //}
            //if (!arithmeticRegular.Values.TryDequeue(out b))
            //{
            //    //isError = true;
            //    return;
            //}
            double result = 0;
            switch (op)
            {
                case Operator.Multiplication:
                    result = a * b;
                    break;
                case Operator.Division:
                    result = a / b;
                    break;
                case Operator.Sum:
                    result = a + b;
                    break;
                case Operator.Subtraction:
                    result = a - b;
                    break;
                default:
                    break;
            }
        }

        public ArithmeticRegular ProcessInput(string ArithmeticStringutString)
        {
            ArithmeticRegular result = new();
            int numberCounter = 0;
            bool isNumber = false;
            double addNumber;
            char[] tokens = ArithmeticStringutString.ToCharArray();
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
                        double.TryParse(ArithmeticStringutString.Substring(i - numberCounter, numberCounter), out addNumber);
                        result.Values.Enqueue(addNumber);
                    }
                    isNumber = false;
                }

                if (string.IsNullOrWhiteSpace(tokens[i].ToString()))
                    continue;

                //if (isOperator(tokens[i]))
                //{
                //    result.Operators.Enqueue(Calculator.ToOperator(tokens[i]));
                //}
            }
            return result;
        }
    }
}
