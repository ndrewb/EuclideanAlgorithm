using System;
using System.IO;

namespace EuclideanAlgorithm
{
    public class Euclidean
    {
        public Euclidean(int num1, int num2)
        {
            Num1 = num1;
            Num2 = num2;
            Gcd = CalculateGcd(Num1, Num2);
        }

        public Euclidean(string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    Num1 = int.Parse(lines[0]);
                    Num2 = int.Parse(lines[1]);
                    Gcd = CalculateGcd(Num1, Num2);
                }
                else
                {
                    throw new ArgumentException("Файл должен содержать хотя бы две строки с числами.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }
        }

        public int Num1 { get; }
        public int Num2 { get; }
        public int Gcd { get; }

        private int CalculateGcd(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }

            return Math.Abs(a);
        }
    }
}