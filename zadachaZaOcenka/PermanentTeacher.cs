using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadachaZaOcenka
{
    public class PermanentTeacher:TeacherBase
    {
        public PermanentTeacher(string name, string school, List<string> classes, string subject)
        {
            Name = name;
            School = school;
            Classes = classes;
            Subject = subject;
            Contract = ContractType.Permanent;
        }

        public override bool IsTeachingSubject(string subject)
        {
            return Subject.Equals(subject, StringComparison.OrdinalIgnoreCase);
        }
    }
}
