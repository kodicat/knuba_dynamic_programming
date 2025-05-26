using FluentAssertions;
using labs.lab4;
using NUnit.Framework;

namespace unit_tests.lab4;

[TestFixture]
public class ThreeThingsTests
{
    [Test]
    public void ShouldReturnCorrectMaxDestroyedEdges_WhenFullyConnectable()
    {
        var n = 4;
        var m = 5;
        var edges = new List<Tuple<int, int, int>>
        {
            Tuple.Create(1, 2, 3),
            Tuple.Create(2, 3, 1),
            Tuple.Create(3, 4, 2),
            Tuple.Create(1, 3, 3),
            Tuple.Create(2, 4, 3)
        };

        var result = ThreeThings.Solve(n, m, edges);

        result.Should().Be(2);
    }

    [Test]
    public void ShouldReturnMinusOne_WhenMenCannotConnect()
    {
        var n = 3;
        var m = 2;
        var edges = new List<Tuple<int, int, int>>
        {
            Tuple.Create(1, 2, 2),
            Tuple.Create(2, 3, 2)
        };

        var result = ThreeThings.Solve(n, m, edges);

        result.Should().Be(-1);
    }

    [Test]
    public void ShouldReturnMinusOne_WhenWomenCannotConnect()
    {
        var n = 3;
        var m = 2;
        var edges = new List<Tuple<int, int, int>>
        {
            Tuple.Create(1, 2, 1),
            Tuple.Create(2, 3, 1)
        };

        var result = ThreeThings.Solve(n, m, edges);

        result.Should().Be(-1);
    }

    [Test]
    public void ShouldReturnZero_WhenAllEdgesAreNeeded()
    {
        var n = 3;
        var m = 3;
        var edges = new List<Tuple<int, int, int>>
        {
            Tuple.Create(1, 2, 3),
            Tuple.Create(2, 3, 1),
            Tuple.Create(1, 3, 2)
        };

        var result = ThreeThings.Solve(n, m, edges);

        result.Should().Be(0);
    }

    [Test]
    public void ShouldReturnCorrect_WhenRedundantSharedRoadsExist()
    {
        var n = 4;
        var m = 6;
        var edges = new List<Tuple<int, int, int>>
        {
            Tuple.Create(1, 2, 3),
            Tuple.Create(2, 3, 3),
            Tuple.Create(3, 4, 3),
            Tuple.Create(4, 1, 3),
            Tuple.Create(1, 3, 1),
            Tuple.Create(2, 4, 2)
        };

        var result = ThreeThings.Solve(n, m, edges);

        result.Should().Be(3);
    }
}
