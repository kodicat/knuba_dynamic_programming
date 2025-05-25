namespace labs.individual;

public abstract class ParallelCourses3
{
    public static int MinimumTime(int n, int[][] relations, int[] time) {
        var (graph, inDegree) = BuildGraph(n, relations);

        var (queue, dp) = InitializeQueue(n, time, inDegree);

        while (queue.Count > 0) {
            var course = queue.Dequeue();
            foreach (var neighbor in graph[course]) {
                dp[neighbor] = Math.Max(dp[neighbor], dp[course] + time[neighbor]);
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }

        return dp.Prepend(0).Max();
    }

    private static (List<int>[] graph, int[] inDegree) BuildGraph(int n, int[][] relations)
    {
        var graph = new List<int>[n];
        for (var i = 0; i < n; i++) {
            graph[i] = [];
        }
        var inDegree = new int[n];

        foreach (var relation in relations) {
            var prevIndex = relation[0] - 1;
            var nextIndex = relation[1] - 1;
            graph[prevIndex].Add(nextIndex);
            inDegree[nextIndex]++;
        }

        return (graph, inDegree);
    }

    private static (Queue<int> queue, int[] dp) InitializeQueue(int n, int[] time, int[] inDegree)
    {
        var queue = new Queue<int>();
        var dp = new int[n];

        for (var i = 0; i < n; i++) {
            if (inDegree[i] == 0) {
                queue.Enqueue(i);
                dp[i] = time[i];
            }
        }

        return (queue, dp);
    }
}
