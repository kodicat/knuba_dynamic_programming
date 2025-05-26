using System;
using System.Collections.Generic;

namespace labs.lab6;

public class ShilAndAssignment
{
    public static int MaxDivisibleAssignments(int N, int M, List<int> A)
    {
        var graph = new List<int>[M + 1];
        for (var i = 1; i <= M; i++)
            graph[i] = new List<int>();

        for (var ci = 1; ci <= M; ci++)
        {
            for (var i = 0; i < N; i++)
            {
                if (A[i] % ci == 0)
                    graph[ci].Add(i);
            }
        }

        var matchTo = new int[N];
        Array.Fill(matchTo, -1);

        var result = 0;

        for (var ci = 1; ci <= M; ci++)
        {
            var visited = new bool[N];
            if (FindMatch(ci, graph, matchTo, visited))
                result++;
        }

        return result;
    }

    private static bool FindMatch(int ci, List<int>[] graph, int[] matchTo, bool[] visited)
    {
        foreach (var aiIndex in graph[ci])
        {
            if (visited[aiIndex]) continue;
            visited[aiIndex] = true;

            if (matchTo[aiIndex] == -1 || FindMatch(matchTo[aiIndex], graph, matchTo, visited))
            {
                matchTo[aiIndex] = ci;
                return true;
            }
        }
        return false;
    }

    public static void Main()
    {
        var tokens = System.Console.ReadLine().Split();
        var N = int.Parse(tokens[0]);
        var M = int.Parse(tokens[1]);

        List<int> A = new List<int>();
        for (var i = 0; i < N; i++)
        {
            A.Add(int.Parse(System.Console.ReadLine()));
        }

        var answer = MaxDivisibleAssignments(N, M, A);
        Console.WriteLine(answer);
    }
}
