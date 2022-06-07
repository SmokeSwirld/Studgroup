using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studgroup
{
    internal class Student : IComparable 
    {
        internal string Name { get; set; } = "Some Name";

        internal string Surname { get; set; } = "Some Surname";

        internal string Telefhone { get; set; } = "Some Telefhone";

        internal DateTime Date { get; set; } =  DateTime.Parse("01.01.1988");

        internal int[] zachet = new int[5];

        internal int[] kursova = new int[5];

        internal int[] ekzamn = new int[5];
        public int CompareTo(object obj)
        {
            if (obj is Student student) return Name.CompareTo(student.Name);
            else throw new ArgumentException("Некорректное значение параметра");
        }
      
        public Student() { }

        public Student(string Name)
        {
            this.Name = Name;
            
        }
        public Student(string Name, string Surname)
        {
            this.Name = Name;
            this.Surname = Surname;
        }
        public Student(string Name, string Surname, DateTime Date, string Telefhone)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Date = Date;
            this.Telefhone = Telefhone;
        }
        public void Print() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Name);
            Console.WriteLine(Surname);
            Console.WriteLine(Telefhone);
            Console.ResetColor();
            Console.WriteLine(Date.ToShortDateString());
            Console.Write("zachet  : "); 
            for (int i = 0; i < zachet.Length; i++) 
            {
                Console.Write(zachet[i]);
                Console.Write(",");
            }
            Console.WriteLine();
            Console.Write("kursova : ");
            for (int i = 0; i < kursova.Length; i++)
            {
                Console.Write(kursova[i]);
                Console.Write(",");
            }
            Console.WriteLine();
            Console.Write("ekzamn  : ");
            for (int i = 0; i < ekzamn.Length; i++)
            {
                Console.Write(ekzamn[i]);
                Console.Write(",");
            }
            Console.WriteLine();
        }
       public class StudentComparerSurname : IComparer<Student>
        {
            public int Compare(Student p1, Student p2)
            {
                if (p1 is null || p2 is null)
                throw new ArgumentException("Некорректное значение параметра");
                return p1.Surname.CompareTo(p2.Surname); ;
            }
        }
        public class StudentComparerZachet : IComparer<Student>
        {
            public int Compare(Student p1, Student p2)
            {
                if (p1 is null || p2 is null)
                    throw new ArgumentException("Некорректное значение параметра");
                
                return p1.zachet[0].CompareTo(p2.zachet[0]); ;
            }
        }
    }
    internal class Group : IEnumerable
    {
        internal const int kol = 5;
        int position = -1;
        internal Student[] group = new Student[kol];

        public Student this[int index]
        {
            get
            {
                return group[index];
            }
            set
            {
                group[index] = value;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)GetEnumerator(); 
        }
        public bool MoveNext()
        {
            position++;
            return (position < group.Length);
        }
        internal string Namegroup { get; set; } = "Some NameGruop";

        public Group() 
        { 
            for (int i = 0; i < kol; i++) 
            {
                group[i]=new Student();
            }
            
        }
        public Group(string namegroup)
        {
            Namegroup = namegroup;
        }
    
        public void PrintGruop()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Namegroup);
            Console.Write("kol student : ");
            Console.WriteLine(kol);
            Console.ResetColor();
            for (int i = 0; i < kol; i++)
            {
                group[i].Print();
                Console.WriteLine("=====================");
            }
        }
    }
    
    
    internal class Program
    {
        static void Main(string[] args)
        {

           Student student = new Student();
           Student student1 = new Student();
           student.zachet[1] = 95;
            //  DateTime Date1  = DateTime.Parse("11.11.1999");
            //  Student st = new Student("Alex","G", Date1,"+38000-000-00-00");
            //  Console.WriteLine(st.Date.ToShortDateString());
            //  student.Print();
            Console.WriteLine(student.CompareTo(student1)); // 0 
            Console.WriteLine("=================================");

            Group group1 = new Group();
           // group1.PrintGruop();
            group1[1].Name = "Alex12";
            group1[2].Name = "Alex23";
            group1[3].Name = "Alex3";
            group1[4].Name = "Alex2";
            Array.Sort(group1.group);
            group1.PrintGruop();
            group1[1].Surname = "STRONG";
            group1[2].Surname = "SMALL";
            group1[3].Surname = "BIG";
            group1[4].Surname = "LITE";

            Array.Sort(group1.group, new Student.StudentComparerSurname());
            group1.PrintGruop();
            group1[1].zachet[0] = 90;
            group1[2].zachet[0] = 95;
            group1[3].zachet[0] = 80;
            group1[4].zachet[0] = 98;
            Array.Sort(group1.group, new Student.StudentComparerZachet());
            group1.PrintGruop();
            Group[] groups = new Group[3]
            {
                new Group(),
                new Group(),
                new Group(),
            };

            groups[0].MoveNext();
            foreach (Group p in groups) 
            {
                p.PrintGruop();
            }
        }
    }
}
