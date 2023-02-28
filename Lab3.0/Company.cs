using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace Lab3
{
    public class Company
    {
        public enum VacanciesTypes { InternShip, Trainee, Junior, Middle, Senior };
        public string CompanyName { get; }
        public int Income { get; }
        public List<Tuple<string, VacanciesTypes>> Vacancies { get; }
        public List<Employee> employees { get; }
        public Dictionary<Department, double> InvestAmount { get; }
        public Dictionary<Discipline, double>? DisciplineRateByCompany { get; }
        public Company()
        {

        }
        public Company(string CompanyName, int Income, IEnumerable<Tuple<string, VacanciesTypes>>? Vacancies, IEnumerable<Employee> Employees, Dictionary<Department, double>? InvestAmount)
        {
            this.CompanyName = CompanyName;
            this.Income = Income;
            if (Vacancies != null)
            {
                this.Vacancies = Vacancies.ToList();
            }
            if (Employees != null)
            {
                this.employees = Employees.ToList();
            }
            if (InvestAmount != null)
            {
                this.InvestAmount = InvestAmount;
            }
        }
        public Company(string CompanyName, int Income, IEnumerable<Tuple<string, VacanciesTypes>>? Vacancies, IEnumerable<Employee> Employees, Dictionary<Department, double>? InvestAmount, Dictionary<Discipline, double>? DisciplineRateByCompany) : this(CompanyName, Income, Vacancies, Employees, InvestAmount)
        {
            this.DisciplineRateByCompany = DisciplineRateByCompany;
        }
        public void ExpandNumberOfEmployees(Department department)
        {
            var InterShipVacancies = Vacancies.Where(x => x.Item2 == VacanciesTypes.InternShip || x.Item2 == VacanciesTypes.Trainee).ToList();
            foreach (var item in InterShipVacancies)
            {
                foreach (var student in department.Students.OrderByDescending(x => x.SuccessRate))
                {
                    if (student.YearOfStudy == 4 && student.SuccessRate > 90 && !student.IsEmployed)
                    {
                        employees.Add(new Employee(student));
                        student.IsEmployed = true;
                        Debug.WriteLine($"Student " + student.StudentName + " found job.");
                        Vacancies.Remove(item);
                        break;
                    }
                }
            }
        }
        public void FileWrite()
        {
            var fout = new StreamWriter("Company.txt");
            fout.WriteLine($"The name of the company: {CompanyName}");
            fout.WriteLine($"The income of the company: {Income}");
            fout.WriteLine($"The company has such vacancies: ");
            foreach (var i in Vacancies)
            {
                fout.WriteLine($"{i.Item1} the level is {i.Item2}");
            }
            fout.WriteLine($"The company has such employees: ");
            foreach (var i in employees)
            {
                fout.WriteLine($"{i.Name}");
            }
            fout.WriteLine($"The company invested in such departments:");
            foreach (var i in InvestAmount)
            {
                fout.WriteLine($"{i.Key} : {i.Value}");
            }
            fout.WriteLine("The company rate Disciplines as such: ");
            foreach(var i in DisciplineRateByCompany)
            {
                fout.WriteLine($"{i.Key} : {i.Value}");
            }
            fout.Close();
        }
        public class ITAccelerator{
            public int projectNumber { get; set; }
            public List<Student> students { get; }
            public int Spending { get; set; }
            public ITAccelerator(int projectNumber, IEnumerable<Student> students, int spendings)
            {
                this.projectNumber = projectNumber;
                this.students = students.ToList();
                Spending = spendings;
            }
            public void GetVacantStudent(Company ITAcceleratorParent)
            {
                var InterShipVacancies = ITAcceleratorParent.Vacancies.Where(x => x.Item2 == VacanciesTypes.InternShip || x.Item2 == VacanciesTypes.Trainee).ToList();
                var StudentsOrdered = students.OrderByDescending(x => x.SuccessRate).ThenByDescending(x => x.ITProjectsParticipationRate);
                foreach (var item in InterShipVacancies)
                {
                    foreach (var student in StudentsOrdered)
                    {
                        if (student.YearOfStudy == 4 && student.SuccessRate > 90 && !student.IsEmployed)
                        {
                            ITAcceleratorParent.employees.Add(new Employee(student));
                            student.IsEmployed = true;
                            Debug.WriteLine($"Student " + student.StudentName + " found job.");
                            ITAcceleratorParent.Vacancies.Remove(item);
                            break;
                        }
                    }
                }
            }

        }

    }
}
