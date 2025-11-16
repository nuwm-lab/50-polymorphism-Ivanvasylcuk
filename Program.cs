using System;
using System.Globalization;

namespace Geometry
{
    public class HalfPlane
    {
        protected double _a1, _a2, _b;

        public double A1
        {
            get => _a1;
            set => _a1 = value;
        }

        public double A2
        {
            get => _a2;
            set => _a2 = value;
        }

        public double B
        {
            get => _b;
            set => _b = value;
        }

        public HalfPlane() { }

        public HalfPlane(double a1, double a2, double b)
        {
            _a1 = a1;
            _a2 = a2;
            _b = b;
        }

        protected double ReadDouble(string message)
        {
            double value;
            Console.Write(message);
            while (!double.TryParse(Console.ReadLine(), NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                Console.Write("Помилка! Введіть коректне число: ");
            }
            return value;
        }

        public virtual void SetCoefficients()
        {
            _a1 = ReadDouble("Введіть a1: ");
            _a2 = ReadDouble("Введіть a2: ");
            _b = ReadDouble("Введіть b: ");
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Півплощина: {_a1} * x1 + {_a2} * x2 <= {_b}");
        }

        public virtual void CheckPoint()
        {
            Console.WriteLine("\nВведіть координати точки:");
            double x1 = ReadDouble("x1 = ");
            double x2 = ReadDouble("x2 = ");

            double left = _a1 * x1 + _a2 * x2;
            if (left <= _b)
                Console.WriteLine("Точка належить півплощині.");
            else
                Console.WriteLine("Точка не належить півплощині.");
        }

    }

    public class HalfSpace : HalfPlane
    {
        private double _a3;

        public double A3
        {
            get => _a3;
            set => _a3 = value;
        }

        public HalfSpace() { }

        public HalfSpace(double a1, double a2, double a3, double b)
            : base(a1, a2, b)
        {
            _a3 = a3;
        }

        public override void SetCoefficients()
        {
            _a1 = ReadDouble("Введіть a1: ");
            _a2 = ReadDouble("Введіть a2: ");
            _a3 = ReadDouble("Введіть a3: ");
            _b = ReadDouble("Введіть b: ");
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Півпростір: {_a1} * x1 + {_a2} * x2 + {_a3} * x3 <= {_b}");
        }

        public override void CheckPoint()
        {
            Console.WriteLine("\nВведіть координати точки:");
            double x1 = ReadDouble("x1 = ");
            double x2 = ReadDouble("x2 = ");
            double x3 = ReadDouble("x3 = ");

            double left = _a1 * x1 + _a2 * x2 + _a3 * x3;
            if (left <= _b)
                Console.WriteLine("Точка належить півпростору.");
            else
                Console.WriteLine("Точка не належить півпростору.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Оберіть об’єкт:\n1 — Півплощина\n2 — Півпростір");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.Write("Помилка! Введіть 1 або 2: ");
            }

            HalfPlane obj = choice == 1 ? new HalfPlane() : new HalfSpace();

            obj.SetCoefficients();
            obj.PrintCoefficients();
            obj.CheckPoint();

            Console.WriteLine("\nПрограма завершена.");
        }
    }
}
