using AutoMapper;
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
    public class AddAcademicGroupCommand : IRequest
    {
        public string Name { get; set; }
        public int GraduationYear { get; set; }
    }

    public class AddAcademicGroupCommandHandler : IRequestHandler<AddAcademicGroupCommand>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AddAcademicGroupCommandHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddAcademicGroupCommand request, CancellationToken cancellationToken)
        {
            var academicGroup = _mapper.Map<AcademicGroup>(request);

            await _repository.Create(academicGroup);

            return Unit.Value;
        }
    }
}
