using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    struct MarksOfBsuir
    {
        public int[] MMA;
        public int[] OAIP;
        public int[] ISP;
        MarksOfBsuir(int oine)
        {
            MMA = new int[0];
            OAIP = new int[0];
            ISP = new int[0];
        }
        public void ShowMark() 
        {
            if (MMA != null)
            {
                Console.Write("MMA: ");
                for (int i = 0; i < MMA.Length; i++)
                {
                    Console.Write(MMA[i] + " ");
                }
            }
            Console.WriteLine();
            if (OAIP != null)
            {
                Console.Write("OAIP: ");
                for (int i = 0; i < OAIP.Length; i++)
                {
                    Console.Write(OAIP[i] + " ");
                }
            }
            Console.WriteLine();
            if (ISP != null)
            {
                Console.Write("ISP: ");
                for (int i = 0; i < ISP.Length; i++)
                {
                    Console.Write(ISP[i] + " ");
                }
            }
            Console.WriteLine();
        }
        public void RandMark(ref int[] predmet) 
        {
            Random random = new Random();
            if (predmet != null)
            {
                Array.Resize(ref predmet, predmet.Length + 1);
                predmet[predmet.Length - 1] = random.Next(4,10);
            }
            else
            {
                predmet = new int[1];
                predmet[0] = random.Next(4,10);
            }

        }
    }
    class SpecStudent : Student
    {
        private MarksOfBsuir marks = new MarksOfBsuir();
        private string Faculty;
        private string Spec;
        public override void Status()
        {
            Console.WriteLine("student is in faculty:" + Faculty + " and specialization: " + Spec);
        }
        public SpecStudent() { }
        public SpecStudent(string name, string lastName, string nationality, string sex, string religion, int age, int course, string university, string gradeBook, string faculty , string spec) : base(name, lastName, nationality, sex, religion, age, course, university, gradeBook)
        {
            Faculty = faculty;
            Spec = spec;
        }
        public void ShowMark()
        {
            marks.ShowMark();
            Console.ReadKey();
        }
        public void RandMarks() 
        {
            for (int i = 0; i < 10; i++)
            {
                marks.RandMark(ref marks.MMA);
                marks.RandMark(ref marks.OAIP);
                marks.RandMark(ref marks.ISP);
            }
        }
        public override void MethodsInvocation()
        {
            bool retry = true;
            while (retry)
            {
                Console.Clear();
                Console.WriteLine("What you need: \n1-Show info\n2-Change Info\n3-Static Element\n4-Happy Birthday\n5-Status \n6-Add 10 random marks \n7- Show marks\nAnother Exit");
                char answer = Console.ReadKey().KeyChar;
                switch (answer)
                {
                    case '1': ShowInfo(); Console.ReadKey(); break;
                    case '2':
                        Console.WriteLine("What change? (Name,LastName,Sex,Religion,Nationality)");
                        string Answer = Console.ReadLine();
                        Console.WriteLine("Change to: ");
                        string Value = Console.ReadLine();
                        SetVariable(ref Value, Answer);
                        break;
                    case '4': HappyBirthday(); break;
                    case '3': ShowStaticElements(); break;
                    case '5': Status(); break;
                    case '7': ShowMark(); break;
                    case '6': RandMarks(); break;
                    default:
                        retry = false;
                        break;
                }
            }

        }

    }
}
