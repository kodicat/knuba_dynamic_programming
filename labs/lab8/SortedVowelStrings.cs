namespace labs.lab8;

public static class SortedVowelStrings
{
    private static string[] _alphabet = ["a", "e", "i", "o", "u"];

    public static int CountVowelStrings(int n)
    {
        return Sequence(_alphabet, n);
        // return StarsAndBarsTheorem(_alphabet, n);
    }

    private static int Sequence(string[] alphabet, int n)
    {
        var count = alphabet.Length;
        var accumulator = new int[count];
        for (var i = 0; i < count; i++)
            accumulator[i] = 1; 

        for (var i = 0; i < n; i++)
        for (var j = 1; j < count; j++)
            accumulator[j] += accumulator[j - 1];

        return accumulator[count - 1];
    }

    private static int StarsAndBarsTheorem(string[] alphabet, int n)
    {
        var k = alphabet.Length;

        return BinomialCoefficient(n + k - 1, k - 1);
    }

    private static int BinomialCoefficient(int n, int k)
    {
        var result = 1;
        for (var i = 0; i < k; i++)
        {
            result *= (n - i);
            result /= (i + 1);
        }

        return result;
    }
}
