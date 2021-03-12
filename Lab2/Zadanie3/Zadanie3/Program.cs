using System;
using System.Globalization;
namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            string Language = "en-US";
            Console.WriteLine("Choose language:\n1-English\n2-French\n3-Spanish\n4-Croatian\n5-Russian");
            char Answer = Console.ReadKey().KeyChar;
            int Choose = Convert.ToInt32(Answer-48);
            switch (Choose)
            {
                case 1: Language = "en-US"; break;
                case 2: Language = "fr-FR"; break;
                case 3: Language = "es-MX"; break;
                case 4: Language = "hr-BA"; break;
                case 5: Language = "ru-RU"; break;
                default: Language = "en-US"; break;
            }
            Console.Clear();
            DateTime OurData = new DateTime(2000, 1, 1);
            for (int i = 0; i < 12; i++)
            {
                Console.WriteLine(OurData.AddMonths(i).ToString("MMMM", CultureInfo.GetCultureInfo(Language)));
            }
            
        }
    }
}
