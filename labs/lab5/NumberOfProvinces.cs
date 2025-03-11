namespace labs.lab5;

public static class NumberOfProvinces
{
    public static int FindCircleNum(int[][] isConnected)
    {
        var n = isConnected.Length;
        var parent = Enumerable.Range(0, n).ToArray();

        for (var i = 0; i < n; i++)
        for (var j = i + 1; j < n; j++)
        {
            if (isConnected[i][j] == 1)
                Connect(i, j, parent);
        }

        return parent.Where((x, i) => x == i).Count();
    }

    private static void Connect(int i, int j, int[] parent)
    {
        var iParent = FindParent(parent, i);
        var jParent = FindParent(parent, j);
        
        if (iParent == jParent)
            return;
        
        parent[iParent] = jParent;
    }

    private static int FindParent(int[] parent, int i)
    {
        if (parent[i] == i)
            return i;
        return FindParent(parent, parent[i]);
    }
}
