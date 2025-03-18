using FluentAssertions;
using labs.lab9;
using NUnit.Framework;

namespace unit_tests.lab9;

public class IntToRomanTests
{
    [Test]
    public void Test1()
    {
        var n = 3749;

        var result = IntegerToRoman.IntToRoman(n);
        result.Should().Be("MMMDCCXLIX");
    }

    [Test]
    public void Test2()
    {
        var n = 58;

        var result = IntegerToRoman.IntToRoman(n);
        result.Should().Be("LVIII");
    }

    [Test]
    public void Test3()
    {
        var n = 1994;

        var result = IntegerToRoman.IntToRoman(n);
        result.Should().Be("MCMXCIV");
    }

    [Test]
    public void Test4()
    {
        var n = 4;

        var result = IntegerToRoman.IntToRoman(n);
        result.Should().Be("IV");
    }

    [Test]
    public void Test5()
    {
        var n = 5;

        var result = IntegerToRoman.IntToRoman(n);
        result.Should().Be("V");
    }
}
