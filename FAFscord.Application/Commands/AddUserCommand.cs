using AutoMapper;
using FAFscord.Application.Common.Dtos.CreateDtos;
using FAFscord.Application.Common.Interfaces.Repositories;
using FAFscord.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Commands
{
    public class AddUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public Guid AcademicGroupId { get; set; }
    }

    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddUserCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            await _repository.Create(user);

            return Unit.Value;
        }
    }
}
