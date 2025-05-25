using FluentAssertions;
using labs.lab4.Utils;
using NUnit.Framework;

namespace unit_tests.lab4.Utils;

public class GetPrimeFactorsTests
{
    [Test]
    public void Test1()
    {
        var n = 37800;
        var factors = DivisibilityUtils.GetPrimeFactors(n);

        (int, int)[] expected = [(2, 3), (3, 3), (5, 2), (7, 1)];
        factors.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Test2()
    {
        var n = 72600;
        var factors = DivisibilityUtils.GetPrimeFactors(n);

        (int, int)[] expected = [(2, 3), (3, 1), (5, 2), (11, 2)];
        factors.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Test3()
    {
        var n = 84672;
        var factors = DivisibilityUtils.GetPrimeFactors(n);

        (int, int)[] expected = [(2, 6), (3, 3), (7, 2)];
        factors.Should().BeEquivalentTo(expected);
    }
}
