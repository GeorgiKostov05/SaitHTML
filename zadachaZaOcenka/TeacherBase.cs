using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadachaZaOcenka
{
    public abstract class TeacherBase : ITeacher
    {
        public string Name { get; set; }
        public string School { get; set; }
        public List<string> Classes { get; set; }
        public string Subject { get; set; }
        public ContractType Contract { get; set; }

        public abstract bool IsTeachingSubject(string subject);
    }
}
