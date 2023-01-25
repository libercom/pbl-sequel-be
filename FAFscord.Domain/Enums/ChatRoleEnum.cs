using FAFscord.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain.Enums
{
    public enum ChatRoleEnum
    {
        [Guid("C5627232-B455-4D6C-9B6E-BA14B6589FD9")]
        Admin,

        [Guid("FBAD6E22-61C9-4772-A379-5462FF42496E")]
        User
    }
}
