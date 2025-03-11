namespace labs.lab3;

public static class FishInGrid
{
    public static int FindMaxFish(int[][] grid)
    {
        var queue = new Queue<int[]>();
        var max = 0;
        for (var r = 0; r < grid.Length; r++)
        for (var c = 0; c < grid[r].Length; c++)
        {
            if (grid[r][c] == 0)
                continue;

            queue.Enqueue([r, c]);
            var current = BreadthFirstSearch(queue, grid);

            if (current > max)
                max = current;

            queue.Clear();
        }

        return max;
    }

    private static int BreadthFirstSearch(Queue<int[]> queue, int[][] grid)
    {
        var aggregated = 0;
        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();
            var row = cell[0];
            var column = cell[1];
            aggregated += grid[row][column];
            grid[row][column] = 0;
            EnqueueAdjacentCells(queue, grid, row, column);
        }
        return aggregated;
    }

    private static void EnqueueAdjacentCells(Queue<int[]> queue, int[][] grid, int row, int column)
    {
        if (row > 0 && grid[row - 1][column] != 0)
            queue.Enqueue([row - 1, column]);
        if (column > 0 && grid[row][column - 1] != 0)
            queue.Enqueue([row, column - 1]);
        if (row < grid.Length - 1 && grid[row + 1][column] != 0)
            queue.Enqueue([row + 1, column]);
        if (column < grid[row].Length - 1 && grid[row][column + 1] != 0)
            queue.Enqueue([row, column + 1]);
    }
}
