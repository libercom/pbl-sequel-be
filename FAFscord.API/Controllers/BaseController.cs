using AutoMapper;
using FAFscord.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FAFscord.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    [Authorize]
    public class BaseController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

        protected async Task<TResponse> SendQuery<TResponse>(IRequest<TResponse> request)
        {
            var result = await Mediator.Send(request);

            return result;
        }

        protected async Task SendCommand(IRequest request)
        {
            await Mediator.Send(request);
        }

        protected async Task<TResponse> SendCommand<TResponse>(IRequest<TResponse> request)
        {
            var result = await Mediator.Send(request);

            return result;
        }

        protected TTarget Map<TSource, TTarget>(TSource source)
        {
            return Mapper.Map<TSource, TTarget>(source);
        }

        protected async Task<Guid> GetCurrentLoggedInUserId()
        {
            return await SendQuery(new GetCurrentUserQuery());
        }
    }
}
