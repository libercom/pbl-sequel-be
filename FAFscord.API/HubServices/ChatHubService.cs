using FAFscord.API.Hubs;
using FAFscord.API.HubServices.Interfaces;
using FAFscord.Application.Common.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace FAFscord.API.HubServices
{
    public class ChatHubService : IChatHubService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatHubService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessage(Guid chatId, MessageDto message)
        {
            await _hubContext.Clients.Group(chatId.ToString()).SendAsync("SendMessage", message);
        }
    }
}
