using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Common.Dtos.CreateDtos
{
    public class MessageCreateDto
    {
        public string Text { get; set; }
        public Guid ChatId { get; set; }
    }
}
