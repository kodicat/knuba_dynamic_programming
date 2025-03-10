namespace labs.lab2;

public static class CourseSchedule
{
    public static bool CanFinish(int numCourses, int[][] prerequisites)
    {
        if (numCourses == 0)
        {
            return true;
        }

        var adjacencyMatrix = new bool[numCourses, numCourses];
        FillAdjacencyMatrix(adjacencyMatrix, prerequisites);

        var inDegree = new int[numCourses];
        FillInDegree(inDegree, numCourses, adjacencyMatrix);

        return IsTopologicallySortable(adjacencyMatrix, inDegree);
    }

    private static void FillAdjacencyMatrix(bool[,] adjacencyMatrix, int[][] prerequisites)
    {
        foreach (var edge in prerequisites)
        {
            var i = edge[0];
            var j = edge[1];
            adjacencyMatrix[i, j] = true;
        }
    }

    private static void FillInDegree(int[] inDegree, int numCourses, bool[,] adjacencyMatrix)
    {
        for (var i = 0; i < numCourses; i++)
        for (var j = 0; j < numCourses; j++)
        {
            if (adjacencyMatrix[i, j])
                inDegree[j]++;
        }
    }
    
    private static bool IsTopologicallySortable(bool[,] adjacencyMatrix, int[] inDegree)
    {
        var nodeCount = inDegree.Length;

        var queue = new Queue<int>();
        AddZeroInDegreeNodes(queue, inDegree);

        var visitedNodes = new HashSet<int>();
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (!visitedNodes.Add(node))
                return false;

            for (var j = 0; j < nodeCount; j++)
            {
                if (adjacencyMatrix[node, j])
                {
                    inDegree[j]--;
                    if (inDegree[j] == 0)
                    {
                        queue.Enqueue(j);
                    }
                }
            }
        }

        return visitedNodes.Count == nodeCount;
    }

    private static void AddZeroInDegreeNodes(Queue<int> queue, int[] inDegree)
    {
        for (var i = 0; i < inDegree.Length; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }
    }
}
