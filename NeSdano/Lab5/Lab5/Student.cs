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
        }
        public void ChooseFees(TuitionFees tuitionFees)
        {
            this.tuitionFees = tuitionFees;
        }
        public override void MethodsInvocation()
        {
            bool retry = true;
            while (retry)
            {
                Console.Clear();
                Console.WriteLine("What you need: \n1-Show info\n2-Change Info\n3-Static Element\n4-Happy Birthday\n 5-Status \nAnother Exit");
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
                    default:
                        retry = false;
                        break;
                }
            }

        }
    }
}
