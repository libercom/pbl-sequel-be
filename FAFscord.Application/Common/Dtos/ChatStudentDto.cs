using FAFscord.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Common.Dtos
{
    public class ChatStudentDto
    {
        public ChatRole Role { get; set; }
        public UserDto User { get; set; }
    }
}
