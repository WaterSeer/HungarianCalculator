using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HungarianCalculator.Calculator;

namespace HungarianCalculator
{
    public class ArithmeticRegular : IArithmeticRegular
    {
        private Queue<Operator> _operators;
        private Queue<double> _values;
        public Queue<Operator> Operators { get; set; }
        public Queue<double> Values { get; set; }       

        

        private void processOperator(Operator op)
        {
            double a, b;
            if (!_arithmeticRegular.Values.TryDequeue(out a))
            {
                //isError = true;
                return;
            }
            if (!_arithmeticRegular.Values.TryDequeue(out b))
            {
                //isError = true;
                return;
            }
            double result = 0;
            switch (op)
            {
                case Operator.Multiply:
                    result = a * b;
                    break;
                case Operator.Divide:
                    result = a / b;
                    break;
                case Operator.Sum:
                    result = a + b;
                    break;
                case Operator.chan:
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

                if (isOperator(tokens[i]))
                {
                    result.Operators.Enqueue(Calculator.ToOperator(tokens[i]));
                }
            }
            return result;
        }

    
    }
}
