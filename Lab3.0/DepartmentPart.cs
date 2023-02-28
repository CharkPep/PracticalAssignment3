using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public partial class Department
    {
        public void CheckQualityOfEducationProgram(Discipline discipline, Company Company)
        {
            if (Company.DisciplineRateByCompany == null)
            {
                Debug.WriteLine($"Company : {Company.CompanyName} haven`t rated a discipline {discipline.DisciplineName}");
            }
            else
            {
                Debug.WriteLine($"Company : {Company.CompanyName} rated a discipline {discipline.DisciplineName}: {Company.DisciplineRateByCompany[discipline]}");
            }
        }
    }
}
