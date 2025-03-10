namespace labs.lab1;

public static class FindValidMatrix
{
    public static int[][] RestoreMatrix(int[] rowSum, int[] colSum)
    {
        rowSum = rowSum.ToArray();
        colSum = colSum.ToArray();

        var matrix = Enumerable
            .Range(0, rowSum.Length)
            .Select(_ => Enumerable.Repeat(0, colSum.Length).ToArray())
            .ToArray();

        for (var rowIndex = 0; rowIndex < rowSum.Length; rowIndex++)
        for (var colIndex = 0; colIndex < colSum.Length; colIndex++)
        {
            var maxValue = Math.Min(rowSum[rowIndex], colSum[colIndex]);
            matrix[rowIndex][colIndex] = maxValue;
            rowSum[rowIndex] -= maxValue;
            colSum[colIndex] -= maxValue;
        }

        return matrix;
    }
}
