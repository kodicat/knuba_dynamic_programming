using FluentAssertions;
using labs.lab8;
using NUnit.Framework;

namespace unit_tests.lab8;

public class CountVowelStringsTests
{
    [Test]
    public void Test1()
    {
        var n = 1;

        var result = SortedVowelStrings.CountVowelStrings(n);
        result.Should().Be(5);
    }

    [Test]
    public void Test2()
    {
        var n = 2;

        var result = SortedVowelStrings.CountVowelStrings(n);
        result.Should().Be(15);
    }

    [Test]
    public void Test3()
    {
        var n = 3;

        var result = SortedVowelStrings.CountVowelStrings(n);
        result.Should().Be(35);
    }

    [Test]
    public void Test4()
    {
        var n = 4;

        var result = SortedVowelStrings.CountVowelStrings(n);
        result.Should().Be(70);
    }

    [Test]
    public void Test5()
    {
        var n = 33;

        var result = SortedVowelStrings.CountVowelStrings(n);
        result.Should().Be(66045);
    }
}
