using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain
{
    public class ChatStudent : BaseEntity
    {
        public Guid ChatRoleId { get; set; }
        public ChatRole Role { get; set; }

        public ICollection<Message> Messages { get; set; }

        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
