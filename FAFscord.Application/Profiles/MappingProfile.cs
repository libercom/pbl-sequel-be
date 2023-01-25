using AutoMapper;
using FAFscord.Application.Commands;
using FAFscord.Application.Common.Dtos;
using FAFscord.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddChatCommand, Chat>();

            CreateMap<AddUserCommand, User>();

            CreateMap<AddAcademicGroupCommand, AcademicGroup>();

            CreateMap<SendMessageCommand, Message>();

            // !--------------------------------------------------

            CreateMap<Message, MessageDto>();

            CreateMap<User, UserDto>();

            CreateMap<ChatStudent, ChatStudentDto>();

            CreateMap<Chat, ChatDto>();
        }
    }
}
