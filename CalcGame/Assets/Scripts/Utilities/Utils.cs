using System.Collections.Generic;

public static class Utils
{
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static char MathOperationSymbol(this MathOperationEnum mathOperationEnum)
    {
        switch (mathOperationEnum)
        {
            case MathOperationEnum.Add:
                {
                    return '+';
                }
            case MathOperationEnum.Subtract:
                {
                    return '-';
                }
            case MathOperationEnum.Multiply:
                {
                    return '*';
                }
            case MathOperationEnum.Divide:
                {
                    return '/';
                }
        }
        return default;
    }
}
