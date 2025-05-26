using FluentAssertions;
using labs.lab6;
using NUnit.Framework;

namespace unit_tests.lab6;

public class ShilAndAssignmentTests
{
    [Test]
    public void TestExampleCase()
    {
        int N = 5, M = 5;
        List<int> A = [2, 3, 4, 6, 10];
        var expected = 5;

        var result = ShilAndAssignment.MaxDivisibleAssignments(N, M, A);
        result.Should().Be(expected);
    }

    [Test]
    public void TestAllOnes()
    {
        int N = 3, M = 3;
        List<int> A = [1, 1, 1];
        var expected = 1;

        var result = ShilAndAssignment.MaxDivisibleAssignments(N, M, A);
        result.Should().Be(expected);
    }

    [Test]
    public void TestNoDivisibles()
    {
        int N = 3, M = 3;
        List<int> A = [7, 11, 13];
        var expected = 1;

        var result = ShilAndAssignment.MaxDivisibleAssignments(N, M, A);
        result.Should().Be(expected);
    }

    [Test]
    public void TestMinimumCase()
    {
        int N = 1, M = 1;
        List<int> A = [4];
        var expected = 1;

        var result = ShilAndAssignment.MaxDivisibleAssignments(N, M, A);
        result.Should().Be(expected);
    }

    [Test]
    public void TestLargeInput()
    {
        int N = 100, M = 100;
        List<int> A = [];
        for (var i = 1; i <= 100; i++)
            A.Add(i * 2);

        var result = ShilAndAssignment.MaxDivisibleAssignments(N, M, A);
        Assert.IsTrue(result >= 50);
    }
}