using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab3
{
    internal partial class Department
    {
        public string DepartmentName { get; set; }
        public int TeacherNumber { get; set; }
        public int StundetNumber { get; set; }
        public int DisciplineNumber { get; set; }
        public List<Student> Students { get; set; }
        public HashSet<Discipline> Disciplines { get; set; }

        public Department()
        {

        }
        public void InvolveSpecialists(Company Company, int NumberToInvolve)
        {
            var NewTeachers = 0;
            var NewDisciplines = 0;
            foreach (var i in Company.employees)
            {
                if (i.CanBeInvolvedInStudy)
                {
                    NewTeachers++;
                    if (Disciplines.Contains(i.DisciplineToTeach))
                    {
                        Disciplines.Add(i.DisciplineToTeach);
                        NewDisciplines++;
                    }
                }
            }
            TeacherNumber += NewTeachers;
            Console.WriteLine($"Number of new Teacher(s): {NewTeachers}");
            Console.WriteLine($"Number of new Disciplines(s): {NewDisciplines}");
        }
        public void InternShipForStudents(Company Company, Project project, Student student)
        {
            if(Company.InterShipVacanvyes > 0)
            {
                Company.InterShipVacanvyes--;
                student.StudentsCreativity += project.DurationInMonth * 10;
            }
            if (student.StudentsCreativity > 100)
            {
                student.StudentsCreativity = 100;
            }
        }
        public void InvestAmountByCompany(Company Company)
        {
            Console.WriteLine(Company.InvestAmount[this]);
        }



    }
}
