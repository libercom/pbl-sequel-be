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

namespace FAFscord.Application.Commands
{
    public class SendMessageCommand : IRequest<MessageDto>
    {
        public string Text { get; set; }

        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
    }

    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, MessageDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDataProtector _protector;

        public SendMessageCommandHandler(IRepository repository, IMapper mapper, IDataProtectionProvider dataProtectionProvider)
        {
            _repository = repository;
            _mapper = mapper;
            _protector = dataProtectionProvider.CreateProtector("SendMessage");
        }

        public async Task<MessageDto> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var message = _mapper.Map<Message>(request);
            message.CreatedOn = DateTimeOffset.Now;
            message.Text = _protector.Protect(request.Text);

            var result = await _repository.Create(message);

            var includes = new List<string> { nameof(ChatStudent.User), nameof(ChatStudent.Role) };
            var chatStudent = await _repository.GetById<ChatStudent>(x => x.UserId == result.UserId && x.ChatId == result.ChatId, includes);

            result.ChatStudent = chatStudent;
            result.Text = request.Text;
            var mappedResult = _mapper.Map<MessageDto>(result);

            return mappedResult;
        }
    }
}
