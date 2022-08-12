namespace HackerRankTests;

public class MinMaxTests
{
    [Fact]
    public void Should_calc_min_max()
    {
        var input = new[] { 1, 3, 5, 7, 9 };
        var expectedMin = 1 + 3 + 5 + 7;
        var expectedMax = 3 + 5 + 7 + 9;

        var (min, max) = GetMinMix(input.ToList());
        
        Assert.Equal(expectedMin, min);
        Assert.Equal(expectedMax, max);
    }

    [Fact]
    public void Should_handle_bigger_numbers()
    {
        var input = new[] { 256741038, 623958417, 467905213, 714532089, 938071625 };
        var (min, max) = GetMinMix(input.ToList());
        
        Assert.Equal(2063136757, min);
        Assert.Equal(2744467344, max);
    }

    private (long min, long max) GetMinMix(List<int> input)
    {
        var longInput = input.Select(x => (long)x).ToList();
        longInput.Sort();
        
        return (longInput.Take(4).Sum(), longInput.TakeLast(4).Sum());
    }
}