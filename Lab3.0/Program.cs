using Lab3._0;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Lab3.Company;

namespace Lab3
{
    internal class Program
    {
        static void WriteFileShowCase()
        {
            var Dis1 = new Discipline("ІПЗ", "", 100);
            var Dis2 = new Discipline("ППЗ", "", 100);
            var Dis3 = new Discipline("КПЗ", "", 100);
            var Dis4 = new Discipline("ККЗ", "", 100);

            var Stud1 = new Student("Egor", 1, 100, Dis1, 100);
            var Stud2 = new Student("Vlad", 1, 80, Dis1, 0);
            var Stud3 = new Student("Vova", 1, 100, Dis1, 100);
            var Stud4 = new Student("Bogdan", 1, 100, Dis1, 100);
            var Stud5 = new Student("Dima", 1, 80, Dis1, 0);
            var Stud6 = new Student("Anya", 1, 100, Dis1, 100);

            var Dep1 = new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });
            var Dep2 = new Department("FKS", 100, 3, 6, new List<Student> { Stud4, Stud5, Stud6 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });

            var Employee1 = new Employee("Employee1", 1000, false, Dis1);
            var Employee2 = new Employee("Employee2", 1000, true, Dis1);
            var Employee3 = new Employee("Employee3", 1000, true, Dis1);
            var Employee4 = new Employee("Employee4", 1000, true, Dis4);

            //Invest amount 

            var Dic = new Dictionary<Department, double>
            {
                { Dep1, 1000000000.05 },
                { Dep2, 1000000.0001 }
            };

