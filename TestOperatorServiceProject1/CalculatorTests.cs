using HungarianCalculator;
using NUnit.Framework;
using static HungarianCalculator.OperatorService;

namespace Tests
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
            Calculator calculator = new Calculator();
        }

        [Test]
        public void Calculate_Check100Sum2Operator_Return102()
        {
            double answer = 102;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100+2"));           
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Sub2Operator_Return98()
        {
            double answer = 98;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100-2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Mul2Operator_Return200()
        {
            double answer = 200;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100*2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Div2Operator_Return50()
        {
            double answer = 50;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100/2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Sum2OperatorWithSpace_Return102()
        {
            double answer = 102;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100 +2"));
            Assert.AreEqual(result, answer);
        }        

        [Test]
        public void Calculate_Check100Sum2Div2Operator_Return101()
        {
            double answer = 101;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100+2/2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Sum2Div2Plus2Operator_Return103()
        {
            double answer = 103;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100+2/2+2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Div2Sum2Div2Operator_Return51()
        {
            double answer = 51;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("100/2+2/2"));
            Assert.AreEqual(result, answer);
        }


    }
}
