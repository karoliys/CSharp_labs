using System;
namespace Zadanie2
{
    class Program
    {
        static double SixteenToTen(string Num)
        {
            string Number = Num.ToUpper();
            char Symbol = ' ';
            double sum = 0;
            int SixteenInt = 0;
            if ((Number[0] == '-' || Number[0] == '+'))
            {
                Symbol = Number[0];
                Number = Number.Substring(1);
            }
            for (int i = 0; i < Number.Length; i++)
            {
                switch (Number[i])
                {
                    case '0': SixteenInt = 0; break;
                    case '1': SixteenInt = 1; break;
                    case '2': SixteenInt = 2; break;
                    case '3': SixteenInt = 3; break;
                    case '4': SixteenInt = 4; break;
                    case '5': SixteenInt = 5; break;
                    case '6': SixteenInt = 6; break;
                    case '7': SixteenInt = 7; break;
                    case '8': SixteenInt = 8; break;
                    case '9': SixteenInt = 9; break;
                    case 'A': SixteenInt = 10; break;
                    case 'B': SixteenInt = 11; break;
                    case 'C': SixteenInt = 12; break;
                    case 'D': SixteenInt = 13; break;
                    case 'E': SixteenInt = 14; break;
                    case 'F': SixteenInt = 15; break;
                    default: break;
                }
                sum = sum + SixteenInt * Math.Pow(16, Number.Length - 1 - i);
            }
            if (Symbol == '-')
            {
                return 0 - sum;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            string EnteredLine = Console.ReadLine();
            string[] ArrayLine = EnteredLine.Split(' ');
            bool IsHex = false;
            for (int i = 0; i < ArrayLine.Length; i++)
            {
                IsHex = false;
                for (int j = 0; j < ArrayLine[i].Length; j++)
                {
                    if ((ArrayLine[i][j] == '-' || ArrayLine[i][j] == '+') && j == 0)
                    {
                        break;
                    }
                    if ((ArrayLine[i][j] < '0') || (ArrayLine[i][j] > '9' && ArrayLine[i][j] < 'A') || (ArrayLine[i][j] > 'F' && ArrayLine[i][j] < 'a') || (ArrayLine[i][j] > 'f'))
                    {
                        IsHex = true;
                        break;
                    }
                }
                if (!IsHex)
                {
                    Console.WriteLine("Hex " + ArrayLine[i] + " is " + SixteenToTen(ArrayLine[i]));
                }
            }
        }
    }
}
