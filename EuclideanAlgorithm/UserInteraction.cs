using System;
using System.IO;

namespace EuclideanAlgorithm
{
    public class UserInteraction
    {
        public void Start()
        {
            var continueProgram = true;

            while (continueProgram)
            {
                Console.Clear();
                Console.WriteLine("Выберите способ ввода данных:");
                Console.WriteLine("1 - Ввести числа вручную");
                Console.WriteLine("2 - Загрузить числа из файла");
                Console.WriteLine("0 - Выход из программы");

                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    var num1 = GetValidNumber("Введите первое число: ");
                    var num2 = GetValidNumber("Введите второе число: ");

                    var algorithm = new Euclidean(num1, num2);
                    Console.Clear();
                    Console.WriteLine($"НОД чисел {num1} и {num2} = {algorithm.Gcd}");
                }
                else if (choice == "2")
                {
                    Console.Write("Введите путь к файлу: ");
                    var filePath = Console.ReadLine();

                    if (File.Exists(filePath))
                    {
                        try
                        {
                            var algorithm = new Euclidean(filePath);

                            if (algorithm.Num1 != 0 || algorithm.Num2 != 0)
                            {
                                Console.Clear();
                                Console.WriteLine($"НОД чисел {algorithm.Num1} и {algorithm.Num2} = {algorithm.Gcd}");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Ошибка: Файл должен содержать хотя бы два числа.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.Clear();
                            Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ошибка: Файл не найден. Проверьте путь и попробуйте снова.");
                    }
                }
                else if (choice == "0")
                {
                    continueProgram = false;
                    Console.WriteLine("Завершение программы.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                }

                if (choice == "1" || choice == "2")
                {
                    Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                }
            }
        }

        private int GetValidNumber(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                var input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    return number;
                }

                Console.Clear();
                Console.WriteLine("Ошибка: Введено не число. Пожалуйста, попробуйте снова.");
            }
        }
    }
}