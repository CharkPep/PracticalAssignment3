using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Employee
    {

        public string name { get; set; }
        public int salory { get; set; }
        public bool canBeInvolvedInStudy { get; set; }
        public Discipline? disciplineToTeach { get; set; }
        public Employee(Student student)
        {
            name = student.StudentName;
            salory = 10000;
            canBeInvolvedInStudy = false;
            disciplineToTeach = null;
        }
        public Employee(string Name, int Salory, bool CanTeach, Discipline DisciplineToTeach)
        {
            this.name = Name;
            this.salory = Salory;
            canBeInvolvedInStudy = CanTeach;
            this.disciplineToTeach = DisciplineToTeach;
        }
        public Employee(Company EmployedAt, string Name, int Salory, bool CanTeach, Discipline DisciplineToTeach)
        {
            this.name = Name;
            this.salory = Salory;
            canBeInvolvedInStudy = CanTeach;
            this.disciplineToTeach = DisciplineToTeach;
        }
    }
}
