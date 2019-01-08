using Xunit;
using System.Linq;

namespace Calculator.Console.Tests
{
    public class StringExtensionTests
    {
        [Theory]
        [InlineData("3", "3", 1)]
        [InlineData("3+3", "3+3", 3)]
        [InlineData("(3 + 3)", "(3+3)", 5)]
        [InlineData(" (3 + 3 )", "(3+3)", 5)]
        public void GetNextComponent(string value, string expected, int numComponents)
        {
            var result = value.GetNextComponent().ToList();

            Assert.Equal(expected, string.Join(string.Empty, result));             
            Assert.Equal(result.Count(), numComponents);
        }

    }
}
