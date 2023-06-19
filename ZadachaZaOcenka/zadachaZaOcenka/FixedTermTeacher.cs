using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadachaZaOcenka
{
    public class FixedTermTeacher : TeacherBase
    {
        public DateTime ContractEndDate { get; set; }

        public FixedTermTeacher(string name, string school, List<string> classes, string subject, DateTime contractEndDate)
        {
            Name = name;
            School = school;
            Classes = classes;
            Subject = subject;
            Contract = ContractType.FixedTerm;
            ContractEndDate = contractEndDate;
        }

        public override bool IsTeachingSubject(string subject)
        {
            return Subject.Equals(subject, StringComparison.OrdinalIgnoreCase);
        }
    }
}
