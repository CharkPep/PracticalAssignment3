using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Student
    {
        public string? StudentName { get; set; }
        public int YearOfStudy { get; set; }
        public int SuccessRate { get; set; } //[0 – 100] загальний бал
        public Discipline? discipline { get; }
        public int ITProjectsParticipationRate { get; set; } // Загальгий балл за проекти
        public int StudentsCreativity { get; set; }//0 - 100 - креативність студента
        public bool IsEmployed { get; set; }
        public Student(){}
        public Student(string Name, int YearOfStudy, int SuccessRate, Discipline discipline, int StudentCreativity)
        {
            this.StudentName = Name;
            this.YearOfStudy= YearOfStudy;
            this.SuccessRate = SuccessRate;
            this.discipline= discipline;
            this.StudentsCreativity = StudentCreativity;
        }

    }
}
