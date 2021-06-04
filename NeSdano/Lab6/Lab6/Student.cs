using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Student : Human
    {
        public enum TuitionFees 
        {
           StateEmployee,
           Payer,
        }
        protected int Course;
        protected string University; 
        protected string GradeBook;
        protected TuitionFees tuitionFees;
        public Student()
        {
            Course = 1;
        }
        public Student(string name, string lastName, string nationality, string sex, string religion, int age, int course, string university, string gradeBook) : base (name, lastName, nationality, sex, religion, age)
        {
            Course = course;
            University = university;
            GradeBook = gradeBook;
        }
        public override void Status()
        {
            Console.WriteLine("student is not distributed");
            Console.ReadKey();
        }
        public void ChooseFees(TuitionFees tuitionFees)
        {
            this.tuitionFees = tuitionFees;
        }
        public void SetScoreCT() 
        {
            bool exit = true;
            int CT;
            CT = Human.SetForInt(Console.ReadLine());
            while (exit)
            {
                if (0 <= CT && CT <= 300)
                {
                    SummScoreCT = CT;
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Retry: CT{0;300} = ");
                    CT = Human.SetForInt(Console.ReadLine());
                }
            }
        
            
        }
        public void SetAttestat() 
        {
            Console.Clear();
            bool exit = true;
            double Attestat = Human.SetForInt(Console.ReadLine());
            while (exit)
            {
                if (Attestat <= 10 && Attestat > 0)
                {
                    AverageAtestat = Attestat;
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Retry: Attestat{0;10} = ");
                    Attestat = Human.SetForInt(Console.ReadLine());
                }
            }

        }
        public void SeeScore() 
        {
            Console.WriteLine(SummScoreCT + AverageAtestat * 10);
        }
        public override void MethodsInvocation()
        {
            bool retry = true;
            while (retry)
            {
                Console.Clear();
                Console.WriteLine("What you need: \n1-Show info\n2-Change Info\n3-Static Element\n4-Happy Birthday\n 5-Status\n6-SetCT and Attestat\nAnother Exit");
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
                    case '6': SetScoreCT(); SetAttestat(); break;
                    default:
                        retry = false;
                        break;
                }
            }

        }
    }
}
