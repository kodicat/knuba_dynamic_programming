using FluentAssertions;
using labs.lab5;
using NUnit.Framework;

namespace unit_tests.lab5;

public class FindCircleNumTests
{
    [Test]
    public void TestTwoConnectedCities()
    {
        int[][] isConnected =
        [
            [1,1,0],
            [1,1,0],
            [0,0,1]
        ];

        var result = NumberOfProvinces.FindCircleNum(isConnected);
        result.Should().Be(2);
    }

    [Test]
    public void TestNoConnectedCities()
    {
        int[][] isConnected =
        [
            [1,0,0],
            [0,1,0],
            [0,0,1]
        ];

        var result = NumberOfProvinces.FindCircleNum(isConnected);
        result.Should().Be(3);
    }
}