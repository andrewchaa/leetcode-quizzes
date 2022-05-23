using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodeTests
{
    public class LongestPalindromicSubstringTests
    {
        [Theory]
        [InlineData("babad", "bab")]
        [InlineData("baabad", "baab")]
        [InlineData("cbbd", "bb")]
        [InlineData("a", "a")]
        [InlineData("abb", "bb")]
        public void Should_get_the_longest_palindromic_substring(string input, string expected)
        {
            Assert.Equal(expected, LongestPalindrome(input));
        }

        public string LongestPalindrome(string s)
        {
            if (s.Length == 1)
            {
                return s;
            }

            var palindrome = string.Empty;
            for (var i = 0; i < s.Length; i++)
            {
                for (var j = s.Length-i; j > 0; j--)
                {
                    var substring = s.Substring(i, j);
                    if (substring.SequenceEqual(substring.Reverse()))
                    {
                        if (j > palindrome.Length)
                            palindrome = substring;
                    }
                }

            }
            return palindrome;
        }

        [Fact]
        public void Test() {
            Assert.Equal(string.Empty, "a".Replace("a".Substring(0, 1), ""));
            Assert.Equal(string.Empty, "aa"
                .Replace("aa".Substring(0, 1), "")
            );
            Assert.Equal("b", "aba".Replace("aba".Substring(0, 1), string.Empty));
            Assert.Equal("", "abba"
                .Replace("abba".Substring(0, 2), string.Empty)
                .Replace(new string("abba".Substring(0, 2).ToCharArray().Reverse().ToArray()), string.Empty)
            );
        }

    }
    
}