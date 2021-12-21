namespace HungarianCalculator
{
    public static class OperatorService
    {
        private static bool isOperator(this char ch)
        {
            return (ch == '+' || ch == '-' || ch == '*' || ch == '/');
        }

        public enum Precedense
        {
            Low,
            High
        }

        public enum Operator
        {
            Multiply,
            Divide,
            Sum,
            chan,
            NotOperator
        }

        private static Precedense getPrecedence(this Operator op)
        {
            if (op == Operator.Multiply || op == Operator.Divide)
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
                    return Operator.chan;
                case '*':
                    return Operator.Multiply;
                case '/':
                    return Operator.Divide;
                default:
                    return Operator.NotOperator;
            }
        }
    }
}
