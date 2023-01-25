using FAFscord.Application.Commands;
using FAFscord.Application.Common.Dtos.CreateDtos;
using FAFscord.Application.Common.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace FAFscord.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IGraphApiService _graphApiService;

        public UserController(IGraphApiService graphApiService)
        {
            _graphApiService = graphApiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var user = await _graphApiService.GetUserDetails();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDto userCreateDto)
        {
            var command = Map<UserCreateDto, AddUserCommand>(userCreateDto);
            var currentUserId = await GetCurrentLoggedInUserId();
            command.Id = currentUserId;

            await SendCommand(command);

            return Ok();
        }
    }
}
