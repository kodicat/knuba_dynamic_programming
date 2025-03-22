using FluentAssertions;
using labs.lab4;
using NUnit.Framework;

namespace unit_tests.lab4;

public class MaximumSpanningTreeTests
{
    [Test]
    public void Test1()
    {
        var n = 3;
        int[] balls = [4, 6, 9];

        var result = BuyAnything.MaximumSpanningTree(n, balls);
        result.Should().Be(5);
    }
}
