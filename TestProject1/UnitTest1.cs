using System.Diagnostics;
using System.Reflection;
using Lab3;
using NuGet.Frameworks;
using static Lab3.Company;
#pragma warning disable CS8625
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        #region DataSets

        private IEnumerable<(Department, Company, int, int, int, bool)> DataSet1()
        {
            var Dis1 = new Discipline("≤œ«", "", 100);
            var Dis2 = new Discipline("œœ«", "", 100);
            var Dis3 = new Discipline(" œ«", "", 100);
            var Dis4 = new Discipline("  «", "", 100);

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

            yield return (new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 }), (new Company("PonySoftware", 100000000, Vacancies, new List<Employee>() { Employee1, Employee2, Employee3 }, Dic)), 10, 2, 0, false);
            Employee1 = new Employee("Employee1", 1000, false, Dis1);
            Employee2 = new Employee("Employee2", 1000, true, Dis1);
            Employee3 = new Employee("Employee3", 1000, true, Dis1);
            yield return (new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 }), (new Company("PonySoftware", 100000000, Vacancies, new List<Employee>() { Employee1, Employee2, Employee3 }, Dic)), 10, 2, 0, false);
            Employee1 = new Employee("Employee1", 1000, false, Dis1);
            Employee2 = new Employee("Employee2", 1000, false, Dis1);
            Employee4 = new Employee("Employee4", 1000, true, Dis4);
            yield return (new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 }), (new Company("PonySoftware", 100000000, Vacancies, new List<Employee>() { Employee1, Employee2, Employee4 }, Dic)), 10, 1, 1, false);
            Employee1 = new Employee("Employee1", 1000, false, Dis1);
            Employee2 = new Employee("Employee2", 1000, true, Dis1);
            Employee3 = new Employee("Employee3", 1000, true, Dis1);
            yield return (new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 }), (new Company("PonySoftware", 100000000, Vacancies, new List<Employee>() { Employee1, Employee2, Employee3 }, Dic)), 0, 0, 0, true);
            Employee1 = new Employee("Employee1", 1000, false, Dis1);
            Employee2 = new Employee("Employee2", 1000, true, Dis1);
            Employee3 = new Employee("Employee3", 1000, true, Dis1);
            yield return (new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 }), (new Company("PonySoftware", 100000000, Vacancies, new List<Employee>() { Employee1, Employee2, Employee3 }, Dic)), 2, 2, 0, true);
        }
        private IEnumerable<(Department, Company, double)> DataSet2()
        {
            var Dis1 = new Discipline("≤œ«", "", 100);
            var Dis2 = new Discipline("œœ«", "", 100);
            var Dis3 = new Discipline(" œ«", "", 100);
            var Dis4 = new Discipline("  «", "", 100);

            var Stud1 = new Student("Egor", 1, 100, Dis1, 100);
            var Stud2 = new Student("Vlad", 1, 80, Dis1, 0);
            var Stud3 = new Student("Vova", 1, 100, Dis1, 100);
            var Stud4 = new Student("Bogdan", 1, 100, Dis1, 100);
            var Stud5 = new Student("Dima", 1, 80, Dis1, 0);
            var Stud6 = new Student("Anya", 1, 100, Dis1, 100);

            var Dep1 = new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });
            var Dep2 = new Department("FKS", 100, 3, 6, new List<Student> { Stud4, Stud5, Stud6 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });
            var Dep3 = new Department("KKS", 100, 3, 6, new List<Student> { Stud4, Stud5, Stud6 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });
            
            //Invest amount 

            var Dic = new Dictionary<Department, double>
            {
                { Dep1, 1000000000.05 },
                { Dep2, 1000000.0001 },
                { Dep3, 10000.0001 }
            };

            var Vacancies = new List<Tuple<string, VacanciesTypes>>
            {
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip)
            };

            yield return (Dep1, new Company("Company1", 0, null, null, Dic), 1000000000.05);
            yield return (Dep2, new Company("Company1", 0, null, null, Dic), 1000000.0001);
            yield return (Dep3, new Company("Company1", 0, null, null, Dic), 10000.0001);
        }

        private IEnumerable<(Department, Company, int)> DataSet3()
        {
            var Dis1 = new Discipline("≤œ«", "", 100);
            var Dis2 = new Discipline("œœ«", "", 100);
            var Dis3 = new Discipline(" œ«", "", 100);


            var Stud1 = new Student("Egor", 4, 100, Dis1, 100);
            var Stud2 = new Student("Vlad", 4, 80, Dis1, 0);
            var Stud3 = new Student("Vova", 4, 100, Dis1, 100);

            var Dep1 = new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });

            var Employee1 = new Employee("Employee1", 1000, false, Dis1);
            var Employee2 = new Employee("Employee2", 1000, true, Dis1);
            var Employee3 = new Employee("Employee3", 1000, true, Dis1);

            var Vacancies = new List<Tuple<string, VacanciesTypes>>
            {
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip),
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip),
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip)

            };
            
            yield return (Dep1, new Company("Company1", 0, Vacancies, new List<Employee> { Employee1, Employee2, Employee3 }, null), 2);
            Stud1 = new Student("Egor", 1, 100, Dis1, 100);
            Stud2 = new Student("Vlad", 1, 80, Dis1, 0);
            Stud3 = new Student("Vova", 4, 100, Dis1, 100);
            Dep1 = new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });
            yield return (Dep1, new Company("Company1", 0, Vacancies, new List<Employee> { Employee1, Employee2, Employee3 }, null), 1);
            Stud1 = new Student("Egor", 1, 100, Dis1, 100);
            Stud2 = new Student("Vlad", 1, 80, Dis1, 0);
            Stud3 = new Student("Vova", 1, 100, Dis1, 100);
            Dep1 = new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });
            yield return (Dep1, new Company("Company1", 0, Vacancies, new List<Employee> { Employee1, Employee2, Employee3 }, null), 0);
            Stud1 = new Student("Egor", 4, 100, Dis1, 100);
            Stud2 = new Student("Vlad", 4, 80, Dis1, 0);
            Stud3 = new Student("Vova", 4, 100, Dis1, 100);
            Dep1 = new Department("FIT", 100, 3, 6, new List<Student> { Stud1, Stud2, Stud3 }, new HashSet<Discipline> { Dis1, Dis2, Dis3 });
            yield return (Dep1, new Company("Company1", 0, new List<Tuple<string, VacanciesTypes>>{new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip)}, new List<Employee> { Employee1, Employee2, Employee3 }, null), 1);

        }

        private IEnumerable<(ITAccelerator, Company, int)> DataSet4()
        {
            var Dis1 = new Discipline("≤œ«", "", 100);
            var Dis2 = new Discipline("œœ«", "", 100);
            var Dis3 = new Discipline(" œ«", "", 100);



            var Employee1 = new Employee("Employee1", 1000, false, Dis1);
            var Employee2 = new Employee("Employee2", 1000, true, Dis1);
            var Employee3 = new Employee("Employee3", 1000, true, Dis1);

            var Vacancies = new List<Tuple<string, VacanciesTypes>>
            {
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip),
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip),
                new Tuple<string, VacanciesTypes>("Intership Developer", VacanciesTypes.InternShip)

            };


            var Stud1 = new Student("Egor", 4, 100, Dis1, 100);
            Stud1.ITProjectsParticipationRate = 100;
            var Stud2 = new Student("Vlad", 4, 80, Dis1, 0);
            Stud2.ITProjectsParticipationRate = 100;
            var Stud3 = new Student("Vova", 4, 100, Dis1, 100);
            Stud3.ITProjectsParticipationRate = 100; ;
            var ITAccel1 = new ITAccelerator(100, new List<Student>{ Stud1, Stud2, Stud3 }, 1000000);


            yield return (ITAccel1, new Company("Company1", 0, Vacancies, new List<Employee> { Employee1, Employee2, Employee3 }, null), 2);
            Stud1 = new Student("Egor", 4, 100, Dis1, 100);
            Stud1.ITProjectsParticipationRate = 100;
            Stud2 = new Student("Vlad", 4, 91, Dis1, 70);
            Stud2.ITProjectsParticipationRate = 100;
            Stud3 = new Student("Vova", 4, 100, Dis1, 90);
            Stud3.ITProjectsParticipationRate = 100;
            ITAccel1 = new ITAccelerator(100, new List<Student> { Stud1, Stud2, Stud3 }, 1000000);

            yield return (ITAccel1, new Company("Company1", 0, Vacancies, new List<Employee> { Employee1, Employee2, Employee3 }, null), 3);
            Stud1 = new Student("Egor", 4, 100, Dis1, 100);
            Stud1.ITProjectsParticipationRate = 100;
            Stud2 = new Student("Vlad", 4, 91, Dis1, 70);
            Stud2.ITProjectsParticipationRate = 50;
            Stud3 = new Student("Vova", 4, 100, Dis1, 90);
            Stud3.ITProjectsParticipationRate = 100;
            var Stud4 = new Student("Student4", 4, 91, Dis1, 90);
            Stud4.ITProjectsParticipationRate = 100;
            ITAccel1 = new ITAccelerator(100, new List<Student> { Stud1, Stud2, Stud3, Stud4 }, 1000000);

            yield return (ITAccel1, new Company("Company1", 0, Vacancies, new List<Employee> { Employee1, Employee2, Employee3 }, null), 3);


        }

        #endregion


        [TestMethod]
        public void DepartmentInvolveSpecialistsTest()
        {
            foreach(var (dep, comp, numberToInvlove, expectedTeacher, expectedPrograms, enough) in DataSet1())
            {
                var initValueTeachers = dep.TeacherNumber;
                var initValuePrograms = dep.Disciplines.Count;
                var flag = dep.InvolveSpecialists(comp, numberToInvlove);
                Assert.IsTrue(dep.TeacherNumber - initValueTeachers == expectedTeacher && dep.Disciplines.Count - initValuePrograms == expectedPrograms && flag == enough, "The method works incorrectly");
            }
        }
        [TestMethod]
        public void InvestAmountByCompanyTest()
        {
            foreach (var (dep, comp,expected) in DataSet2())
            {
                Assert.IsTrue(dep.InvestAmountByCompany(comp) == expected, comp.CompanyName);
            }
        }
        [TestMethod]
        public void ExpandNumberOfEmployees()
        {
            foreach (var (dep, comp, expected) in DataSet3())
            {
                int curEmployee = comp.employees.Count;
                int curVacancies = comp.Vacancies.Count;
                comp.ExpandNumberOfEmployees(dep);
                Assert.IsTrue(expected == comp.employees.Count - curEmployee && expected == curVacancies - comp.Vacancies.Count, $"Expected: {expected}, got {comp.employees.Count - curEmployee} and {curVacancies - comp.Vacancies.Count}.");
            }
        }
        [TestMethod]
        public void ITAcceleratorTest()
        {
            foreach(var (accelerator, comp, expected) in DataSet4())
            {
                int curEmployee = comp.employees.Count;
                int curVacancies = comp.Vacancies.Count;
                accelerator.GetVacantStudent(comp);
                Assert.IsTrue(expected == comp.employees.Count - curEmployee && expected == curVacancies - comp.Vacancies.Count, $"Expected: {expected}, got {comp.employees.Count - curEmployee} and {curVacancies - comp.Vacancies.Count}.");

            }
        }
    }
}