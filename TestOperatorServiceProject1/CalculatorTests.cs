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

        [Test]
        public void Calculate_Check2Sum3Brackets_Return5()
        {
            double answer = 5;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("(2+3)"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check2Sum3Brakets_Return7()
        {
            double answer = 7;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("(2+3+2)"));
            Assert.AreEqual(result, answer);
        }
        

        [Test]
        public void Calculate_Brakets_1_Return11()
        {
            double answer = 11;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("2+3*(1+2)"));
            Assert.AreEqual(result, answer);
        }
       
        [Test]
        public void Calculate_Brakets_2_Return4()
        {
            double answer = 4;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("(4+4)/2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Brakets_3_Return11()
        {
            double answer = 11;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("1+2*(3+2)"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Brakets_4_Return15()
        {
            double answer = 15;
            Calculator c = new Calculator();
            var result = c.Calculate(c.ProcessInput("2+15/3+4*2"));
            Assert.AreEqual(result, answer);
        }


    }
}
