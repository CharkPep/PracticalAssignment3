using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Discipline
    {
        public string DisciplineName { get; }
        public string DisciplineDescription { get; }
        public int DisciplineDurationInHours { get; }
        public Discipline(string Name, string Description, int DisciplineDuration)
        {
            DisciplineName = Name;
            DisciplineDescription = Description;
            DisciplineDurationInHours = DisciplineDuration;
        }
    }
}
