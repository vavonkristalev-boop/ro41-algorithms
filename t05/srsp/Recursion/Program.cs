using System;

static class Rec
{
    public static int DigitSum(int n)
    {
        if (n == 0) // Базовый случай
        {
            return 0;
        }
        return (n % 10) + DigitSum(n / 10);
    }

    public static long Pow(int x, int n)
    {
        if (n == 0) // Базовый случай
        {
            return 1;
        }
        return x * Pow(x, n - 1);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("DigitSum(0) = " + Rec.DigitSum(0));
        Console.WriteLine("DigitSum(7) = " + Rec.DigitSum(7));
        Console.WriteLine("DigitSum(12345) = " + Rec.DigitSum(12345));
        Console.WriteLine("DigitSum(1000) = " + Rec.DigitSum(1000));

        Console.WriteLine("-----------------------------");

        Console.WriteLine("Pow(2, 0) = " + Rec.Pow(2, 0));
        Console.WriteLine("Pow(2, 10) = " + Rec.Pow(2, 10));
        Console.WriteLine("Pow(5, 3) = " + Rec.Pow(5, 3));
        Console.WriteLine("Pow(7, 1) = " + Rec.Pow(7, 1));
    }
}
