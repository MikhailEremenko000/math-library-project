using System;
//основная часть программы
namespace MathLibrary
{
    public interface IBasicOperations
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
    }

    public interface IAdvancedOperations
    {
        bool IsPrime(int number);
        double Power(double number, double power);
        long Factorial(int n);
    }

    public interface IEquationSolver
    {
        bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2);
    }
    public class BasicOperations : IBasicOperations
    {
        public double Add(double a, double b) => a + b;

        public double Subtract(double a, double b) => a - b;

        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (Math.Abs(b) < double.Epsilon)
            {
                throw new DivideByZeroException("Делитель не может быть равен нулю.");
            }
            return a / b;
        }
    }

    public class AdvancedOperations : IAdvancedOperations
    {
        private const int SmallPrime = 2;
        private const int StartOddCheck = 3;

        public bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == SmallPrime) return true;
            if (number % SmallPrime == 0) return false;

            int boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = StartOddCheck; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        public double Power(double number, double power)
        {
            return Math.Pow(number, power);
        }

        public long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Факториал отрицательного числа не определен.");
            }

            if (n > 50)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "Факториал слишком велик для типа long.");
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                checked
                {
                    result *= i;
                }
            }
            return result;
        }
    }

    public class EquationSolver : IEquationSolver
    {
        private const double Epsilon = 1e-10;

        public bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
        {
            x1 = null;
            x2 = null;

            if (Math.Abs(a) < Epsilon)
            {
                throw new ArgumentException("Коэффициент a не может быть равен нулю в квадратном уравнении.", nameof(a));
            }

            double discriminant = b * b - 4 * a * c;

            if (discriminant < -Epsilon)
            {
                return false;
            }

            if (Math.Abs(discriminant) < Epsilon)
            {
                x1 = -b / (2 * a);
                x2 = x1;
            }
            else
            {
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                x1 = (-b + sqrtDiscriminant) / (2 * a);
                x2 = (-b - sqrtDiscriminant) / (2 * a);
            }

            return true;
        }
    }
    public static class MathFunctions
    {
        public static double Power(double baseNum, int exponent)
        {
            if (exponent == 0) return 1;

            double result = 1;
            int absExponent = Math.Abs(exponent);

            for (int i = 0; i < absExponent; i++)
            {
                result *= baseNum;
            }

            return exponent > 0 ? result : 1 / result;
        }

        public static long Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал отрицательного числа не определен");

            if (n > 20)
                throw new ArgumentException("Слишком большое число для вычисления факториала (макс. 20)");

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
        public static class Calculator
    {
        private static readonly BasicOperations Basic = new BasicOperations();
        private static readonly AdvancedOperations Advanced = new AdvancedOperations();
        private static readonly EquationSolver Solver = new EquationSolver();

        public static double Add(double a, double b) => Basic.Add(a, b);
        public static double Subtract(double a, double b) => Basic.Subtract(a, b);
        public static double Multiply(double a, double b) => Basic.Multiply(a, b);
        public static double Divide(double a, double b) => Basic.Divide(a, b);
        public static bool IsPrime(int number) => Advanced.IsPrime(number);
        public static double Power(double number, double power) => Advanced.Power(number, power);
        public static long Factorial(int n) => Advanced.Factorial(n);
        public static bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
            => Solver.SolveQuadratic(a, b, c, out x1, out x2);
    }
}