using System;
using MathLibrary1;

namespace Math
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("   ТЕСТИРОВАНИЕ MATH LIBRARY");
            Console.WriteLine("========================================\n");

            TestPower();
            TestFactorial();
            TestSolveQuadratic();

            Console.WriteLine("\n========================================");
            Console.WriteLine("   ТЕСТИРОВАНИЕ ЗАВЕРШЕНО");
            Console.WriteLine("========================================");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        static void TestPower()
        {
            Console.WriteLine("\n=== ТЕСТИРОВАНИЕ МЕТОДА POWER (Возведение в степень) ===\n");

            try
            {
                // Стандартные случаи
                Console.WriteLine("Стандартные случаи:");
                PrintPowerResult(2, 3);      // 2^3 = 8
                PrintPowerResult(5, 2);      // 5^2 = 25
                PrintPowerResult(10, 1);     // 10^1 = 10
                PrintPowerResult(7, 0);      // 7^0 = 1

                // Дробные основания
                Console.WriteLine("\nДробные основания:");
                PrintPowerResult(2.5, 2);    // 2.5^2 = 6.25
                PrintPowerResult(1.5, 3);    // 1.5^3 = 3.375

                // Отрицательные степени
                Console.WriteLine("\nОтрицательные степени:");
                PrintPowerResult(2, -1);     // 2^(-1) = 0.5
                PrintPowerResult(4, -2);      // 4^(-2) = 0.0625

                // Отрицательные основания
                Console.WriteLine("\nОтрицательные основания:");
                PrintPowerResult(-2, 3);      // (-2)^3 = -8
                PrintPowerResult(-2, 2);      // (-2)^2 = 4
                PrintPowerResult(-2, -1);     // (-2)^(-1) = -0.5
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при тестировании Power: {ex.Message}");
            }
        }

        static void PrintPowerResult(double baseNum, int exponent)
        {
            try
            {
                double result = MathLibrary1.MathFunctions.Power(baseNum, exponent);
                Console.WriteLine($"{baseNum}^{exponent} = {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{baseNum}^{exponent} - Ошибка: {ex.Message}");
            }
        }

        static void TestFactorial()
        {
            Console.WriteLine("\n=== ТЕСТИРОВАНИЕ МЕТОДА FACTORIAL ===\n");

            try
            {
                // Положительные числа
                Console.WriteLine("Факториалы положительных чисел:");
                int[] testNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                foreach (int n in testNumbers)
                {
                    try
                    {
                        long result = MathLibrary1.MathFunctions.Factorial(n);
                        Console.WriteLine($"{n}! = {result:N0}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"{n}! - Ошибка: {ex.Message}");
                    }
                }

                // Тест с большим числом (должен вызвать переполнение или исключение)
                Console.WriteLine("\nТест с большим числом (должен вызвать исключение):");
                try
                {
                    long result = MathLibrary1.MathFunctions.Factorial(100);
                    Console.WriteLine($"100! = {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ожидаемая ошибка при 100!: {ex.Message}");
                }

                // Тест с отрицательным числом (должен вызвать исключение)
                Console.WriteLine("\nТест с отрицательным числом (должен вызвать исключение):");
                try
                {
                    long result = MathLibrary1.MathFunctions.Factorial(-5);
                    Console.WriteLine($"(-5)! = {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ожидаемая ошибка при -5!: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при тестировании Factorial: {ex.Message}");
            }
        }

        static void TestSolveQuadratic()
        {
            Console.WriteLine("\n=== ТЕСТИРОВАНИЕ МЕТОДА SOLVE QUADRATIC (Квадратные уравнения) ===\n");

            try
            {
                // Тест 1: Два различных корня
                Console.WriteLine("1. Уравнение: x² - 3x + 2 = 0 (ожидаем корни 1 и 2)");
                TestQuadraticEquation(1, -3, 2);

                // Тест 2: Один корень (дискриминант = 0)
                Console.WriteLine("\n2. Уравнение: x² - 2x + 1 = 0 (ожидаем один корень x = 1)");
                TestQuadraticEquation(1, -2, 1);

                // Тест 3: Нет действительных корней
                Console.WriteLine("\n3. Уравнение: x² + x + 1 = 0 (ожидаем нет действительных корней)");
                TestQuadraticEquation(1, 1, 1);

                // Тест 4: Уравнение с отрицательным дискриминантом
                Console.WriteLine("\n4. Уравнение: x² + 4 = 0 (ожидаем нет действительных корней)");
                TestQuadraticEquation(1, 0, 4);

                // Тест 5: Уравнение с дробными коэффициентами
                Console.WriteLine("\n5. Уравнение: 2.5x² - 3.5x + 1 = 0");
                TestQuadraticEquation(2.5, -3.5, 1);

                // Тест 6: Не квадратное уравнение (a = 0)
                Console.WriteLine("\n6. Уравнение: 0x² + 2x - 3 = 0 (должно вызвать исключение)");
                try
                {
                    TestQuadraticEquation(0, 2, -3);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"   Ожидаемая ошибка: {ex.Message}");
                }

                // Тест 7: Очень большие коэффициенты
                Console.WriteLine("\n7. Уравнение с большими коэффициентами: 1000x² - 5000x + 6000 = 0");
                TestQuadraticEquation(1000, -5000, 6000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при тестировании SolveQuadratic: {ex.Message}");
            }
        }

        static void TestQuadraticEquation(double a, double b, double c)
        {
            try
            {
                Console.WriteLine($"   {a:F2}x² + {b:F2}x + {c:F2} = 0");

                var result = MathLibrary1.MathFunctions.SolveQuadratic(a, b, c);

                switch (result.RootCount)
                {
                    case 2:
                        Console.WriteLine($"   Два действительных корня: x₁ = {result.X1:F4}, x₂ = {result.X2:F4}");
                        // Проверка подстановкой
                        Console.WriteLine($"   Проверка: a*x₁² + b*x₁ + c = {a * result.X1 * result.X1 + b * result.X1 + c:F6}");
                        Console.WriteLine($"   Проверка: a*x₂² + b*x₂ + c = {a * result.X2 * result.X2 + b * result.X2 + c:F6}");
                        break;
                    case 1:
                        Console.WriteLine($"   Один действительный корень: x = {result.X1:F4}");
                        Console.WriteLine($"   Проверка: a*x² + b*x + c = {a * result.X1 * result.X1 + b * result.X1 + c:F6}");
                        break;
                    case 0:
                        Console.WriteLine($"   Нет действительных корней");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"   Ошибка: {ex.Message}");
            }
        }
    }
}