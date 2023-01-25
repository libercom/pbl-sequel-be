using FAFscord.API.HubServices.Interfaces;
using FAFscord.Application.Commands;
using FAFscord.Application.Common.Dtos.CreateDtos;
using Microsoft.AspNetCore.Mvc;

namespace FAFscord.API.Controllers
{
    public class MessageController : BaseController
    {
        private readonly IChatHubService _chatHubService;

        public MessageController(IChatHubService chatHubService)
        {
            _chatHubService = chatHubService;
        }

        [HttpPost("sendmessage")]
        public async Task<IActionResult> SendMessage(MessageCreateDto userCreateDto)
        {
            var command = Map<MessageCreateDto, SendMessageCommand>(userCreateDto);
            var currentUserId = await GetCurrentLoggedInUserId();
            command.UserId = currentUserId;

            var result = await SendCommand(command);

            await _chatHubService.SendMessage(command.ChatId, result);

            return Ok();
        }
    }
}
