using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{ 
    internal class Company
    {
        public string CompanyName { get; }
        public int Income { get; }
        public int EmloyeeNumber { get; }
        public List<Discipline> VacancyByDiscipline { get; }
        public List<Employee> employees { get; set; }
        public int InterShipVacanvyes { get; set; }
        public Dictionary<Department, int> InvestAmount { get; }
        public void ExpandNumberOfEmployees(Department department)
        {
            int NumberOfGraduatingStudents = 0;
            var ToEmploye = (int)(this.InterShipVacanvyes * 0.1);
            var Employed = new List<Student>();
            foreach (var i in department.Students)
            {
                if (i.YearOfStudy == 4 && !i.IsEmployed && ToEmploye > 0) 
                {
                    NumberOfGraduatingStudents++;
                    ToEmploye--;
                    i.IsEmployed = true;
                    Employed.Add(i);
                }
            }
            foreach (var i in Employed)
            {
                Console.WriteLine($"Student " + i.StudentName + " found job.");
            }
        }
        public class ITAccelerator{
            private int ProjectNumber;
            private List<Student> Students;
            private int StudentNumber;
            public void GetInvestAmount()
            {

            }
            public void GetVacantStudent(Department department, Company ITAcceleratorParent)
            {
                var Rating = new SortedSet<Tuple<Student, int>>(); 
                foreach(var i in department.Students)
                {
                    Rating.Add(Tuple.Create(i,i.SuccessRate + i.ITProjectsParticipationRate));
                }
                int tempVacant = ITAcceleratorParent.InterShipVacanvyes;
                Console.WriteLine($"There are {ITAcceleratorParent.InterShipVacanvyes} right now");
                foreach(var i in Rating)
                {
                    if(tempVacant > 0)
                        Console.WriteLine(i.Item1 + " " + i.Item2 + " Vacant.");
                    else
                        Console.WriteLine(i.Item1 + " " + i.Item2 + " Not Vacant.");
                }

            }
            class ITAcceleratorTeacher
            {
                private string Name;
                private int Salory;
            }

        }

    }
}
