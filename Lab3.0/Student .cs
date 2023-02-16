using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Student : Department
    {
        public string StudentName { get; set; }
        public int YearOfStudy { get; set; }
        public int SuccessRate { get; set; } //[0 – 100] загальний бал
        private List<int> Grades;
        private Discipline discipline;
        public int ITProjectsParticipationRate { get; }
        public int StudentsCreativity { get; set; }//0 - 100 - креативність студента
        private int NumberOfAwards;
        public bool IsEmployed { get; set; }
        public Student(){}
        public Student(string Name, int YearOfStudy, int SuccessRate, Discipline discipline, int StudentCreativity, int NumberOfAwards)
        {
            this.StudentName = Name;
            this.YearOfStudy= YearOfStudy;
            this.SuccessRate = SuccessRate;
            this.discipline= discipline;
            this.StudentsCreativity = StudentCreativity;
            this.NumberOfAwards = NumberOfAwards;
        }

    }
}
