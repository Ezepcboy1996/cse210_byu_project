using System;

namespace Week03Project
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test all constructors
            Fraction f1 = new Fraction();          // 1/1
            Fraction f2 = new Fraction(5);         // 5/1
            Fraction f3 = new Fraction(3, 4);      // 3/4
            Fraction f4 = new Fraction(1, 3);      // 1/3

            // Display results
            Console.WriteLine("Fraction f1: " + f1.GetFractionString() + " = " + f1.GetDecimalValue());
            Console.WriteLine("Fraction f2: " + f2.GetFractionString() + " = " + f2.GetDecimalValue());
            Console.WriteLine("Fraction f3: " + f3.GetFractionString() + " = " + f3.GetDecimalValue());
            Console.WriteLine("Fraction f4: " + f4.GetFractionString() + " = " + f4.GetDecimalValue());

            // Demonstrate setters
            f4.SetTop(2);
            f4.SetBottom(5);
            Console.WriteLine("Updated f4: " + f4.GetFractionString() + " = " + f4.GetDecimalValue());
        }
    }
}
