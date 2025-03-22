namespace labs.lab4;

public static class BuyAnythingKruskal
{
    public static int MaximumSpanningTree(int n, int[] values)
    {
        var edges = GetEdgesPriorityQueue(n, values);
        return GetKruskalMaxCost(n, edges);
    }

    private static PriorityQueue<(int weight, int u, int v), int> GetEdgesPriorityQueue(int n, int[] values)
    {
        // comparer is provided for max-heap priority queue behaviour
        var edges = new PriorityQueue<(int weight, int u, int v), int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

        var gcdCache = new Dictionary<(int, int), int>();

        for (var i = 0; i < n; i++)
        for (var j = i + 1; j < n; j++)
        {
            var gcdValue = GreatestCommonDivisorWithCache(gcdCache, values[i], values[j]);
            var edge = (gcdValue, i, j);
            edges.Enqueue(edge, gcdValue);
        }

        return edges;
    }

    private static int GreatestCommonDivisorWithCache(Dictionary<(int, int), int> gcdCache, int a, int b)
    {
        var key = (Math.Min(a, b), Math.Max(a, b));
        if (gcdCache.TryGetValue(key, out var gcdValue))
            return gcdValue;

        gcdValue = GreatestCommonDivisor(a, b);
        gcdCache[key] = gcdValue;
        gcdCache[(gcdValue, a)] = gcdValue;
        gcdCache[(gcdValue, b)] = gcdValue;
        return gcdValue;
    }

    private static int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            a %= b;
            (a, b) = (b, a);
        }

        return a;
    }

    private static int GetKruskalMaxCost(int n, PriorityQueue<(int weight, int u, int v), int> edges)
    {
        var parent = Enumerable.Range(0, n).ToArray();
        var rank = new int[n];

        var count = 0;
        var maxEdgesCount = n - 1;
        var maxCost = 0;

        while (edges.Count > 0 && count < maxEdgesCount)
        {
            var (weight, u, v) = edges.Dequeue();

            if (FindParentWithCompression(parent, u) == FindParentWithCompression(parent, v))
                continue;

            DisjointSetUnion(parent, rank, u, v);
            maxCost += weight;
            count++;
        }

        return maxCost;
    }

    private static void DisjointSetUnion(int[] parent, int[] rank, int i, int j)
    {
        var iParent = FindParentWithCompression(parent, i);
        var jParent = FindParentWithCompression(parent, j);
        
        if (iParent == jParent)
            return;

        UnionParentsWithRanking(parent, rank, iParent, jParent);
    }

    private static int FindParentWithCompression(int[] parent, int i)
    {
        if (parent[i] != i)
            parent[i] = FindParentWithCompression(parent, parent[i]);

        return parent[i];
    }

    private static void UnionParentsWithRanking(int[] parent, int[] rank, int iParent, int jParent)
    {
        if (rank[iParent] > rank[jParent])
        {
            parent[jParent] = iParent;
        }
        else if (rank[iParent] < rank[jParent])
        {
            parent[iParent] = jParent;
        }
        else
        {
            parent[jParent] = iParent;
            rank[iParent]++;
        }
    }
}
