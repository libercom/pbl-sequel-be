using AutoMapper;
using FAFscord.Application.Common.Dtos;
using FAFscord.Application.Common.Interfaces.Repositories;
using FAFscord.Domain;
using FAFscord.Domain.Enums;
using FAFscord.Domain.Extensions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Commands
{
    public class AddChatCommand : IRequest
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }

    public class AddChatCommandHandler : IRequestHandler<AddChatCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddChatCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddChatCommand request, CancellationToken cancellationToken)
        {
            var chat = _mapper.Map<Chat>(request);
            var result = await _repository.Create(chat);
            var chatStudent = new ChatStudent
            {
                ChatId = result.Id,
                UserId = request.UserId,
                ChatRoleId = ChatRoleEnum.Admin.GetGuid()
            };

            await _repository.Create(chatStudent);

            return Unit.Value;
        }
    }
}
