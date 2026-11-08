using System;

namespace ArrayAlgosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Тестирование BubbleSort ---");
            TestBubble(new int[] { });
            TestBubble(new int[] { 5 });
            TestBubble(new int[] { 1, 2, 3, 4, 5 });
            TestBubble(new int[] { 5, 4, 3, 2, 1 });
            TestBubble(new int[] { 3, 1, 3, 2, 3 });

            // Тест на массиве из 1000 элементов (уже отсортированном)
            int[] largeArray = new int[1000];
            for (int i = 0; i < 1000; i++) largeArray[i] = i;
            int largeComparisons = ArrayAlgos.BubbleSort(largeArray);
            Console.WriteLine($"\nТест 1000 элементов: Сравнений = {largeComparisons} (Ожидается 999)");

            Console.WriteLine("\n--- Тестирование CountOccurrences ---");
            int[] sortedA = new int[] { 1, 2, 2, 2, 5, 7 };
            TestCount(sortedA, 2, 3);
            TestCount(sortedA, 1, 1);
            TestCount(sortedA, 7, 1);
            TestCount(sortedA, 3, 0);
            TestCount(sortedA, 9, 0);
        }

        // Вспомогательный метод для красивого вывода тестов сортировки
        static void TestBubble(int[] a)
        {
            Console.Write("До: [" + string.Join(", ", a) + "]");
            int comparisons = ArrayAlgos.BubbleSort(a);
            bool sorted = ArrayAlgos.IsSorted(a);
            Console.WriteLine($" | После: [" + string.Join(", ", a) + $"] | IsSorted: {sorted} | Сравнений: {comparisons}");
        }

        // Вспомогательный метод для красивого вывода тестов поиска вхождений
        static void TestCount(int[] a, int x, int expected)
        {
            int actual = ArrayAlgos.CountOccurrences(a, x);
            Console.WriteLine($"Массив: [{string.Join(", ", a)}] | Ищем: {x} | Ожидалось: {expected} | Факт: {actual} | {(actual == expected ? "OK" : "FAIL")}");
        }
    }

    public static class ArrayAlgos
    {
        // 1. Проверка, отсортирован ли массив
        public static bool IsSorted(int[] a)
        {
            if (a == null || a.Length <= 1)
                return true;

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1])
                    return false; // если нашли элемент больше следующего — не отсортирован
            }
            return true;
        }

        // 2. Сортировка пузырьком с флажком раннего выхода
        public static int BubbleSort(int[] a)
        {
            if (a == null || a.Length <= 1)
                return 0;

            int comparisons = 0;
            int n = a.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false; // флажок раннего выхода

                for (int j = 0; j < n - 1 - i; j++)
                {
                    comparisons++;
                    if (a[j] > a[j + 1])
                    {
                        // меняем элементы местами
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swapped = true;
                    }
                }

                // Если за весь проход ни одного обмена не было — массив уже отсортирован
                if (!swapped)
                    break;
            }

            return comparisons;
        }

        // 3. Количество вхождений через два бинарных поиска (без циклов по всему массиву)
        public static int CountOccurrences(int[] sortedA, int x)
        {
            if (sortedA == null || sortedA.Length == 0)
                return 0;

            // Первый бинарный поиск: индекс первого элемента >= x (LowerBound)
            int lower = FindLowerBound(sortedA, x);

            // Второй бинарный поиск: индекс первого элемента > x (UpperBound)
            int upper = FindUpperBound(sortedA, x);

            // Разница между индексами и есть количество вхождений
            return upper - lower;
        }

        // Метод для поиска индекса первого элемента >= x
        private static int FindLowerBound(int[] a, int x)
        {
            int lo = 0;
            int hi = a.Length; // берем длину, так как элемент может быть больше всех

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (a[mid] >= x)
                    hi = mid;
                else
                    lo = mid + 1;
            }
            return lo;
        }

        // Метод для поиска индекса первого элемента > x
        private static int FindUpperBound(int[] a, int x)
        {
            int lo = 0;
            int hi = a.Length;

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (a[mid] > x)
                    hi = mid;
                else
                    lo = mid + 1;
            }
            return lo;
        }
    }
}
