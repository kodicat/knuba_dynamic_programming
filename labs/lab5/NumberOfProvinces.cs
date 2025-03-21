namespace labs.lab5;

// disjoint set union (DSU)
public static class NumberOfProvinces
{
    public static int FindCircleNum(int[][] isConnected)
    {
        var n = isConnected.Length;
        var parent = Enumerable.Range(0, n).ToArray();
        var rank = new int[n];

        for (var i = 0; i < n; i++)
        for (var j = i + 1; j < n; j++)
        {
            if (isConnected[i][j] == 1)
                Union(i, j, parent, rank);
        }

        return parent.Where((x, i) => x == i).Count();
    }

    private static void Union(int i, int j, int[] parent, int[] rank)
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
        var from = iParent;
        var to = jParent;

        if (rank[iParent] > rank[jParent])
        {
            from = jParent;
            to = iParent;
        }

        parent[from] = to;

        if (rank[iParent] == rank[jParent])
            rank[iParent]++;
    }
}
