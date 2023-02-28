using System.Collections.Generic;
using static Lab3.Company;

namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
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
        }
    }
}