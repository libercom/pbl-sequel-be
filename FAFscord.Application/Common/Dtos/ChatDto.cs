using FAFscord.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Common.Dtos
{
    public class ChatDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<UserDto> Users { get; set; }
        public ICollection<ChatStudentDto> ChatStudents { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}
