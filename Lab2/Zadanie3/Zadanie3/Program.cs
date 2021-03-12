using System;
using System.Globalization;
namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime OurData = new DateTime(2000, 1, 1);
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(OurData.AddMonths(i).ToString("MMMM", CultureInfo.GetCultureInfo("fr-FR")));
            }
            
        }
    }
}
