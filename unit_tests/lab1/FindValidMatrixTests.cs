using FluentAssertions;
using FluentAssertions.Execution;
using labs.lab1;
using NUnit.Framework;

namespace unit_tests.lab1;

public class FindValidMatrixTests
{
    [Test]
    public void TestBasicScenario()
    {
        int[] rowSum = [3, 8], colSum = [4, 7];
        var matrix = FindValidMatrix.RestoreMatrix(rowSum, colSum);
        TestMatrix(matrix, rowSum, colSum);
    }

    [Test]
    public void TestScenarioMoreComplex()
    {
        int[] rowSum = [5, 7, 10], colSum = [8, 6, 8];
        var matrix = FindValidMatrix.RestoreMatrix(rowSum, colSum);
        TestMatrix(matrix, rowSum, colSum);
    }

    private static void TestMatrix(int[][] matrix, int[] rowSum, int[] colSum)
    {
        using (var _ = new AssertionScope());
        var indexedRows = matrix.Select((row, index) => (index, row));
        foreach (var (index, row) in indexedRows)
        {
            row.Sum().Should().Be(rowSum[index]);
        }

        var indexedCols = 
            Enumerable
                .Range(0, matrix[0].Length)
                .Select(colIndex => matrix.Select(row => row[colIndex]).ToArray())
                .Select((col, index) => (index, col))
                .ToArray();
        foreach (var (index, col) in indexedCols)
        {
            col.Sum().Should().Be(colSum[index]);
        }
    }
}
