using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Domain
{
    public class Message : BaseEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public string Text { get; set; }

        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }

        public ChatStudent ChatStudent { get; set; }
    }
}
