using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadachaZaOcenka
{
    public interface ITeacher
    {
        string Name { get; }
        string School { get; }
        List<string> Classes { get; }
        string Subject { get; }
        ContractType Contract { get; }
        bool IsTeachingSubject(string subject);
    }
}
