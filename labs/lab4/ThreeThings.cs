using System;
using System.Collections.Generic;

namespace labs.lab4;

public class ThreeThings
{
    class DSU
    {
        private int[] parent;
        private int[] rank;
        public int Components { get; private set; }

        public DSU(int n)
        {
            parent = new int[n + 1];
            rank = new int[n + 1];
            Components = n;
            for (int i = 1; i <= n; i++) parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public bool Union(int x, int y)
        {
            int xr = Find(x), yr = Find(y);
            if (xr == yr) return false;

            if (rank[xr] < rank[yr])
                parent[xr] = yr;
            else if (rank[yr] < rank[xr])
                parent[yr] = xr;
            else
            {
                parent[yr] = xr;
                rank[xr]++;
            }

            Components--;
            return true;
        }
    }

    public static int Solve(int n, int m, List<Tuple<int, int, int>> edges)
    {
        var type1 = new List<Tuple<int, int>>();
        var type2 = new List<Tuple<int, int>>();
        var type3 = new List<Tuple<int, int>>();

        foreach (var edge in edges)
        {
            var a = edge.Item1;
            var b = edge.Item2;
            var type = edge.Item3;

            if (type == 1) type1.Add(Tuple.Create(a, b));
            else if (type == 2) type2.Add(Tuple.Create(a, b));
            else type3.Add(Tuple.Create(a, b));
        }

        var dsuMen = new DSU(n);
        var dsuWomen = new DSU(n);
        var used = 0;

        foreach (var edge in type3)
        {
            var a = edge.Item1;
            var b = edge.Item2;
            if (dsuMen.Find(a) != dsuMen.Find(b) || dsuWomen.Find(a) != dsuWomen.Find(b))
            {
                bool changedMen = dsuMen.Union(a, b);
                bool changedWomen = dsuWomen.Union(a, b);
                if (changedMen || changedWomen)
                    used++;
            }
        }

        foreach (var edge in type1)
        {
            var a = edge.Item1;
            var b = edge.Item2;
            if (dsuMen.Union(a, b))
                used++;
        }

        foreach (var edge in type2)
        {
            var a = edge.Item1;
            var b = edge.Item2;
            if (dsuWomen.Union(a, b))
                used++;
        }

        if (dsuMen.Components != 1 || dsuWomen.Components != 1)
            return -1;

        return m - used;
    }

    public static void Main()
    {
        var header = Console.ReadLine().Split();
        var n = int.Parse(header[0]);
        var m = int.Parse(header[1]);

        var edges = new List<Tuple<int, int, int>>();
        for (int i = 0; i < m; i++)
        {
            var parts = Console.ReadLine().Split();
            var a = int.Parse(parts[0]);
            var b = int.Parse(parts[1]);
            var t = int.Parse(parts[2]);
            edges.Add(Tuple.Create(a, b, t));
        }

        int result = Solve(n, m, edges);
        Console.WriteLine(result);
    }
}
