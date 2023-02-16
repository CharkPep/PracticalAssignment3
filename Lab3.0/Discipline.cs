using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Discipline : Department
    {
        public string DisciplineName { get; }
        public string DisciplineDescription { get; }
        public int DisciplineDurationInHours { get; }
    }
}
