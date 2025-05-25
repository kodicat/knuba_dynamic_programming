using FluentAssertions;
using labs.individual;
using NUnit.Framework;

namespace unit_tests.individual;

public class ParallelCourses3Tests
{
    [Test]
    public void TestBasicScenario1()
    {
        var n = 3;
        int[][] relations = [[1, 3], [2, 3]];
        int[] time = [3, 2, 5];
        var expected = 8;

        var result = ParallelCourses3.MinimumTime(n, relations, time);
        result.Should().Be(expected);
    }

    [Test]
    public void TestBasicScenario2()
    {
        var n = 5;
        int[][] relations = [[1,5],[2,5],[3,5],[3,4],[4,5]];
        int[] time = [1,2,3,4,5];

        var expected = 12;

        var result = ParallelCourses3.MinimumTime(n, relations, time);
        result.Should().Be(expected);
    }
    
    [Test]
    public void Test_NoDependencies()
    {
        var n = 4;
        int[][] relations = [];
        int[] time = [1, 2, 3, 4];

        var expected = 4;

        var result = ParallelCourses3.MinimumTime(n, relations, time);
        result.Should().Be(expected);
    }

    [Test]
    public void Test_ChainDependencies()
    {
        var n = 4;
        int[][] relations = [[1, 2], [2, 3], [3, 4]];
        int[] time = [1, 2, 3, 4];

        var expected = 10;

        var result = ParallelCourses3.MinimumTime(n, relations, time);
        result.Should().Be(expected);
    }

    [Test]
    public void Test_ComplexGraph()
    {
        var n = 5;
        int[][] relations = [[1, 3], [2, 3], [3, 4], [3, 5]];
        int[] time = [1, 2, 3, 4, 5];

        var expected = 10;

        var result = ParallelCourses3.MinimumTime(n, relations, time);
        result.Should().Be(expected);
    }

    [Test]
    public void Test_SingleCourse()
    {
        var n = 1;
        int[][] relations = [];
        int[] time = [10];

        var expected = 10;

        var result = ParallelCourses3.MinimumTime(n, relations, time);
        result.Should().Be(expected);
    }
}