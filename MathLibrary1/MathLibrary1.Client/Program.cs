using MathLibrary; //клиентская часть программы
namespace MathLibrary1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация работы MathLibrary.dll\n");

            double x = 10, y = 4;

            Console.WriteLine("Базовые операции");
            Console.WriteLine($"Сложение: {x} + {y} = {Calculator.Add(x, y)}");
            Console.WriteLine($"Вычитание: {x} - {y} = {Calculator.Subtract(x, y)}");
            Console.WriteLine($"Умножение: {x} * {y} = {Calculator.Multiply(x, y)}");

            try
            {
                Console.WriteLine($"Деление: {x} / {y} = {Calculator.Divide(x, y)}");
                Console.WriteLine($"Попытка деления на ноль: {x} / 0 = {Calculator.Divide(x, 0)}");
            }
            catch (DivideByZeroException ex)
            {
                //Console.WriteLine($"Ошибка при делении: {ex.Message}");
            }
            Console.WriteLine("\nПроверка на простоту");
            int testNumber = 17;
            Console.WriteLine($"Число {testNumber} простое? {Calculator.IsPrime(testNumber)}");
            testNumber = 20;
            Console.WriteLine($"Число {testNumber} простое? {Calculator.IsPrime(testNumber)}");

            Console.WriteLine("\nВозведение в степень");
            Console.WriteLine($"{x} в степени {y} = {Calculator.Power(x, y)}");
            Console.WriteLine($"2 в степени 10 = {Calculator.Power(2, 10)}");

            Console.WriteLine("\nФакториал");
            int factNumber = 5;
            Console.WriteLine($"Факториал числа {factNumber} = {Calculator.Factorial(factNumber)}");

            try
            {
                Console.WriteLine($"Факториал числа -1 = {Calculator.Factorial(-1)}");
            }
            catch (ArgumentException ex)
            {
                //Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nРешение квадратного уравнения");
            double a = 1, b = -3, c = 2;
            if (Calculator.SolveQuadratic(a, b, c, out double? root1, out double? root2))
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет корни: x1 = {root1}, x2 = {root2}");
            }
            else
            {
                Console.WriteLine("Действительных корней нет");
            }

            a = 1; b = 0; c = 1;
            if (Calculator.SolveQuadratic(a, b, c, out root1, out root2))
            {
                Console.WriteLine($"Уравнение {a}x^2 + {b}x + {c} = 0 имеет корни: x1 = {root1}, x2 = {root2}");
            }
            else
            {
                Console.WriteLine("Уравнение x^2 + 1 = 0 не имеет действительных корней");
            }
            Console.WriteLine("\n=== 6. НОВЫЕ МАТЕМАТИЧЕСКИЕ ФУНКЦИИ ===");

            Console.WriteLine("\n--- Площадь круга ---");
            double[] radii = { 1, 2.5, 5, 10 };
            foreach (double radius in radii)
            {
                Console.WriteLine($"Площадь круга с радиусом {radius,4} = {Calculator.CalculateCircleArea(radius),8:F2}");
            }

            try
            {
                Console.WriteLine($"Площадь круга с радиусом -1 = {Calculator.CalculateCircleArea(-1)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\n--- Конвертация температур ---");
            double[] celsiusTemps = { -40, 0, 25, 37, 100 };
            Console.WriteLine("Цельсий -> Фаренгейт:");
            foreach (double celsius in celsiusTemps)
            {
                Console.WriteLine($"{celsius,5}°C = {Calculator.CelsiusToFahrenheit(celsius),6:F1}°F");
            }

            double[] fahrenheitTemps = { -40, 32, 77, 98.6, 212 };
            Console.WriteLine("\nФаренгейт -> Цельсий:");
            foreach (double fahrenheit in fahrenheitTemps)
            {
                Console.WriteLine($"{fahrenheit,6:F1}°F = {Calculator.FahrenheitToCelsius(fahrenheit),5:F1}°C");
            }

            Console.WriteLine("\n--- Расчет гипотенузы ---");
            (double aSide, double bSide)[] triangles = {
                (3, 4),
                (5, 12),
                (8, 15),
                (7, 24)
            };

            foreach (var triangle in triangles)
            {
                double hyp = Calculator.CalculateHypotenuse(triangle.aSide, triangle.bSide);
                Console.WriteLine($"Катеты: {triangle.aSide,2} и {triangle.bSide,2} => Гипотенуза = {hyp,5:F2}");
            }

            try
            {
                Console.WriteLine($"Попытка с отрицательными сторонами: {Calculator.CalculateHypotenuse(-3, 4)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\n==========================================");
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}