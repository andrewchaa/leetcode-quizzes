using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace LeetCodeTests
{
    public class StringToIntegerTests
    {
        [Theory]
        [InlineData("42", 42)]
        [InlineData("-42", -42)]
        [InlineData("   -42", -42)]
        [InlineData("4193 with words", 4193)]
        [InlineData("words and 987", 0)]
        public void Should_convert_string_to_integer(string input, int expected)
        {
            var output = MyAtoi(input);
            Assert.Equal(expected, output);
        }

        public int MyAtoi(string s)
        {
            var acc = 0;
            var negative = s.Contains("-");
            var stringNumber = new Regex("[0-9]+")
                .Match(s)
                .Value;
            var chars = stringNumber.Reverse().ToList();
            for (int i = 0; i < chars.Count(); i++)
            {
                acc += int.Parse(chars[i].ToString()) * (int)Math.Pow(10, i);
            }

            return negative ? acc * -1 : acc;
        }
    }
}