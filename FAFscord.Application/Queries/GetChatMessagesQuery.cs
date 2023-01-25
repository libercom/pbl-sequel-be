using AutoMapper;
using FAFscord.Application.Common.Dtos;
using FAFscord.Application.Common.Interfaces.Repositories;
using FAFscord.Domain;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Queries
{
    public class GetChatMessagesQuery : IRequest<List<MessageDto>>
    {
        public GetChatMessagesQuery(Guid chatId)
        {
            ChatId = chatId;
        }

        public Guid ChatId { get; set; }
    }

    public class GetChatMessagesQueryHandler : IRequestHandler<GetChatMessagesQuery, List<MessageDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public GetChatMessagesQueryHandler(IRepository repository, IMapper mapper, IDataProtectionProvider dataProtectionProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _protector = dataProtectionProvider.CreateProtector("SendMessage");
        }

        public async Task<List<MessageDto>> Handle(GetChatMessagesQuery request, CancellationToken cancellationToken)
        {
            var chat = await _repository.GetById<Chat>(request.ChatId, null);
            var messages = chat.ChatStudents.SelectMany(x => x.Messages).ToList().OrderBy(x => x.CreatedOn);

            foreach (var message in messages)
            {
                if (!string.IsNullOrEmpty(message.Text))
                    message.Text = _protector.Unprotect(message.Text);
            }

            var messageDtos = _mapper.Map<List<MessageDto>>(messages);

            return messageDtos;
        }
    }
}
