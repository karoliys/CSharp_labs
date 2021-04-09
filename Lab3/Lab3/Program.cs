using System;

namespace Lab3
{
    enum AgeCategory
    {
        Baby,
        Child,
        Teenager,
        Adult,
        Elderly
    }
    enum HeirLeugthPeople
    {
        SquareHeir,
        UsualHeir,
        LongHeir
    }
    class Human
    {
        public Human(string name, string lastName, string nationality, string sex, string religion, int age, int hairLength, int earnings)
        {
            this.name = name;
            this.lastName = lastName;
            this.nationality = nationality;
            this.sex = sex;
            this.religion = religion;
            this.earnings = earnings;
            this.age = age;
            this.hairLength = hairLength;
            AssignAgeCategory();
            AssignHeirLeugthPeople();
        }
        public Human()
        {

        }
        protected string name;
        protected string lastName;
        protected string nationality;
        protected string sex;
        protected string religion;
        protected int age;
        protected int earnings;
        protected int hairLength;
        protected AgeCategory ageCategory;
        protected HeirLeugthPeople heirLeugthPeople;
        static protected string[] body = { "head ", "eyes ", "hands ", "ears ", "legs" };
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public string Religion
        {
            get { return religion; }
            set { religion = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public int Earnings
        {
            get { return earnings; }
            set { earnings = value; }
        }
        public int HairLength
        {
            get { return hairLength; }
            set { hairLength = value; }
        }
        public static void CheckString(ref string str)
        {
            bool correctness;
            do
            {
                correctness = false;
                if (str.Length == 0)
                {
                    Console.Write("Empty line detected\n");
                    str = Console.ReadLine();
                    correctness = true;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsLetter(str[i]))
                    {
                        Console.Write("Use only characters \n");
                        str = Console.ReadLine();
                        correctness = true;
                        break;
                    }
                }
            } while (correctness);
            return;
        }
        public void AssignHeirLeugthPeople()
        {
            if (hairLength < 15)
            {
                heirLeugthPeople = HeirLeugthPeople.SquareHeir;
            }
            else if (hairLength >= 15 && hairLength < 30)
            {
                heirLeugthPeople = HeirLeugthPeople.UsualHeir;
            }
            else
            {
                heirLeugthPeople = HeirLeugthPeople.LongHeir;
            }
        }
        public void AssignAgeCategory()
        {
            if (age <= 3 && age > 0)
            {
                ageCategory = AgeCategory.Baby;
            }
            else if (age > 3 && age <= 12)
            {
                ageCategory = AgeCategory.Child;
            }
            else if (age > 12 && age < 18)
            {
                ageCategory = AgeCategory.Teenager;
            }
            else if (age >= 18 && age < 60)
            {
                ageCategory = AgeCategory.Adult;
            }
            else if (age >= 60)
            {
                ageCategory = AgeCategory.Elderly;
            }
        }
        public static void CheckSex(ref string str)
        {
            str = str.ToUpper();
            bool correctness;
            do
            {
                correctness = false;
                if (str.Length == 0)
                {
                    Console.Write("Empty line detected\n");
                    str = Console.ReadLine();
                    correctness = true;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (!(str == "M" || str == "W"))
                    {
                        Console.Write("Use only 'M' or 'W' \n");
                        str = Console.ReadLine();
                        str = str.ToUpper();
                        correctness = true;
                        break;
                    }
                }
            } while (correctness);
        }
        public static int SetForInt(string str)
        {
            bool correctness;
            do
            {
                correctness = false;
                if (str.Length == 0)
                {
                    Console.Write("Empty line detected\n");
                    str = Console.ReadLine();
                    correctness = true;
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if (!(str[i] >= '0' && str[i] <= '9'))
                    {
                        Console.Write("Use only numbers \n");
                        str = Console.ReadLine();
                        correctness = true;
                        break;
                    }
                }
            } while (correctness);
            return Convert.ToInt32(str);
        }
        public void SetVariable(ref string value, string Variable)
        {

            switch (Variable)
            {
                case "Name": CheckString(ref value); name = value; break;
                case "LastName": CheckString(ref value); lastName = value; break;
                case "Nationality": CheckString(ref value); nationality = value; break;
                case "Sex": CheckSex(ref value); Sex = value; break;
                case "Religion": CheckString(ref value); religion = value; break;
                default: break;
            }
        }
        public void SetVariable(ref int value, string Variable)
        {
            switch (Variable)
            {
                case "Age": age = value; break;
                case "Earnings": earnings = value; break;
                default: break;
            }
        }
        public void ShowInfo()
        {
            Console.Clear();
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("LastName: " + LastName);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Sex: " + Sex);
            Console.WriteLine("Religion: " + Religion);
            Console.WriteLine("Nationality: " + Nationality);
            Console.WriteLine("Earnings: " + Earnings + "$");
            Console.WriteLine("Age Category:" + ageCategory);
            Console.WriteLine("Hair Length: " + heirLeugthPeople);
        }
        public void HappyBirthday()
        {
            age++;
            AssignAgeCategory();
        }
        public void Haircut()
        {
            hairLength = hairLength - 5;
            if (hairLength < 0)
            {
                hairLength = 0;
            }
            AssignHeirLeugthPeople();
        }
        public void ShowStaticElements() 
        {
            Console.Clear();
            Console.WriteLine("static body parts: ");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(body[i]);
            }
           
            Console.ReadKey();
        }
        public void MethodsInvocation()
        {
            bool retry = true;
            while (retry)
            {
                Console.Clear();
                Console.WriteLine("What you need: \n1-Show info\n2-Change Info\n3-Static Element\n4-Happy Birthday\n5-Cut Hair(-5sm)\n Another Exit");
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
                    case '5': Haircut(); break;
                    case '3': ShowStaticElements(); break;    
                    default:
                        retry = false;
                        break;
                }
            }

        }
    }
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
            Console.Write("Age = ");
            int Age = Human.SetForInt(Console.ReadLine());
            Console.Write("Hair Length = ");
            int HairLength = Human.SetForInt(Console.ReadLine());
            Human.CheckString(ref Nationality);
            Console.Write("Religion = ");
            string Religion = Console.ReadLine();
            Human.CheckString(ref Religion);
            Console.Write("Sex (M or W) = ");
            string Sex = Console.ReadLine();
            Human.CheckSex(ref Sex);
            Console.Write("Earnings($) = ");
            int Earnings = Human.SetForInt(Console.ReadLine());

            Human human = new Human(Name, LastName, Nationality, Sex, Religion, Age, HairLength, Earnings);
            return human;
        }
        static void Main(string[] args)
        {
            Human human = new Human();
            human = HumanInitialization();
            human.MethodsInvocation();
        }

    }
}
