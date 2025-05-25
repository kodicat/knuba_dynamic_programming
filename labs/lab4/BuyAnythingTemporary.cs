using labs.lab4.Utils;

namespace labs.lab4;

public static class BuyAnythingTemporary
{
    public static long MaximumSpanningTree(int n, string valuesString)
    {
        var values = new HashSet<int>();
        var duplicatesCost = ParseValuesFilteringDuplicates(valuesString, values);

        var divisorToNumbers = new Dictionary<int, HashSet<int>>();
        var numberToDivisors = new Dictionary<int, HashSet<int>>();

        var primesCost = FillDivisorsFilteringPrimes(values, divisorToNumbers, numberToDivisors);

        var maxCost = duplicatesCost + primesCost;

        var value = values.First();
        var initialDivisors = numberToDivisors[value];
        var addedDivisorsSortedSet = new SortedSet<int>(initialDivisors, Comparer<int>.Create((a, b) => b.CompareTo(a)));

        RemoveAddedValue(value, values, divisorToNumbers, numberToDivisors);

        var divisorsToRemove = new List<int>();
        while (values.Count > 0)
        {
            foreach (var divisor in addedDivisorsSortedSet)
            {
                var sameDivisorValues = divisorToNumbers[divisor];
                if (sameDivisorValues.Count == 0)
                {
                    divisorToNumbers.Remove(divisor);
                    divisorsToRemove.Add(divisor);
                    continue;
                }
                var first = sameDivisorValues.First();
                var divisorsToAdd = numberToDivisors[first];
                addedDivisorsSortedSet.UnionWith(divisorsToAdd);

                RemoveAddedValue(first, values, divisorToNumbers, numberToDivisors);
                maxCost += first;
                break;
            }

            if (divisorsToRemove.Count > 0)
            {
                addedDivisorsSortedSet.ExceptWith(divisorsToRemove);
                divisorsToRemove.Clear();
            }
        }

        return maxCost;
    }

    private static void RemoveAddedValue(
        int value,
        HashSet<int> values,
        Dictionary<int, HashSet<int>> divisorToNumbers,
        Dictionary<int, HashSet<int>> numberToDivisors)
    {
        var divisors = numberToDivisors[value];
        numberToDivisors.Remove(value);
        foreach (var divisor in divisors)
        {
            divisorToNumbers[divisor].Remove(value);
        }
        values.Remove(value);
    }

    private static long FillDivisorsFilteringPrimes(
        HashSet<int> values,
        Dictionary<int, HashSet<int>> divisorToNumbers,
        Dictionary<int, HashSet<int>> numberToDivisors)
    {
        var primes = new HashSet<int>();
        foreach (var value in values)
        {
            var divisors = DivisibilityUtils.GetAllDivisorsExceptOne(value);
            if (divisors.Count == 1)
            {
                primes.Add(value);
            }
            else
            {
                AddDivisorsAndNumbers(divisorToNumbers, numberToDivisors, value, divisors);
            }
        }
        return GetPrimesCost(values, primes);
    }

    private static void AddDivisorsAndNumbers(
        Dictionary<int,HashSet<int>> divisorToNumbers,
        Dictionary<int,HashSet<int>> numberToDivisors,
        int value,
        HashSet<int> divisors)
    {
        numberToDivisors[value] = divisors;

        foreach (var divisor in divisors)
        {
            if (divisorToNumbers.TryGetValue(divisor, out var numbers))
            {
                numbers.Add(value);
            }
            else
            {
                divisorToNumbers[divisor] = [value];
            }
        }
    }

    private static long ParseValuesFilteringDuplicates(
        string valuesString,
        HashSet<int> values)
    {
        const char spaceChar = ' ';

        var duplicatesCost = 0L;
        var left = 0;
        while (left < valuesString.Length)
        {
            if (valuesString[left] == spaceChar)
            {
                left++;
                continue;
            }

            var right = left;
            while (right < valuesString.Length && valuesString[right] != spaceChar)
                right++;

            // todo: parse manually without string creation
            var number = int.Parse(valuesString[left..right]);
            left = right;

            if (!values.Add(number))
            {
                duplicatesCost += number;
            }
        }

        return duplicatesCost;
    }

    private static long GetPrimesCost(HashSet<int> numbers, HashSet<int> primes)
    {
        if (primes.Count == 0)
            return 0L;

        numbers.ExceptWith(primes);

        if (numbers.Count == 0)
            return primes.Count - 1;

        var cost = 0L;
        foreach (var prime in primes)
        {
            foreach (var number in numbers)
            {
                if (number < prime)
                    continue;

                if (number % prime != 0)
                    continue;

                cost += prime - 1L;
                break;
            }

            cost += 1L;
        }
        return cost;
    }
}
