using System;
using System.Text;

namespace TextToolsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Тестирование CountWords ---");
            TestCountWords("", 0);
            TestCountWords("   ", 0);
            TestCountWords("a b", 2);
            TestCountWords("Ахметов Ерлан", 2);

            Console.WriteLine("\n--- Тестирование IsPalindrome ---");
            TestIsPalindrome("", true);
            TestIsPalindrome("   ", true);
            TestIsPalindrome("a b", false);
            TestIsPalindrome("А роза упала на лапу Азора", true);

            Console.WriteLine("\n--- Тестирование Initials ---");
            TestInitials("", "");
            TestInitials("   ", "");
            TestInitials("Ахметов Ерлан", "А. Е.");
            TestInitials("Ахметов Ерлан Серикұлы", "А. Е. С.");

            Console.WriteLine("\n--- Тестирование Repeat ---");
            TestRepeat("a", 3, "aaa");
            TestRepeat("abc", 2, "abcabc");
            TestRepeat("", 5, "");
        }

        // Вспомогательные методы для красивого вывода тестов как у студента
        static void TestCountWords(string input, int expected)
        {
            int actual = TextTools.CountWords(input);
            Console.WriteLine($"Вход: \"{input}\" | Ожидалось: {expected} | Факт: {actual} | {(actual == expected ? "OK" : "FAIL")}");
        }

        static void TestIsPalindrome(string input, bool expected)
        {
            bool actual = TextTools.IsPalindrome(input);
            Console.WriteLine($"Вход: \"{input}\" | Ожидалось: {expected} | Факт: {actual} | {(actual == expected ? "OK" : "FAIL")}");
        }

        static void TestInitials(string input, string expected)
        {
            string actual = TextTools.Initials(input);
            Console.WriteLine($"Вход: \"{input}\" | Ожидалось: \"{expected}\" | Факт: \"{actual}\" | {(actual == expected ? "OK" : "FAIL")}");
        }

        static void TestRepeat(string input, int n, string expected)
        {
            string actual = TextTools.Repeat(input, n);
            Console.WriteLine($"Вход: \"{input}\", n={n} | Ожидалось: \"{expected}\" | Факт: \"{actual}\" | {(actual == expected ? "OK" : "FAIL")}");
        }
    }

    public static class TextTools
    {
        // 1. Подсчет слов без лишних пробелов (без LINQ)
        public static int CountWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            // Делим по пробелам, удаляя пустые элементы между двойными пробелами
            string[] parts = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return parts.Length;
        }

        // 2. Палиндром без учета регистра и пробелов (чистый цикл)
        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return true;

            // Сначала убираем все пробелы и переводим в нижний регистр
            string clean = "";
            foreach (char c in s)
            {
                if (c != ' ')
                {
                    clean += char.ToLower(c);
                }
            }

            // Проверяем классическим циклом с двух сторон
            int left = 0;
            int right = clean.Length - 1;
            while (left < right)
            {
                if (clean[left] != clean[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }

        // 3. Получение инициалов из полного имени
        public static string Initials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return "";

            string[] parts = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string result = "";

            foreach (string part in parts)
            {
                if (part.Length > 0)
                {
                    result += char.ToUpper(part[0]) + ". ";
                }
            }

            return result.Trim(); // Убираем последний лишний пробел
        }

        // 4. Повторение строки n раз через StringBuilder
        public static string Repeat(string s, int n)
        {
            if (string.IsNullOrEmpty(s) || n <= 0)
                return "";

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
    }
}
