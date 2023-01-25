using AutoMapper;
using FAFscord.Application.Common.Dtos;
using FAFscord.Application.Common.Interfaces.Repositories;
using FAFscord.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Queries
{
    public class GetUserChatsQuery : IRequest<List<ChatDto>>
    {
        public GetUserChatsQuery(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; set; }
    }

    public class GetUserChatsQueryHandler : IRequestHandler<GetUserChatsQuery, List<ChatDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetUserChatsQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ChatDto>> Handle(GetUserChatsQuery request, CancellationToken cancellationToken)
        {
            var chats = await _repository.GetAll<Chat>(new List<string> { $"{nameof(Chat.ChatStudents)}" });
            var userChats = chats.Where(x => x.ChatStudents.Any(y => y.UserId == request.UserId)).ToList();
            var chatDtos = _mapper.Map<List<ChatDto>>(userChats);

            foreach (var chat in userChats)
            {
                chatDtos.FirstOrDefault(x => x.Id == chat.Id).Messages = chat.ChatStudents
                                                                             .Where(x => x.ChatId == chat.Id)
                                                                             .SelectMany(x => _mapper.Map<List<MessageDto>>(x.Messages)).ToList();
            }

            return chatDtos;
        }
    }
}
