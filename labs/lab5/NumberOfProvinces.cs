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
        var iParent = FindParent(parent, i);
        var jParent = FindParent(parent, j);
        
        if (iParent == jParent)
            return;

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
            rank[jParent] = iParent;
            rank[iParent]++;
        }

        parent[iParent] = jParent;
    }

    private static int FindParent(int[] parent, int i)
    {
        if (parent[i] != i)
            parent[i] = FindParent(parent, parent[i]);

        return parent[i];
    }
}
