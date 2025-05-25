namespace labs.lab4.Utils;

public static class DivisibilityUtils
{
    // sqrt(100 000) ~ 317 (100 000 - max possible int as input)
    // take all the primes prior to 317 (317 * 317 > 100 000)
    // 65 first prime numbers
    private static readonly int[] Primes =
    [
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97,
        101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197,
        199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313
    ];

    public static HashSet<int> GetAllDivisorsExceptOne(int originalNumber)
    {
        if (originalNumber == 1)
            return [];

        var factors = GetPrimeFactorsInternal(originalNumber);
        return GetAllDivisorsExceptOne(factors);
    }

    public static List<(int factor, int exponent)> GetPrimeFactors(int n)
    {
        return GetPrimeFactorsInternal(n);
    }

    private static List<(int factor, int exponent)> GetPrimeFactorsInternal(int n)
    {
        if (n == 1)
            return [];

        var factors = new List<(int, int)>();
        foreach (var prime in Primes)
        {
            if (prime >= n)
                break;

            if (prime * prime > n)
                break;

            if (n % prime != 0)
                continue;

            var exponent = 0;
            while (n % prime == 0)
            {
                n /= prime;
                exponent++;
            }

            factors.Add((prime, exponent));
        }

        if (n > 1)
            factors.Add((n, 1));

        return factors;
    }

    private static HashSet<int> GetAllDivisorsExceptOne(List<(int factor, int exponent)> factors)
    {
        HashSet<int> divisors = [];
        CalculateDivisors(0, 1, factors, divisors);
        return divisors;
    }

    private static void CalculateDivisors(int index, int divisor, List<(int factor, int exponent)> factors, HashSet<int> divisors)
    {
        if (index == factors.Count)
        {
            if (divisor != 1)
                divisors.Add(divisor);
            return;
        }

        for (var i = 0; i <= factors[index].exponent; ++i)
        {
            CalculateDivisors(index + 1, divisor, factors, divisors);
            divisor *= factors[index].factor;
        }
    }

    public static int GetDivisorsCount(List<int> sortedPrimeFactors)
    {
        return GetDivisorsCountInternal(sortedPrimeFactors);
    }

    // number N is expressed as prime factorization
    // N = p1^e1 * p2^e2 * ... * pk^ek
    // then total number of divisors is
    // d(N) = (e1 + 1) * (e2 + 1) * ... * (ek + 1)
    private static int GetDivisorsCountInternal(List<int> sortedPrimeFactors)
    {
        if (sortedPrimeFactors.Count == 0)
            return 1;

        if (sortedPrimeFactors.Count == 1)
            return 2;

        var result = 1;

        var current = 1;
        var count = 0;
        foreach (var factor in sortedPrimeFactors)
        {
            if (factor == current)
            {
                count++;
                continue;
            }

            result *= (count + 1);
            count = 1;
            current = factor;
        }

        return result * (count + 1);
    }

    public static (int number, int divisorCount) GetMaxDivisorsNumber(int till)
    {
        var max = 1;
        var count = 0;
        for (var number = 1; number <= till; number++)
        {
            var factors = GetPrimeFactorsList(number);
            var divisorsCount = GetDivisorsCount(factors);

            if (divisorsCount <= count)
                continue;

            max = number;
            count = divisorsCount;
        }

        return (max, count);
    }

    public static List<(int number, int divisorCount)> GetMaxDivisorsNumber2(int till, int atLeastCount)
    {
        var list = new List<(int, int)>();
        for (var number = 1; number <= till; number++)
        {
            var factors = GetPrimeFactorsList(number);
            var divisorsCount = GetDivisorsCount(factors);

            if (divisorsCount < atLeastCount)
                continue;

            list.Add((number, divisorsCount));
        }

        return list;
    }

    private static List<int> GetPrimeFactorsList(int n)
    {
        if (n == 1)
            return [];
    
        var factors = new List<int>();
        foreach (var prime in Primes)
        {
            if (prime >= n)
                break;
    
            if (prime * prime > n)
                break;
    
            while (n % prime == 0)
            {
                n /= prime;
                factors.Add(prime);
            }
        }
    
        if (n > 1)
            factors.Add(n);
    
        return factors;
    }
}
