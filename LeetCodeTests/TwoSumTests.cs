using System;
using Xunit;

namespace LeetCodeTests
{
    public class TwoSumTests
    {
        [Fact]
        public void Should_find_two_numbers_that_sums_the_target()
        {
            var nums = new[] {2, 7, 11, 15};
            var target = 9;

            Assert.Equal(new[] {0, 1}, TwoSum(nums, target));
        }

        private int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length-1; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] {i, j};
                    }
                }
            }

            return new[]{0, 0};
        }
    }
}