            var Vacancies = new List<Tuple<string, VacanciesTypes>>
            {
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip)
            };

            var Company1 = new Company("PonySoftware", 100000000, Vacancies, new List<Employee>() { Employee1, Employee2, Employee3 }, Dic, new Dictionary<Discipline, double>
            {
                { Dis1, 99.00 },
                { Dis2, 100.00 }
            });

            Dep1.WriteFile();
            Company1.WriteFile();
            Console.ReadLine();
        }
        public static Discipline InputDiscipline()
        {
            Console.WriteLine("Input the Discipline title: ");
            var title = Console.ReadLine();
            Console.WriteLine("Input Discipline Duration In Hours: ");
            var duration = 0;
            if (!Int32.TryParse(Console.ReadLine(), out duration))
            {
                throw new ArgumentException(nameof(duration));
            }
            return new Discipline(title, "Inputed dis from keyboard.", duration);
        }
        public static List<Discipline> InputDis()
        {
            var Disciplines = new List<Discipline>();
            Console.WriteLine("Input the number of Discipline");
            var DisciplineNumber = 0;
            if (!Int32.TryParse(Console.ReadLine(), out DisciplineNumber))
            {
                throw new ArgumentException(nameof(DisciplineNumber));
            }
            for (int i = 0; i < DisciplineNumber; i++)
            {
                Disciplines.Add(InputDiscipline());
            }
            return Disciplines;
        }
        public static Company InputCompany(Department department, List<Discipline> disciplines)
        {
            Console.WriteLine("Input Company name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Input Company income: ");
            var income = 0;
            if (!Int32.TryParse(Console.ReadLine(), out income))
            {
                throw new ArgumentException(nameof(income));
            }
            Console.WriteLine("Input the number of vacancies");
            var VacantNumber = 0;
            if(!Int32.TryParse(Console.ReadLine(), out VacantNumber))
            {
                throw new ArgumentException(nameof(VacantNumber));
            }
            var Vacancies = new List<Tuple<string, VacanciesTypes>>();
            for (int i = 0;i < VacantNumber; i++)
            {

                Console.WriteLine("Enter the vacancy title: ");
                var title = Console.ReadLine();
                Console.WriteLine("Choose the vacancy level(0 - intern, 1 - Trainee, 2 - Junior, 3 - middMiddlele, 4 - Senior)");
                var option = 0;
                if(!Int32.TryParse(Console.ReadLine(), out option))
                {
                    throw new ArgumentException(nameof(option));
                }
                if(option < 0 || option > 4)
                {
                    throw new ArgumentException(nameof(option));
                }
                Vacancies.Add(new Tuple<string, VacanciesTypes>(title, (VacanciesTypes)option));
            }

            Console.WriteLine("Input the number of Employees");
            var EmployeeNumber = 0;
            if (!Int32.TryParse(Console.ReadLine(), out EmployeeNumber))
            {
                throw new ArgumentException(nameof(EmployeeNumber));
            }
            var Employees = new List<Employee>();
            for (int i = 0; i < EmployeeNumber; i++)
            {

                Console.WriteLine("Enter an Employee name: ");
                var Employeename = Console.ReadLine();

                Console.WriteLine("Enter an Employee salory: ");
                var salory = 0;
                if (!Int32.TryParse(Console.ReadLine(), out salory))
                {
                    throw new ArgumentException(nameof(salory));
                }
                Console.WriteLine("Enter if the employee can teach(1- can, 0 - can not): ");
                var canteach = 0;
                if (!Int32.TryParse(Console.ReadLine(), out canteach))
                {
                    throw new ArgumentException(nameof(canteach));
                }
                if(canteach < 0 || canteach > 1)
                {
                    throw new ArgumentException(nameof(canteach));
                }

                Console.WriteLine("Enter the Discipline that Employee can teach: ");
                for(int j = 0;j < disciplines.Count; j++)
                {
                    Console.WriteLine($"{i} : {disciplines[j].DisciplineName}");
                }

                var DisIndx = 0;
                if (!Int32.TryParse(Console.ReadLine(), out DisIndx))
                {
                    throw new ArgumentException(nameof(DisIndx));
                }
                Employees.Add(new Employee(Employeename, salory, canteach == 1 ? true : false, disciplines[DisIndx]));
            }
            Console.WriteLine("Enter invest amount for each department: ");
            Console.Write($"{department.DepartmentName} : ");
            var InvertAmout = new Dictionary<Department, double>() { { department, Double.Parse(Console.ReadLine()) } };

            return new Company(name, income, Vacancies, Employees, InvertAmout);
        }
        public static Student InputStudent(List<Discipline> disciplines)
        {
            Console.WriteLine("Input student name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Input student`s year of study: ");
            var yearOfStudy = 0;
            if (!Int32.TryParse(Console.ReadLine(), out yearOfStudy))
            {
                throw new ArgumentException(nameof(yearOfStudy));
            }
            Console.WriteLine("Input student`s success rate : ");
            var successRate = 0;
            if (!Int32.TryParse(Console.ReadLine(), out successRate))
            {
                throw new ArgumentException(nameof(successRate));
            }
            Console.WriteLine("Enter the Discipline: ");
            for (int j = 0; j < disciplines.Count; j++)
            {
                Console.WriteLine($"{j} : {disciplines[j].DisciplineName}");
            }

            var DisIndx = 0;
            if (!Int32.TryParse(Console.ReadLine(), out DisIndx))
            {
                throw new ArgumentException(nameof(DisIndx));
            }
            Console.WriteLine("Input the student`s Creativity rate(1-100): ");
            var Creativity = 0;
            if (!Int32.TryParse(Console.ReadLine(), out Creativity))
            {
                throw new ArgumentException(nameof(Creativity));
            }

            return new Student(name, yearOfStudy, successRate, disciplines[DisIndx], Creativity);
        }
        public static Department InputDepartment(List<Discipline> disciplines)
        {
            Console.WriteLine("Input Company name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Input the number of Teachers: ");
            var teacherNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input the number of Students: ");
            var studentsNumber = Int32.Parse(Console.ReadLine());
            var students = new List<Student>(studentsNumber);
            for(int i = 0;i < studentsNumber; i++)
            {
                students.Add(InputStudent(disciplines));
            }
            return new Department(name, teacherNumber, students, disciplines.ToHashSet());
        }
        static void Main(string[] args)
        {
            var Company1 = new Company();
            var Department = new Department();
            var Disciplines = new List<Discipline>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select Onption:");
                Console.WriteLine("1 - input new Company");
                Console.WriteLine("2 - input new Department");
                Console.WriteLine("3 - input Disciplines");
                Console.WriteLine("4 - check an example of writing in file");
                Console.WriteLine("5 - check an lab 2");
                Console.WriteLine("0 - exit.");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Company1 = InputCompany(Department, Disciplines);
                        break;
                    case "2":
                        Department = InputDepartment(Disciplines);
                        break;
                    case "3":
                        Disciplines = InputDis();
                        break;
                    case "4":
                        WriteFileShowCase();
                        break;
                    case "5":
                        StartupProject.Run();
                        break;
                    default:
                        return;
                }
            }

            Department.WriteFile();
            Company1.WriteFile();
        }
    }
}