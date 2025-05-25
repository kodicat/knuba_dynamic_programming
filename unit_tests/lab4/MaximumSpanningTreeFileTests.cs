using FluentAssertions;
using labs.lab4;
using NUnit.Framework;

namespace unit_tests.lab4;

public class MaximumSpanningTreeFileTests
{
    private static readonly string TestFileDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "lab4/files");

    [TestCase("4 6 9", 3, 5)]
    [TestCase("14521 20887", 2, 1)]
    // [TestCase("69523 62792 19448 48086 49683 68069 23408 5040 34264 53543 66522 33498 6568 1386 72586 71315", 16, 449)]
    [TestCase("42261 96196 17569 69141 7364 29233 71530 50747 94021 5793 64012 81770 98844 43244 30483 58996 69746 79082 75238 89269 48181 90393 75138 85730 69776 78883 27196 92288 87872", 29, 722)]
    [TestCase("6503 7397 36910 31719 65578 28908 94464 47470 89191 69008 43744 64405 5918 99148 9669 34120 26304 35771 58163 78327 16726 52925 35447 60956 71666 96979 78196 70263 85709", 29, 610)]
    public void SimpleCaseTests(string values, int n, int expected)
    {
        var actual = BuyAnythingTemporary.MaximumSpanningTree(n, values);
        actual.Should().Be(expected);
    }

    // [TestCase("big_input.txt")]
    // public void Test1(string fileName)
    // {
    //     var (expected, n, values) = GetDataFromFile(fileName);
    //
    //     var kruskal = BuyAnythingKruskal.MaximumSpanningTree(n, values);
    //     // var kruskalListImplementation = BuyAnythingKruskalListImplementation.MaximumSpanningTree(n, values);
    //
    //     // using var scope = new AssertionScope();
    //     kruskal.Should().Be(expected);
    //     // kruskalListImplementation.Should().Be(expected);
    // }

    [TestCase("big_input.txt")]
    public void Test2(string fileName)
    {
        var (expected, n, valuesString) = GetDataFromFile(fileName);

        var maxCost = BuyAnythingTemporary.MaximumSpanningTree(n, valuesString);
        maxCost.Should().Be(expected);
    }

    private static (long expected, int n, string values) GetDataFromFile(string fileName)
    {
        var filePath = Path.Combine(TestFileDirectory, fileName);
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Test file not found: {filePath}");
        }

        var lines = File.ReadAllLines(filePath);

        var expected = long.Parse(lines[0]);
        var n = int.Parse(lines[1]);
        var valuesString = lines[2];

        return (expected, n, valuesString);
    }
}
