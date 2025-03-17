namespace labs.lab7;

public static class ShortestPath
{
    public static int FindTheCity(int n, int[][] edges, int distanceThreshold)
    {
        var graph = CreateDistanceGraph(n);
        FillNeighborCities(graph, edges);
        FillGraphFloydWarshallShortestPath(graph);
        return GetLastCityWithTheSmallestNumberOfNeighbors(graph, distanceThreshold);
    }

    private static int[][] CreateDistanceGraph(int n)
    {
        var graph = new int[n][];
        for (var i = 0; i < n; i++)
        {
            graph[i] = new int[n];
            for (var j = 0; j < n; j++)
            {
                if (i == j)
                {
                    graph[i][j] = 0;
                }
                else
                {
                    graph[i][j] = int.MaxValue;
                }
            }
        }

        return graph;
    }

    private static void FillNeighborCities(int[][] graph, int[][] edges)
    {
        foreach (var edge in edges)
        {
            var from = edge[0];
            var to = edge[1];
            var distance = edge[2];

            UpdateDistance(graph, from, to, distance);
        }
    }

    private static void FillGraphFloydWarshallShortestPath(int[][] graph)
    {
        var n = graph.Length;
        for(var k = 0; k < n; k++)
        for(var i = 0; i < n; i++)
        for(var j = i; j < n; j++)
        {
            if (i == j)
                continue;

            if (graph[i][k] == int.MaxValue || graph[k][j] == int.MaxValue)
                continue;

            var distance = Math.Min(graph[i][j], graph[i][k] + graph[k][j]);
            UpdateDistance(graph, i, j, distance);
        }
    }

    private static void UpdateDistance(int[][] graph, int from, int to, int distance)
    {
        graph[from][to] = distance;
        graph[to][from] = distance;
    }

    private static int GetLastCityWithTheSmallestNumberOfNeighbors(int[][] graph, int distanceThreshold)
    {
        var n = graph.Length;
        var minNumber = n;
        var minCity = n;
        for (var city = 0; city < n; city++)
        {
            var count = graph[city].Count(x => x > 0 && x <= distanceThreshold);
            if (count > minNumber)
                continue;

            minNumber = count;
            minCity = city;
        }

        return minCity;
    }
}
