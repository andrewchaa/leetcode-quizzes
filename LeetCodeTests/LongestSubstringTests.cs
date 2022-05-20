using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCodeTests
{
    public class LongestSubstringTests
    {
        // abcabcbb -> ab, bc, abc, cb
        // pwwkew   -> pw, wke, ke, ew, kew

        [Fact]
        public void Should_handle_first_longest_substring()
        {
            var output = LengthOfLongestSubstring("abcabcbb");
            Assert.Equal(3, output);
        }

        [Fact]
        public void Should_handle_single_char_repeated()
        {
            var output = LengthOfLongestSubstring("bbbbb");
            Assert.Equal(1, output);
        }

        [Fact]
        public void Should_handle_longest_in_the_middle()
        {
            var output = LengthOfLongestSubstring("pwwkew");
            Assert.Equal(3, output);
        }

        [Fact]
        public void Should_handle_longest_in_the_2nd()
        {
            var output = LengthOfLongestSubstring("dvdf");
            Assert.Equal(3, output);
        }

        [Fact]
        public void Should_handle_single_space()
        {
            var output = LengthOfLongestSubstring(" ");
            Assert.Equal(1, output);
        }

        [Fact]
        public void Should_handle_empty_string()
        {
            var output = LengthOfLongestSubstring("");
            Assert.Equal(0, output);
        }

        public int LengthOfLongestSubstring(string input)
        {
            var substrings = GetSubstrings(input);
            return substrings.Any()
                ? substrings.Max(x => x.Length)
                : 0;
        }

        private IEnumerable<string> GetSubstrings(string input)
        {
            var inputChars = input.ToCharArray();
            var subStrings = new List<string>();
            var outputChars = new List<char>();
            while (inputChars.Length > 0)
            {
                for (int i = 0; i < inputChars.Length; i++)
                {
                    if (outputChars.Contains(inputChars[i]))
                    {
                        subStrings.Add(new string(outputChars.ToArray()));
                        outputChars = new List<char>();
                        break;
                    }
                    outputChars.Add(inputChars[i]);
                }

                inputChars = inputChars.Skip(1).ToArray();
            }

            if (outputChars.Count > 0)
            {
                subStrings.Add(new string(outputChars.ToArray()));
            }
            
            return subStrings;
        }
    }
}