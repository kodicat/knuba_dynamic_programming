using System.Text;

namespace labs.lab9;

public static class IntegerToRoman
{
    private static readonly (int, string)[] Translations =
    [
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I"),
    ];

    public static string IntToRoman(int num)
    {
        var romanNumberBuilder = new StringBuilder();
        foreach(var (arabic, roman) in Translations)
        {
            while (num >= arabic)
            {
                romanNumberBuilder.Append(roman);
                num -= arabic;
            }
        }
        return romanNumberBuilder.ToString();
    }
}
