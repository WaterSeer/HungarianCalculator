namespace HungarianCalculator
{
    public static class OperatorService
    {
        public enum Operator
        {
            NotAOperator,
            Multiplication,
            Division,
            Sum,
            Subtraction
        }

        public enum Precedense
        {
            Low,
            High
        }

        public static bool isOperator(this char ch)
        {
            return (ch == '+' || ch == '-' || ch == '*' || ch == '/');
        }

        public static Precedense GetPrecedence(this Operator op)
        {
            if (op is Operator.Multiplication || op is Operator.Division)
                return Precedense.High;
            else
                return Precedense.Low;
        }

        public static Operator ToOperator(this char ch)
        {
            switch (ch)
            {
                case '+':
                    return Operator.Sum;
                case '-':
                    return Operator.Subtraction;
                case '*':
                    return Operator.Multiplication;
                case '/':
                    return Operator.Division;
                default:
                    return Operator.NotAOperator;
            }
        }
    }
}
