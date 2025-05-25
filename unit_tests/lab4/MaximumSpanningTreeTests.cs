using FluentAssertions;
using FluentAssertions.Execution;
using labs.lab4;
using NUnit.Framework;

namespace unit_tests.lab4;

public class MaximumSpanningTreeTests
{
    [Test]
    public void Test1()
    {
        var n = 3;
        int[] values = [4, 6, 9];
        var expected = 5;

        var kruskal = BuyAnythingKruskal.MaximumSpanningTree(n, values);
        var kruskalListImplementation = BuyAnythingKruskalListImplementation.MaximumSpanningTree(n, values);

        using var scope = new AssertionScope();
        kruskal.Should().Be(expected);
        kruskalListImplementation.Should().Be(expected);
    }

    [Test]
    public void Test2()
    {
        var n = 2;
        int[] values = [14521, 20887];
        var expected = 1;

        var kruskal = BuyAnythingKruskal.MaximumSpanningTree(n, values);
        var kruskalListImplementation = BuyAnythingKruskalListImplementation.MaximumSpanningTree(n, values);

        using var scope = new AssertionScope();
        kruskal.Should().Be(expected);
        kruskalListImplementation.Should().Be(expected);
    }

    [Test]
    public void Test3()
    {
        var n = 16;
        int[] values = [69523, 62792, 19448, 48086, 49683, 68069, 23408, 5040, 34264, 53543, 66522, 33498, 6568, 1386, 72586, 71315];
        var expected = 449;

        var kruskal = BuyAnythingKruskal.MaximumSpanningTree(n, values);
        var kruskalListImplementation = BuyAnythingKruskalListImplementation.MaximumSpanningTree(n, values);

        using var scope = new AssertionScope();
        kruskal.Should().Be(expected);
        kruskalListImplementation.Should().Be(expected);
    }

    [Test]
    public void Test4()
    {
        var n = 29;
        int[] values =
        [
            42261, 96196, 17569, 69141, 7364, 29233, 71530, 50747, 94021, 5793, 64012, 81770, 98844, 43244,
            30483, 58996, 69746, 79082, 75238, 89269, 48181, 90393, 75138, 85730, 69776, 78883, 27196, 92288, 87872
        ];
        var expected = 722;

        var kruskal = BuyAnythingKruskal.MaximumSpanningTree(n, values);
        var kruskalListImplementation = BuyAnythingKruskalListImplementation.MaximumSpanningTree(n, values);

        using var scope = new AssertionScope();
        kruskal.Should().Be(expected);
        kruskalListImplementation.Should().Be(expected);
    }

    [Test]
    public void Test5()
    {
        var n = 29;
        int[] values =
        [
            6503, 7397, 36910, 31719, 65578, 28908, 94464, 47470, 89191, 69008, 43744, 64405, 5918, 99148, 9669, 34120,
            26304, 35771, 58163, 78327, 16726, 52925, 35447, 60956, 71666, 96979, 78196, 70263, 85709
        ];
        var expected = 610;

        var kruskal = BuyAnythingKruskal.MaximumSpanningTree(n, values);
        var kruskalListImplementation = BuyAnythingKruskalListImplementation.MaximumSpanningTree(n, values);

        using var scope = new AssertionScope();
        kruskal.Should().Be(expected);
        kruskalListImplementation.Should().Be(expected);
    }
}
