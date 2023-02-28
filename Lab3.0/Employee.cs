using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Employee
    {

        public string Name { get; set; }
        public int Salory { get; set; }
        public bool CanBeInvolvedInStudy { get; set; }
        public Discipline? DisciplineToTeach { get; set; }
        public Employee(Student student)
        {
            Name = student.StudentName;
            Salory = 10000;
            CanBeInvolvedInStudy = false;
            DisciplineToTeach = null;
        }
        public Employee(string Name, int Salory, bool CanTeach, Discipline DisciplineToTeach)
        {
            this.Name = Name;
            this.Salory = Salory;
            CanBeInvolvedInStudy = CanTeach;
            this.DisciplineToTeach = DisciplineToTeach;
        }
        public Employee(Company EmployedAt, string Name, int Salory, bool CanTeach, Discipline DisciplineToTeach)
        {
            this.Name = Name;
            this.Salory = Salory;
            CanBeInvolvedInStudy = CanTeach;
            this.DisciplineToTeach = DisciplineToTeach;
        }
    }
}
