using FAFscord.Application.Common.Dtos;

namespace FAFscord.API.HubServices.Interfaces
{
    public interface IChatHubService
    {
        Task SendMessage(Guid chatId, MessageDto message);
    }
}
