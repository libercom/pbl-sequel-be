using FAFscord.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Common.Dtos
{
    public class MessageDto
    {
        public DateTimeOffset CreatedOn { get; set; }
        public Guid ChatId { get; set; }
        public string Text { get; set; }
        public ChatStudentDto ChatStudent { get; set; }
    }
}
