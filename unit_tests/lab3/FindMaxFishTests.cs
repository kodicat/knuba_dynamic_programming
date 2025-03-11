using FluentAssertions;
using labs.lab3;
using NUnit.Framework;

namespace unit_tests.lab3;

public class FindMaxFishTests
{
    [Test]
    public void TestBasicScenario()
    {
        int[][] grid =
        [
            [0,2,1,0],
            [4,0,0,3],
            [1,0,0,4],
            [0,3,2,0]
        ];

        var result = FishInGrid.FindMaxFish(grid);
        result.Should().Be(7);
    }

    [Test]
    public void TestAlmostEmptyGrid()
    {
        int[][] grid =
        [
            [1,0,0,0],
            [0,0,0,0],
            [0,0,0,0],
            [0,0,0,1]
        ];

        var result = FishInGrid.FindMaxFish(grid);
        result.Should().Be(1);
    }

    [Test]
    public void TestRiverGrid()
    {
        int[][] grid = [[6,1,10]];

        var result = FishInGrid.FindMaxFish(grid);
        result.Should().Be(17);
    }

    [Test]
    public void TestBiggerRiverGrid()
    {
        int[][] grid = [[3,10,5,8]];

        var result = FishInGrid.FindMaxFish(grid);
        result.Should().Be(26);
    }
}