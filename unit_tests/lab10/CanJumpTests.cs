using FluentAssertions;
using labs.lab10;
using NUnit.Framework;

namespace unit_tests.lab10;

public class CanJumpTests
{
    [Test]
    public void Test1()
    {
        int[] nums = [2,3,1,1,4];

        var result = JumpGame.CanJump(nums);
        result.Should().BeTrue();
    }

    [Test]
    public void Test2()
    {
        int[] nums = [3,2,1,0,4];

        var result = JumpGame.CanJump(nums);
        result.Should().BeFalse();
    }

    [Test]
    public void Test3()
    {
        int[] nums = [2,0,0];

        var result = JumpGame.CanJump(nums);
        result.Should().BeTrue();
    }
}