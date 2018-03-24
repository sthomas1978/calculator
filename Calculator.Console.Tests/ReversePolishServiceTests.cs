using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Calculator.Console.Tests
{
    public class ReversePolishServiceTests
    {
        private readonly ReversePolishService _service;

        public ReversePolishServiceTests()
        {
            _service = new ReversePolishService();
        }

        [Fact]
        public void ConvertFromInfix_SimpleExpression_ReturnsCorrectResult()
        { 
            var result = _service.ConvertFromInfix("5 + 7");

            Assert.Equal("5 7 +", result);
        }

        [Fact]
        public void ConvertFromInfix_PrescedenceOrdering_ReturnsCorrectResult()
        {
            var result = _service.ConvertFromInfix("5 * 8 - 7 * 3");

            Assert.Equal("5 8 * 7 3 * -", result);
        }

        [Fact]
        public void ConvertFromInFix_ExpressionHasBrackets_ReturnsCorrectResult()
        {
            var result = _service.ConvertFromInfix("5 * ( 2 + 7 )");

            Assert.Equal("5 2 7 + *", result);
        }

        [Fact]
        public void ConvertFromInfix_ComplexExpression_ReturnsCorrectResult()
        {
            var result = _service.ConvertFromInfix("2 * 3 ^ 4 / 5 - 7 * 8 ^ ( 6 - 9 )");

            Assert.Equal("2 3 4 ^ * 5 / 7 8 6 9 - ^ * -", result);
        }

        [Fact]
        public void EvaluateExpression_SimpleExpression_ReturnsCorrectResult()
        {
            var result = _service.EvaluateExpression("5 7 +");

            Assert.Equal(12, result);
        }

        [Fact]
        public void EvaluateExpression_PrescedenceOrdering_ReturnsCorrectResult()
        {
            var result = _service.EvaluateExpression("5 8 * 7 3 * -");

            Assert.Equal(19, result);
        }

        [Fact]
        public void EvaluateExpression_ComplexExpression_ReturnsCorrectResult()
        {
            var result = _service.EvaluateExpression("2 3 4 ^ * 6 / 7 8 9 6 - ^ * -");

            Assert.Equal(-3557, result);
        }
    }
}
