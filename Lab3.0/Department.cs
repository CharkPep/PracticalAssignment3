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
        public List<Student>? Students { get; }
        public HashSet<Discipline>? Disciplines { get; set; }
        public void WriteFile()
        {
            var fout = new StreamWriter("Department.txt");
            fout.WriteLine($"The Department name: {DepartmentName}");
            fout.WriteLine($"The number of teachers in the department : {TeacherNumber}");
            if (Students == null)
            {
                fout.WriteLine("There is no students.");
            }
            else
            {
                fout.WriteLine($"Students: ");
                foreach (var i in Students)
                {
                    fout.WriteLine(i.StudentName);
                }
            }
            if (Disciplines == null)
            {
                fout.WriteLine("There is no disciplines");
            }
            else
            {
                fout.WriteLine("The disciplines: ");
                foreach (var i in Disciplines)
                {
                    fout.WriteLine(i.DisciplineName);
                }
            }
            fout.Close();
            if (File.Exists("Department.txt"))
            {
                Console.WriteLine("File was written properly.");
            }
            else
            {
                Console.WriteLine("File was not written properly.");
            }

        }
        public Department()
        {

        }
        public Department(string DepartmentName, int TeacherNumber, int StudentNumber, int DisciplineNumber, IEnumerable<Student> Students, HashSet<Discipline> Disciplines)
        {
            this.DepartmentName = DepartmentName;
            this.TeacherNumber = TeacherNumber;
            this.Disciplines = Disciplines;
            this.Students = Students.ToList();
            this.Disciplines = Disciplines;
        }
        public Department(string DepartmentName, int TeacherNumber, IEnumerable<Student> Students, HashSet<Discipline> Disciplines)
        {
            this.DepartmentName = DepartmentName;
            this.TeacherNumber = TeacherNumber;
            this.Disciplines = Disciplines;
            this.Students = Students.ToList();
            this.Disciplines = Disciplines;
        }
        public bool InvolveSpecialists(Company Company, int NumberToInvolve)
        {
            var NewTeachers = 0;
            var NewDisciplines = 0;
            if (Company == null || Company.employees == null)
            {
                throw new ArgumentNullException(nameof(Company));
            }
            if (Company.employees == null || this.Disciplines == null)
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
                    if (i.DisciplineToTeach == null)
                    {
                        throw new ArgumentNullException(nameof(Company));
                    }
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

            if (NewTeachers != NumberToInvolve)
            {
                return false;
            }
            return true;
        }
        public void InternShipForStudents(string project, int projectdiffulty, Student student)
        {
            Debug.WriteLine($"Student {student.StudentName} improved his/her creative abilites by {projectdiffulty}");
            student.StudentsCreativity += projectdiffulty;
        }
        public double InvestAmountByCompany(Company Company)
        {
            if (Company == null || Company.InvestAmount == null)
            {
                throw new ArgumentNullException(nameof(Company));
            }
            return Company.InvestAmount[this];
        }
    }
}
