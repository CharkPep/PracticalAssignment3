using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Employee : Company
    {
        public string Name { get; set; }
        public int Salory { get; set; }
        public bool CanBeInvolvedInStudy { get; set; }
        public Discipline DisciplineToTeach { get; set; }


    }
}
