using FAFscord.Application.Commands;
using FAFscord.Application.Common.Dtos.CreateDtos;
using Microsoft.AspNetCore.Mvc;
using FAFscord.Application.Queries;

namespace FAFscord.API.Controllers
{
    public class ChatController : BaseController
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateChat(ChatCreateDto userCreateDto)
        {
            var command = Map<ChatCreateDto, AddChatCommand>(userCreateDto);
            var currentUserId = await GetCurrentLoggedInUserId();
            command.UserId = currentUserId;

            await SendCommand(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetChatsForUser()
        {
            var currentUserId = await GetCurrentLoggedInUserId();

            var result = await SendQuery(new GetUserChatsQuery(currentUserId));

            return Ok(result);
        }

        [HttpGet("{chatId}/messages")]
        public async Task<IActionResult> GetChatMessages([FromRoute] Guid chatId)
        {
            var result = await SendQuery(new GetChatMessagesQuery(chatId));

            return Ok(result);
        }
    }
}
