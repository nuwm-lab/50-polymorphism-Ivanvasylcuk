using System;

namespace Std
{
    // 🔹 Базовий клас — півплощина
    public class Halfplane
    {
        protected double a1, a2, b;

        public Halfplane() { }

        public Halfplane(double a1, double a2, double b)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.b = b;
        }

        // 🔸 Віртуальні методи
        public virtual void SetCoefficients()
        {
            Console.Write("Введіть a1: ");
            a1 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть a2: ");
            a2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть b: ");
            b = double.Parse(Console.ReadLine() ?? "0");
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Півплощина: {a1} * x1 + {a2} * x2 <= {b}");
        }

        public virtual void CheckPoint()
        {
            Console.WriteLine("\nВведіть координати точки:");
            Console.Write("x1 = ");
            double x1 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("x2 = ");
            double x2 = double.Parse(Console.ReadLine() ?? "0");

            double left = a1 * x1 + a2 * x2;
            if (left <= b)
                Console.WriteLine("✅ Точка належить півплощині.");
            else
                Console.WriteLine("❌ Точка не належить півплощині.");
        }
    }

    // 🔹 Похідний клас — півпростір
    public class Pivprostir : Halfplane
    {
        private double a3;

        public Pivprostir() { }

        public Pivprostir(double a1, double a2, double a3, double b)
            : base(a1, a2, b)
        {
            this.a3 = a3;
        }

        // 🔸 Перевизначення віртуальних методів
        public override void SetCoefficients()
        {
            Console.Write("Введіть a1: ");
            a1 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть a2: ");
            a2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть a3: ");
            a3 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть b: ");
            b = double.Parse(Console.ReadLine() ?? "0");
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Півпростір: {a1} * x1 + {a2} * x2 + {a3} * x3 <= {b}");
        }

        public override void CheckPoint()
        {
            Console.WriteLine("\nВведіть координати точки:");
            Console.Write("x1 = ");
            double x1 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("x2 = ");
            double x2 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("x3 = ");
            double x3 = double.Parse(Console.ReadLine() ?? "0");

            double left = a1 * x1 + a2 * x2 + a3 * x3;
            if (left <= b)
                Console.WriteLine("✅ Точка належить півпростору.");
            else
                Console.WriteLine("❌ Точка не належить півпростору.");
        }
    }

    // 🔹 Програма для демонстрації динамічного поліморфізму
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Оберіть об’єкт:\n1 — Півплощина\n2 — Півпростір");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            // 🔸 Базовий покажчик
            Halfplane obj;

            if (choice == 1)
                obj = new Halfplane();
            else
                obj = new Pivprostir();

            // 🔸 Виклики через базовий клас
            obj.SetCoefficients();
            obj.PrintCoefficients();
            obj.CheckPoint();

            Console.WriteLine("\nПрограма завершена.");
        }
    }
}
