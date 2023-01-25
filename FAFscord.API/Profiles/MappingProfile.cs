using AutoMapper;
using FAFscord.Application.Commands;
using FAFscord.Application.Common.Dtos;
using FAFscord.Application.Common.Dtos.CreateDtos;

namespace FAFscord.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ChatCreateDto, AddChatCommand>();

            CreateMap<UserCreateDto, AddUserCommand>();

            CreateMap<AcademicGroupCreateDto, AddAcademicGroupCommand>();

            CreateMap<MessageCreateDto, SendMessageCommand>();

            CreateMap<MessageCreateDto, MessageDto>();
        }
    }
}
