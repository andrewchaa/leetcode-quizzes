namespace HackerRankTests;

public class PreparationKitTests
{
    [Fact]
    public void Should_return_ratios_of_positive_and_negative_numbers()
    {
        var input = new int[] { 1, 1, 0, -1, -1 };
        var output = PlusMinus(input);
        
        Assert.Equal(new[] {"0.400000", "0.200000", "0.400000"}, output);
    }

    private string [] PlusMinus(int[] input)
    {
        var count = input.Length * 1m;
        var positiveRatio = input.Count(x => x > 0)/count;
        var negativeRatio = input.Count(x => x < 0)/count;
        var zeroRatio = input.Count(x => x == 0)/count;
        
        return new[] {
            positiveRatio.ToString("F6"), 
            zeroRatio.ToString("F6"), 
            negativeRatio.ToString("F6")
        };
    }
}