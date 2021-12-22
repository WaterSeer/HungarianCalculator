using HungarianCalculator;
using NUnit.Framework;
using static HungarianCalculator.OperatorService;

namespace Tests
{
    public class OperatorServiceTests
    {
        [SetUp]
        public void Setup()
        {          
            
        }

        [Test]
        public void IsOperator_CheckPlus_ReturnTrue()
        {
            char plus = '+';
            var result = plus.isOperator();
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOperator_CheckMinus_ReturnTrue()
        {
            char minus = '-';
            var result = minus.isOperator();
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOperator_CheckMul_ReturnTrue()
        {
            char mul = '*';
            var result = mul.isOperator();
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOperator_CheckDiv_ReturnTrue()
        {
            char div = '*';
            var result = div.isOperator();
            Assert.IsTrue(result);
        }

        [Test]
        public void IsOperator_CheckNumber_ReturnFalse()
        {
            char number = '4';
            var result = number.isOperator();
            Assert.IsFalse(result);
        }

        [Test]
        public void GetPrecedense_CheckMul_ReturnHigh()
        {
            var mul = Operator.Multiplication;
            var result = mul.GetPrecedence();
            Assert.AreEqual(result, Precedense.High);
        }

        [Test]
        public void GetPrecedense_CheckDiv_ReturnHigh()
        {
            var div = Operator.Division;
            var result = div.GetPrecedence();
            Assert.AreEqual(result, Precedense.High);
        }

        [Test]
        public void GetPrecedense_CheckSum_ReturnLow()
        {
            var sum = Operator.Sum;
            var result = sum.GetPrecedence();
            Assert.AreEqual(result, Precedense.Low);
        }

        [Test]
        public void GetPrecedense_CheckSub_ReturnLow()
        {
            var sub = Operator.Subtraction;
            var result = sub.GetPrecedence();
            Assert.AreEqual(result, Precedense.Low);
        }

        [Test]
        public void ToOperator_CheckSum_ReturnTrue()
        {            
            var result = '+'.ToOperator();
            Assert.AreEqual(result, Operator.Sum);
        }

        [Test]
        public void ToOperator_CheckSub_ReturnTrue()
        {
            var result = '-'.ToOperator();
            Assert.AreEqual(result, Operator.Subtraction);
        }

        [Test]
        public void ToOperator_CheckMul_ReturnTrue()
        {
            var result = '*'.ToOperator();
            Assert.AreEqual(result, Operator.Multiplication);
        }

        [Test]
        public void ToOperator_CheckDiv_ReturnTrue()
        {
            var result = '/'.ToOperator();
            Assert.AreEqual(result, Operator.Division);
        }

        [Test]
        public void ToOperator_CheckNumber_ReturnTrue()
        {
            var result = '1'.ToOperator();
            Assert.AreEqual(result, Operator.NotAOperator);
        }
    }
}