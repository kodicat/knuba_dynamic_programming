using FluentAssertions;
using FluentAssertions.Execution;
using labs.lab4.Utils;
using NUnit.Framework;

namespace unit_tests.lab4.Utils;

public class GetDivisorsCountTests
{
    [Test]
    public void Test1()
    {
        List<int> factors = [2, 2, 2, 3, 3, 3, 5, 5, 7];
        var numberOfDivisors = DivisibilityUtils.GetDivisorsCount(factors);

        var expectedNumberOfDivisors = 96;
        numberOfDivisors.Should().Be(expectedNumberOfDivisors);
    }

    [Test]
    public void Test2()
    {
        List<int> factors = [2, 2, 2, 3, 5, 5, 11, 11];
        var numberOfDivisors = DivisibilityUtils.GetDivisorsCount(factors);

        var expectedNumberOfDivisors = 72;
        numberOfDivisors.Should().Be(expectedNumberOfDivisors);
    }

    [Test]
    public void Test3()
    {
        List<int> factors = [2, 2, 2, 2, 2, 2, 3, 3, 3, 7, 7];
        var numberOfDivisors = DivisibilityUtils.GetDivisorsCount(factors);

        var expectedNumberOfDivisors = 84;
        numberOfDivisors.Should().Be(expectedNumberOfDivisors);
    }

    [Test]
    public void Test4()
    {
        List<int> factors = [2, 2, 2, 3, 3, 3, 5, 7, 13];
        var numberOfDivisors = DivisibilityUtils.GetDivisorsCount(factors);

        var expectedNumberOfDivisors = 128;
        numberOfDivisors.Should().Be(expectedNumberOfDivisors);
    }

    [Test]
    public void Test5()
    {
        List<int> factors = [2, 2, 2, 3, 3, 3, 5, 7, 11];
        var numberOfDivisors = DivisibilityUtils.GetDivisorsCount(factors);

        var expectedNumberOfDivisors = 128;
        numberOfDivisors.Should().Be(expectedNumberOfDivisors);
    }

    [Test]
    public void Test11()
    {
        var upperBound = 100_000;
        var (number, divisorCount) = DivisibilityUtils.GetMaxDivisorsNumber(upperBound);

        var expectedNumber = 83160;
        var expectedDivisorCount = 128;

        using var scope = new AssertionScope();
        number.Should().Be(expectedNumber);
        divisorCount.Should().Be(expectedDivisorCount);
    }

    [Test]
    public void Test12()
    {
        var upperBound = 100_000;
        var atLeastCount = 120;
        var list = DivisibilityUtils.GetMaxDivisorsNumber2(upperBound, atLeastCount);

        list.Should().NotBeEmpty();
    }
}