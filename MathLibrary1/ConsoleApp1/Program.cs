using MathLibrary1;
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== Демонстрация работы MathLibrary.dll ==\n");

            double x = 10, y = 4;

            // Базовые операции
            Console.WriteLine("=== Базовые операции ===");
            Console.WriteLine($"Сложение: {x} + {y} = {Calculator.Add(x, y)}");
            Console.WriteLine($"Вычитание: {x} - {y} = {Calculator.Subtract(x, y)}");
            Console.WriteLine($"Умножение: {x} * {y} = {Calculator.Multiply(x, y)}");

            // Деление с обработкой ошибки
            try
            {
                Console.WriteLine($"Деление: {x} / {y} = {Calculator.Divide(x, y)}");
                Console.WriteLine($"Попытка деления на ноль: {x} / 0 = {Calculator.Divide(x, 0)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка при делении: {ex.Message}");
            }

            // Проверка на простоту
            Console.WriteLine("\n=== Проверка на простоту ===");
            int testNumber = 17;
            Console.WriteLine($"Число {testNumber} простое? {Calculator.IsPrime(testNumber)}");
            testNumber = 20;
            Console.WriteLine($"Число {testNumber} простое? {Calculator.IsPrime(testNumber)}");

            // Возведение в степень
            Console.WriteLine("\n=== Возведение в степень ===");
            Console.WriteLine($"{x} в степени {y} = {Calculator.Power(x, y)}");
            Console.WriteLine($"2 в степени 10 = {Calculator.Power(2, 10)}");

            // Факториал
            Console.WriteLine("\n=== Факториал ===");
            int factNumber = 5;
            Console.WriteLine($"Факториал числа {factNumber} = {Calculator.Factorial(factNumber)}");

            try
            {
                Console.WriteLine($"Факториал числа -1 = {Calculator.Factorial(-1)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            // Решение квадратного уравнения
            Console.WriteLine("\n=== Решение квадратного уравнения ===");
            double a = 1, b = -3, c = 2;
            if (Calculator.SolveQuadratic(a, b, c, out double? root1, out double? root2))
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет корни: x1 = {root1}, x2 = {root2}");
            }
            else
            {
                Console.WriteLine("Действительных корней нет");
            }

            // Уравнение с отрицательным дискриминантом
            a = 1; b = 0; c = 1;
            if (Calculator.SolveQuadratic(a, b, c, out root1, out root2))
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет корни: x1 = {root1}, x2 = {root2}");
            }
            else
            {
                Console.WriteLine("Уравнение x^2 + 1 = 0 не имеет действительных корней");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}