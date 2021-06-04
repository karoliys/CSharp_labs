﻿using System;
using System.Data;

namespace Lab3
{
    class Program
    {
        static Human HumanInitialization()
        {
            Console.Write("Name = ");
            string Name = Console.ReadLine();
            Human.CheckString(ref Name);
            Console.Write("LastName = ");
            string LastName = Console.ReadLine();
            Human.CheckString(ref LastName);
            Console.Write("Nationality = ");
            string Nationality = Console.ReadLine();
            Human.CheckString(ref Nationality);
            Console.Write("Age = ");
            int Age = Human.SetForInt(Console.ReadLine());
            Console.Write("Religion = ");
            string Religion = Console.ReadLine();
            Human.CheckString(ref Religion);
            Console.Write("Sex (M or W) = ");
            string Sex = Console.ReadLine();
            Human.CheckSex(ref Sex);

            Human human = new Human(Name, LastName, Nationality, Sex, Religion, Age);
            return human;
        }
        static Student StudentInitialization() 
        {
            Console.Write("Name = ");
            string Name = Console.ReadLine();
            Human.CheckString(ref Name);
            Console.Write("LastName = ");
            string LastName = Console.ReadLine();
            Human.CheckString(ref LastName);
            Console.Write("Nationality = ");
            string Nationality = Console.ReadLine();
            Human.CheckString(ref Nationality);
            Console.Write("Age = ");
            int Age = Human.SetForInt(Console.ReadLine());
            Console.Write("Religion = ");
            string Religion = Console.ReadLine();
            Human.CheckString(ref Religion);
            Console.Write("Sex (M or W) = ");
            string Sex = Console.ReadLine();
            Human.CheckSex(ref Sex);
            Console.Write("Course = ");
            int Course = Human.SetForInt(Console.ReadLine());
            Console.Write("University = ");
            string University = Console.ReadLine();
            Console.Write("GradeBook = ");
            string GradeBook = Console.ReadLine();

            Student student = new Student(Name, LastName, Nationality, Sex, Religion, Age, Course, University, GradeBook);
            return student;
        }
        static SpecStudent SpecStudentInitialization()
        {
            Console.Write("Name = ");
            string Name = Console.ReadLine();
            Human.CheckString(ref Name);
            Console.Write("LastName = ");
            string LastName = Console.ReadLine();
            Human.CheckString(ref LastName);
            Console.Write("Nationality = ");
            string Nationality = Console.ReadLine();
            Human.CheckString(ref Nationality);
            Console.Write("Age = ");
            int Age = Human.SetForInt(Console.ReadLine());
            Console.Write("Religion = ");
            string Religion = Console.ReadLine();
            Human.CheckString(ref Religion);
            Console.Write("Sex (M or W) = ");
            string Sex = Console.ReadLine();
            Human.CheckSex(ref Sex);
            Console.Write("Course = ");
            int Course = Human.SetForInt(Console.ReadLine());
            Console.Write("University = ");
            string University = Console.ReadLine();
            Console.Write("GradeBook = ");
            string GradeBook = Console.ReadLine();
            Console.Write("Faculte = ");
            string Faculte = Console.ReadLine();
            Console.Write("specialization = ");
            string Spec = Console.ReadLine();

            SpecStudent specStudent = new SpecStudent(Name, LastName, Nationality, Sex, Religion, Age, Course, University, GradeBook,Faculte, Spec);
            return specStudent;
        }
        static void Main(string[] args)
        {
            /* Human human = new Human();
            human = HumanInitialization();
            human.MethodsInvocation(); */

            Console.WriteLine("Create:\n1-Human\n2-Student\n3-SpecStudent\nAnother exit");
            switch (Console.ReadKey().KeyChar)
            {
                case '1':
                    Console.Clear();
                    Human human = new Human();
                    human = HumanInitialization();
                    human.MethodsInvocation(); 
                    break;
                case '2':
                    Console.Clear();
                    Student student = new Student();
                    student = StudentInitialization();
                    student.MethodsInvocation(); 
                    break;
                case '3':
                    Console.Clear();
                    SpecStudent BsuirStud = new SpecStudent();
                    BsuirStud = SpecStudentInitialization();
                    BsuirStud.MethodsInvocation();
                    break;
                default:break;
            }
            
        }

    }
}