using FAFscord.Application.Common.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAFscord.Application.Queries
{
    public class GetCurrentUserQuery : IRequest<Guid>
    {
    }

    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, Guid>
    {
        private readonly IGraphApiService _graphApiService;

        public GetCurrentUserQueryHandler(IGraphApiService graphApiService)
        {
            _graphApiService = graphApiService;
        }

        public async Task<Guid> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _graphApiService.GetUserDetails();

            return new Guid(user.Id);
        }
    }
}
