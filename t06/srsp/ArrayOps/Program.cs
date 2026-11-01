using System;

static class ArrayOps
{
    public static int Sum(int[] a)
    {
        int s = 0;
        for (int i = 0; i < a.Length; i++)
        {
            s = s + a[i];
        }
        return s;
    }

    public static int IndexOfMin(int[] a)
    {
        int min = a[0];
        int minIndex = 0;

        for (int i = 1; i < a.Length; i++)
        {
            if (a[i] < min)
            {
                min = a[i];
                minIndex = i;
            }
        }
        return minIndex;
    }

    public static int CountGreater(int[] a, int x)
    {
        int count = 0;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] > x)
            {
                count++;
            }
        }
        return count;
    }

    public static void Reverse(int[] a)
    {
        for (int i = 0; i < a.Length / 2; i++)
        {
            int temp = a[i];
            a[i] = a[a.Length - 1 - i];
            a[a.Length - 1 - i] = temp;
        }
    }
}

class Program
{
    static void Main()
    {
        int x = 2;

        int[] arr1 = new int[] { 4, 1, 7, 3, 9 };
        Console.Write("Исходный массив 1: ");
        for (int i = 0; i < arr1.Length; i++) { Console.Write(arr1[i] + " "); }
        Console.WriteLine();
        
        Console.WriteLine("Сумма: " + ArrayOps.Sum(arr1));
        Console.WriteLine("Индекс минимума: " + ArrayOps.IndexOfMin(arr1));
        Console.WriteLine("Элементов > 2: " + ArrayOps.CountGreater(arr1, x));
        
        ArrayOps.Reverse(arr1);
        Console.Write("После Reverse: ");
        for (int i = 0; i < arr1.Length; i++) { Console.Write(arr1[i] + " "); }
        Console.WriteLine("\n-------------------------------------");

        int[] arr2 = new int[] { 5 };
        Console.Write("Исходный массив 2: ");
        for (int i = 0; i < arr2.Length; i++) { Console.Write(arr2[i] + " "); }
        Console.WriteLine();
        
        Console.WriteLine("Сумма: " + ArrayOps.Sum(arr2));
        Console.WriteLine("Индекс минимума: " + ArrayOps.IndexOfMin(arr2));
        Console.WriteLine("Элементов > 2: " + ArrayOps.CountGreater(arr2, x));
        
        ArrayOps.Reverse(arr2);
        Console.Write("После Reverse: ");
        for (int i = 0; i < arr2.Length; i++) { Console.Write(arr2[i] + " "); }
        Console.WriteLine("\n-------------------------------------");

        int[] arr3 = new int[] { -2, -7, -4 };
        Console.Write("Исходный массив 3: ");
        for (int i = 0; i < arr3.Length; i++) { Console.Write(arr3[i] + " "); }
        Console.WriteLine();
        
        Console.WriteLine("Сумма: " + ArrayOps.Sum(arr3));
        Console.WriteLine("Индекс минимума: " + ArrayOps.IndexOfMin(arr3));
        Console.WriteLine("Элементов > 2: " + ArrayOps.CountGreater(arr3, x));
        
        ArrayOps.Reverse(arr3);
        Console.Write("После Reverse: ");
        for (int i = 0; i < arr3.Length; i++) { Console.Write(arr3[i] + " "); }
        Console.WriteLine("\n-------------------------------------");

        int[] arr4 = new int[] { 2, 2, 2 };
        Console.Write("Исходный массив 4: ");
        for (int i = 0; i < arr4.Length; i++) { Console.Write(arr4[i] + " "); }
        Console.WriteLine();
        
        Console.WriteLine("Сумма: " + ArrayOps.Sum(arr4));
        Console.WriteLine("Индекс минимума: " + ArrayOps.IndexOfMin(arr4));
        Console.WriteLine("Элементов > 2: " + ArrayOps.CountGreater(arr4, x));
        
        ArrayOps.Reverse(arr4);
        Console.Write("После Reverse: ");
        for (int i = 0; i < arr4.Length; i++) { Console.Write(arr4[i] + " "); }
        Console.WriteLine("\n-------------------------------------");
    }
}
