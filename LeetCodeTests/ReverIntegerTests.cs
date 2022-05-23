using System;
using System.Linq;
using Xunit;

namespace LeetCodeTests
{
    public class ReverIntegerTests
    {
        [Theory]
        [InlineData(123, 321)]
        [InlineData(-123, -321)]
        [InlineData(1534236469, 0)]
        [InlineData(-2147483648, 0)]
        public void Should_reverse_integers(int input, int expected)
        {
            var output = Reverse(input);
            Assert.Equal(expected, output);
        }

        public int Reverse(int x)
        {
            try
            {
                return x > 0
                    ? int.Parse(x.ToString().Reverse().ToArray())
                    : int.Parse((x * -1).ToString().Reverse().ToArray()) * -1;

            }
            catch (Exception e) 
                when (e is OverflowException || e is FormatException)
            {
                return 0;
            }
        }
    }
}