using FAFscord.Application.Common.Interfaces.Services;
using Microsoft.Graph;

namespace FAFscord.Infrastructure.External.Services
{
    public class GraphApiService : IGraphApiService
    {
        private readonly GraphServiceClient _graphClient;

        public GraphApiService(GraphServiceClient graphClient)
        {
            _graphClient = graphClient;
        }
        
        public async Task<User> GetUserDetails()
        {
            var userDetails = await _graphClient.Me.Request()
                .Select(user => new
                {
                    user.Id,
                    user.DisplayName,
                    user.MailNickname,
                }).GetAsync();

            return userDetails;
        }
    }
}
