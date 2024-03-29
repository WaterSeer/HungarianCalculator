﻿using HungarianCalculator;
using NUnit.Framework;

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
        public void Calculate_Null_ReturnNaN()
        {            
            double answer = double.NaN;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression(null));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Letter_ReturnNaN()
        {
            double answer = double.NaN;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("D"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_checkUseBraketsBit_ReturnNaN()
        {
            double answer = double.NaN;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("1+(2+5))", false));
            Assert.AreEqual(result, answer);
        }


        [Test]
        public void Calculate_Check100Sum2Operator_Return102()
        {
            double answer = 102;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100+2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Sub2Operator_Return98()
        {
            double answer = 98;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100-2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Mul2Operator_Return200()
        {
            double answer = 200;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100*2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Div2Operator_Return50()
        {
            double answer = 50;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100/2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Sum2OperatorWithSpace_Return102()
        {
            double answer = 102;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100 +2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Sum2Div2Operator_Return101()
        {
            double answer = 101;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100+2/2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Sum2Div2Plus2Operator_Return103()
        {
            double answer = 103;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100+2/2+2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check100Div2Sum2Div2Operator_Return51()
        {
            double answer = 51;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("100/2+2/2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check2Sum3Brackets_Return5()
        {
            double answer = 5;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("(2+3)"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Check2Sum3Brakets_Return7()
        {
            double answer = 7;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("(2+3+2)"));
            Assert.AreEqual(result, answer);
        }


        [Test]
        public void Calculate_Brakets_1_Return11()
        {
            double answer = 11;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("2+3*(1+2)"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Brakets_2_Return4()
        {
            double answer = 4;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("(4+4)/2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Brakets_3_Return11()
        {
            double answer = 11;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("1+2*(3+2)"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Brakets_4_Return15()
        {
            double answer = 15;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("2+15/3+4*2"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Brakets_5_Return24()
        {
            double answer = 24;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("4+(4+(4+4)+4)+4"));
            Assert.AreEqual(result, answer);
        }

        [Test]
        public void Calculate_Brakets_6_Return24()
        {
            double answer = 24;
            Calculator calculator = new Calculator();
            var result = calculator.Calculate(calculator.GetArithmeticExpression("(4+(4+(4+4)+4)+4)"));
            Assert.AreEqual(result, answer);
        }
    }
}
