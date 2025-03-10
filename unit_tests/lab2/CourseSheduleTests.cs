using FluentAssertions;
using labs.lab2;
using NUnit.Framework;

namespace unit_tests.lab2;

public class CourseSheduleTests
{
    [Test]
    public void TestBasicScenario()
    {
        var numCourses = 2;
        int[][] prerequisites = [[1, 0]];
        var result = CourseSchedule.CanFinish(numCourses, prerequisites);
        
        result.Should().BeTrue();
    }
    
    [Test]
    public void TestCyclicGraphScenario()
    {
        var numCourses = 2;
        int[][] prerequisites = [[1,0],[0,1]];
        var result = CourseSchedule.CanFinish(numCourses, prerequisites);
        
        result.Should().BeFalse();
    }
}