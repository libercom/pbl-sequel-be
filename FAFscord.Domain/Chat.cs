using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain
{
    public class Chat : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<ChatStudent> ChatStudents { get; set; }
    }
}
