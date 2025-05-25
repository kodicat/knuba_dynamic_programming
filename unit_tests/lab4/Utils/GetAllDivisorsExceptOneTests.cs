using FluentAssertions;
using labs.lab4.Utils;
using NUnit.Framework;

namespace unit_tests.lab4.Utils;

public class GetAllDivisorsExceptOneTests
{
    [TestCase(1, 0)]
    [TestCase(2, 1)]
    [TestCase(3, 1)]
    [TestCase(12, 5)]
    [TestCase(55440, 119)]
    [TestCase(83160, 127)]
    [TestCase(98280, 127)]
    public void Test1(int number, int expectedCount)
    {
        var list = DivisibilityUtils.GetAllDivisorsExceptOne(number);

        list.Should().HaveCount(expectedCount);
    }
}
