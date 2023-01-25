using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public Guid AcademicGroupId { get; set; }
        public string Image { get; set; }

        public ICollection<Chat> Chats { get; set; }
        public ICollection<ChatStudent> ChatStudents { get; set; }
    }
}
