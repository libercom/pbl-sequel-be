using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain
{
    public class AcademicGroup : BaseEntity
    {
        public string Name { get; set; }
        public int GraduationYear { get; set; }
    }
}
