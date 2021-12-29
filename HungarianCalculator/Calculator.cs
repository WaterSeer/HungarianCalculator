using System.Collections.Generic;
using System.Linq;
using static HungarianCalculator.OperatorService;

namespace HungarianCalculator
{
    public class Calculator : ICalculator
    {
        public double Calculate(IArithmeticExpression arithmeticExpression)
        {
            if (arithmeticExpression is null)
                return double.NaN;

            if (arithmeticExpression.Values.Count != arithmeticExpression.Operators.Count + 1)
                return double.NaN;

            double valueInBuffer = double.NaN;
            Operator currentOperator = Operator.NotAOperator;
            Operator bufferInOperator = Operator.NotAOperator;
            double firstValue, secondValue;
            if (!arithmeticExpression.Values.TryDequeue(out firstValue))
                return double.NaN;
            while (arithmeticExpression.Values.TryDequeue(out secondValue) & arithmeticExpression.Operators.TryDequeue(out currentOperator))
            {
                if ((arithmeticExpression.Operators.Count() > 0 && currentOperator.GetPrecedence() > arithmeticExpression.Operators.Peek().GetPrecedence()) || (arithmeticExpression.Operators.Count() == 0))
                {
                    firstValue = Compute(currentOperator, firstValue, secondValue);
                    if (valueInBuffer is not double.NaN)
                    {
                        firstValue = Compute(bufferInOperator, valueInBuffer, firstValue);
                        valueInBuffer = double.NaN;
                    }
                }
                else
                {
                    //the next operator have increase precedence - need to bufferezed arguments for deferred computation
                    valueInBuffer = firstValue;
                    firstValue = secondValue;
                    bufferInOperator = currentOperator;
                }
            }

            if (arithmeticExpression.Operators.Count() == 0 && arithmeticExpression.Values.Count() == 0)
                return firstValue;
            else
                return double.NaN;
        }

        public double Compute(Operator operation, double a, double b)
        {
            switch (operation)
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

        public ArithmeticExpression GetArithmeticExpression(string InputString, bool isUseBrackets = true)
        {
            if (InputString is null)
                return null;

            ArithmeticExpression result = new();
            Stack<char> bracketsStack = new Stack<char>();
            int digitNumber = 0;
            bool isNumber = false;
            double numberInString;
            char[] inputStringChars = InputString.ToCharArray();
            for (int i = 0; i < inputStringChars.Length; i++)
            {
                if (char.IsDigit(inputStringChars[i]))
                {
                    isNumber = true;
                    digitNumber++;
                    if (i == inputStringChars.Length - 1)
                    {
                        double.TryParse(InputString.Substring(i - digitNumber + 1, digitNumber), out numberInString);
                        result.Values.Enqueue(numberInString);
                    }
                    continue;
                }
                else
                {
                    if (isNumber)
                    {
                        double.TryParse(InputString.Substring(i - digitNumber, digitNumber), out numberInString);
                        result.Values.Enqueue(numberInString);
                        digitNumber = 0;
                        isNumber = false;
                    }
                }

                if (inputStringChars[i] == '(' && !isUseBrackets)
                    return null;
                else if (inputStringChars[i] == '(' && isUseBrackets)
                {
                    string substringAfterBrackets = InputString.Substring(i + 1, inputStringChars.Length - i - 1);
                    result.Values.Enqueue(Calculate(GetArithmeticExpression(substringAfterBrackets)));

                    bracketsStack.Push('(');
                    for (int j = 0; j < substringAfterBrackets.Length; j++)
                    {
                        if (bracketsStack.Count == 0)
                        {
                            break;
                        }
                        if (substringAfterBrackets[j] == '(')
                            bracketsStack.Push('(');
                        if (substringAfterBrackets[j] == ')')
                        {
                            bracketsStack.Pop();
                            if (bracketsStack.Count == 0)
                            {
                                i = i + j + 1;
                                break;
                            }
                        }
                    }
                    continue;
                }

                if (char.IsLetter(inputStringChars[i]))
                    continue;

                if (inputStringChars[i].isOperator())
                {
                    result.Operators.Enqueue(inputStringChars[i].ToOperator());
                    continue;
                }

                if (string.IsNullOrWhiteSpace(inputStringChars[i].ToString()))
                    continue;

                if (inputStringChars[i] == ')' && !isUseBrackets)
                {
                    return null;
                }
                else if (inputStringChars[i] == ')')
                    return result;

                if (i == inputStringChars.Length - 1)
                {
                    double.TryParse(InputString.Substring(i - digitNumber + 1, digitNumber), out numberInString);
                    result.Values.Enqueue(numberInString);
                }

                return null;
            }
            return result;
        }
    }
}
