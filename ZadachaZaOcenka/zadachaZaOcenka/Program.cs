using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using zadachaZaOcenka;


namespace zadachaZaOcenka
{
    
    class Program
    {
        static List<ITeacher> teachers = new List<ITeacher>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Въвеждане на данни за учител");
                Console.WriteLine("2. Извеждане на информацията за всички учители");
                Console.WriteLine("3. Извеждане на информацията за учител по зададено име");
                Console.WriteLine("4. Извеждане на броя на учителите, преподаващи определен предмет");
                Console.WriteLine("5. Извеждане на данните на учителите, преподаващи на най-малките класове");
                Console.WriteLine("6. Сортиране на данните по клас");
                Console.WriteLine("0. Изход");

                Console.Write("Изберете опция: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddTeacher();
                        break;
                    case "2":
                        DisplayAllTeachers();
                        break;
                    case "3":
                        SearchTeacherByName();
                        break;
                    case "4":
                        CountTeachersBySubject();
                        break;
                    case "5":
                        DisplayTeachersForLowestClasses();
                        break;
                    case "6":
                        SortTeachersByClass();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Невалидна опция. Моля, изберете отново.");
                        break;
                }

                Console.WriteLine();
            }
        }

        static void AddTeacher()
        {
            Console.WriteLine("Добавяне на учител:");
            Console.Write("Име на учителя: ");
            string name = Console.ReadLine();
            Console.Write("Училище: ");
            string school = Console.ReadLine();
            Console.Write("Класове (разделени със запетаи): ");
            List<string> classes = Console.ReadLine().Split(',').Select(c => c.Trim()).ToList();
            Console.Write("Предмет: ");
            string subject = Console.ReadLine();
            Console.Write("Договор (0 - безсрочен, 1 - срочен): ");
            int contractType = int.Parse(Console.ReadLine());

            ContractType contract = contractType == 0 ? ContractType.Permanent : ContractType.FixedTerm;

            if (contract == ContractType.FixedTerm)
            {
                Console.Write("Крайна дата на договора (във формат dd/mm/yyyy): ");
                DateTime contractEndDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                teachers.Add(new FixedTermTeacher(name, school, classes, subject, contractEndDate));
            }
            else
            {
                teachers.Add(new PermanentTeacher(name, school, classes, subject));
            }

            Console.WriteLine("Учителят е добавен успешно.");
        }

        static void DisplayAllTeachers()
        {
            Console.WriteLine("Информация за всички учители:");

            foreach (var teacher in teachers)
            {
                Console.WriteLine("Име: " + teacher.Name);
                Console.WriteLine("Училище: " + teacher.School);
                Console.WriteLine("Класове: " + string.Join(", ", teacher.Classes));
                Console.WriteLine("Предмет: " + teacher.Subject);
                Console.WriteLine("Договор: " + teacher.Contract);

                if (teacher.Contract == ContractType.FixedTerm)
                {
                    FixedTermTeacher fixedTermTeacher = (FixedTermTeacher)teacher;
                    Console.WriteLine("Крайна дата на договора: " + fixedTermTeacher.ContractEndDate.ToString("dd/MM/yyyy"));
                }

                Console.WriteLine();
            }
        }

        static void SearchTeacherByName()
        {
            Console.Write("Въведете име на учителя: ");
            string name = Console.ReadLine();

            var teacher = teachers.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (teacher != null)
            {
                Console.WriteLine("Име: " + teacher.Name);
                Console.WriteLine("Училище: " + teacher.School);
                Console.WriteLine("Класове: " + string.Join(", ", teacher.Classes));
                Console.WriteLine("Предмет: " + teacher.Subject);
                Console.WriteLine("Договор: " + teacher.Contract);

                if (teacher.Contract == ContractType.FixedTerm)
                {
                    FixedTermTeacher fixedTermTeacher = (FixedTermTeacher)teacher;
                    Console.WriteLine("Крайна дата на договора: " + fixedTermTeacher.ContractEndDate.ToString("dd/MM/yyyy"));
                }
            }
            else
            {
                Console.WriteLine("Учител с това име не е намерен.");
            }
        }

        static void CountTeachersBySubject()
        {
            Console.Write("Въведете предмет: ");
            string subject = Console.ReadLine();

            int count = teachers.Count(t => t.IsTeachingSubject(subject));

            Console.WriteLine("Брой на учителите, преподаващи {0}: {1}", subject, count);
        }

        static void DisplayTeachersForLowestClasses()
        {
            List<ITeacher> lowestClassTeachers = teachers.Where(t => t.Classes.Any(c => c.StartsWith("Class 1"))).ToList();

            Console.WriteLine("Информация за учителите, преподаващи на най-малките класове:");

            foreach (var teacher in lowestClassTeachers)
            {
                Console.WriteLine("Име: " + teacher.Name);
                Console.WriteLine("Училище: " + teacher.School);
                Console.WriteLine("Класове: " + string.Join(", ", teacher.Classes));
                Console.WriteLine("Предмет: " + teacher.Subject);
                Console.WriteLine("Договор: " + teacher.Contract);

                if (teacher.Contract == ContractType.FixedTerm)
                {
                    FixedTermTeacher fixedTermTeacher = (FixedTermTeacher)teacher;
                    Console.WriteLine("Крайна дата на договора: " + fixedTermTeacher.ContractEndDate.ToString("dd/MM/yyyy"));
                }

                Console.WriteLine();
            }
        }

        static void SortTeachersByClass()
        {
            var sortedTeachers = teachers.OrderBy(t => t.Classes.First()).ToList();

            Console.WriteLine("Сортирани данни по клас:");

            foreach (var teacher in sortedTeachers)
            {
                Console.WriteLine("Име: " + teacher.Name);
                Console.WriteLine("Училище: " + teacher.School);
                Console.WriteLine("Класове: " + string.Join(", ", teacher.Classes));
                Console.WriteLine("Предмет: " + teacher.Subject);
                Console.WriteLine("Договор: " + teacher.Contract);

                if (teacher.Contract == ContractType.FixedTerm)
                {
                    FixedTermTeacher fixedTermTeacher = (FixedTermTeacher)teacher;
                    Console.WriteLine("Крайна дата на договора: " + fixedTermTeacher.ContractEndDate.ToString("dd/MM/yyyy"));
                }

                Console.WriteLine();
            }
        }
    }
}
