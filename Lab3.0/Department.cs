using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab3
{
    public partial class Department
    {
        public string? DepartmentName { get; }
        public int? TeacherNumber { get; set; }
        public List<Student>? Students { get; set; }
        public HashSet<Discipline>? Disciplines { get; set; }

        public Department()
        {

        }
        public Department(string DepartmentName, int TeacherNumber, int StudentNumber, int DisciplineNumber, IEnumerable<Student> Students, HashSet<Discipline> Disciplines)
        {
            this.DepartmentName = DepartmentName;
            this.TeacherNumber = TeacherNumber;
            this.Disciplines = Disciplines;
            this.Students= Students.ToList();
            this.Disciplines = Disciplines;
        }
        public bool InvolveSpecialists(Company Company, int NumberToInvolve)
        {
            var NewTeachers = 0;
            var NewDisciplines = 0;
        
            if(Company.employees == null || this.Disciplines == null)
            {
                if (NewTeachers != NumberToInvolve)
                {
                    return false;
                }
                return true;
            }
            
            foreach (var i in Company.employees)
            {
                if (i.CanBeInvolvedInStudy && NumberToInvolve > NewTeachers)
                {
                    NewTeachers++;
                    if (!Disciplines.Contains(i.DisciplineToTeach))
                    {
                        Disciplines.Add(i.DisciplineToTeach);
                        NewDisciplines++;
                    }
                    i.CanBeInvolvedInStudy = false;
                }
            }

            TeacherNumber += NewTeachers;
            Debug.WriteLine($"Number of new Teacher(s): {NewTeachers}");
            Debug.WriteLine($"Number of new Disciplines(s): {NewDisciplines}");

            if(NewTeachers != NumberToInvolve)
            {
                return false;
            }
            return true;
        }
/*        public void InternShipForStudents(Company Company, Project project, Student student)
        {

            if(Company.InterShipVacanvyes > 0)
            {
                Company.InterShipVacanvyes--;
                student.StudentsCreativity += project.durationInMonth * 10;
            }
            if (student.StudentsCreativity > 100)
            {
                student.StudentsCreativity = 100;
            }
        }*/
        public double InvestAmountByCompany(Company Company)
        {
            return Company.InvestAmount[this];
        }



    }
}
