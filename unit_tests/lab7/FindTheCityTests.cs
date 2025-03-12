using FluentAssertions;
using labs.lab7;
using NUnit.Framework;

namespace unit_tests.lab7;

public class FindTheCityTests
{
    [Test]
    public void Test1()
    {
        var n = 4;
        int[][] edges =
        [
            [0,1,3],
            [1,2,1],
            [1,3,4],
            [2,3,1]
        ];
        var distanceThreshold = 4;

        var result = SmallestPath.FindTheCity(n, edges, distanceThreshold);
        result.Should().Be(3);
    }

    [Test]
    public void Test2()
    {
        var n = 5;
        int[][] edges =
        [
            [0,1,2],
            [0,4,8],
            [1,2,3],
            [1,4,2],
            [2,3,1],
            [3,4,1]
        ];
        var distanceThreshold = 2;

        var result = SmallestPath.FindTheCity(n, edges, distanceThreshold);
        result.Should().Be(0);
    }
}
