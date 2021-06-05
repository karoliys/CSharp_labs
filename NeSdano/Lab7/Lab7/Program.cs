using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fraction1 = new Fraction(12, 33);
            Console.WriteLine(fraction1.ToString());
            Console.WriteLine(fraction1.ToString("F"));
            Console.WriteLine(fraction1.ToString("D"));

            Fraction fraction2 = new Fraction(5, 3);
            Fraction fraction3 = fraction1 + fraction2;

            Console.WriteLine($"fraction1 + fraction2 " + fraction3.ToString("F"));
            fraction3 = fraction1 - fraction2;
            Console.WriteLine($"fraction1 - fraction2 " + fraction3.ToString("F"));
            fraction3 = fraction1 * fraction2;
            Console.WriteLine($"fraction1 * fraction2 " + fraction3.ToString("F"));
            fraction3 = fraction1 / fraction2;
            Console.WriteLine($"fraction1 / fraction2 " + fraction3.ToString("F"));

            Fraction fraction4;
            if (Fraction.TryParse("7/42", out fraction4))
            {
                Console.WriteLine($"Parsing 7/42 {fraction4.ToString()}");
            }

            double number = fraction4;
            int numberToInt = (int)fraction4;
            Console.WriteLine(number);
            Console.WriteLine(numberToInt);
        }
    }
}