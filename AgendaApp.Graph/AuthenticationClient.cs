using AgendaApp.Global.Abstract;
using AgendaApp.Graph.Abstract;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendaApp.Graph
{
    public class AuthenticationClient : IAuthenticationClient
    {
        private readonly ISettingsRepository _settingsRepository;

        public AuthenticationClient(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<string> GetApplicationGraphTokenAsync()
        {
            var token = await ConfidentialClientApplicationBuilder
                .Create(_settingsRepository.MicrosoftAppId)
                .WithClientSecret(_settingsRepository.MicrosoftAppPassword)
                .WithAuthority($"https://login.microsoftonline.com/{_settingsRepository.TenantId}")
                .Build()
                .AcquireTokenForClient(new List<string>
                    {"https://graph.microsoft.com/.default"}).ExecuteAsync();
            return token.AccessToken;
        }
    }
}
