using AgendaApp.Graph.Abstract;
using AgendaApp.Models.Graph;
using Flurl.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApp.Graph
{
    public class GraphClient : IGraphClient
    {
        private readonly IAuthenticationClient _authenticationClient;

        public GraphClient(IAuthenticationClient authenticationClient)
        {
            _authenticationClient = authenticationClient ?? throw new ArgumentNullException(nameof(authenticationClient));
        }
        
        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var token = await _authenticationClient.GetApplicationGraphTokenAsync();

            try
            {
                var users = await $"https://graph.microsoft.com/v1.0/users?$filter=id eq '{userId}'"
                    .WithOAuthBearerToken(token)
                    .GetJsonAsync<GraphResponse<User>>();

                return users.Entities.FirstOrDefault();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Meeting> GetMeetingForUser(string meetingId, Guid userId)
        {
            var token = await _authenticationClient.GetApplicationGraphTokenAsync();

            try
            {
                return await $"https://graph.microsoft.com/beta/users/{userId}/onlineMeetings/{meetingId}"
                    .WithOAuthBearerToken(token)
                    .GetJsonAsync<Meeting>();
            }
            catch (FlurlHttpException ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
