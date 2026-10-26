using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество секунд: ");
        string input = Console.ReadLine();

        // Защита от падения программы при некорректном вводе
        if (!int.TryParse(input, out int totalSeconds) || totalSeconds < 0)
        {
            Console.WriteLine("Ошибка: Некорректный ввод");
            return; 
        }

        // Расчет времени
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        // Вывод результата
        Console.WriteLine($"{hours} ч {minutes} мин {seconds} с");
    }
}
