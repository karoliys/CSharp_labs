using System;
namespace Zadanie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string EnteredLine = Console.ReadLine();
            string[] ArrayLine = EnteredLine.Split(' ');
            for (int i = ArrayLine.Length - 1; i >= 0 ; i--)
            {
                Console.Write(ArrayLine[i] + " ");
            }
        }
    }
}
