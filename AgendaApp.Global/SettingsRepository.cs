using AgendaApp.Global.Abstract;
using Microsoft.Extensions.Configuration;

namespace AgendaApp.Global
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly IConfiguration _config;

        public SettingsRepository(IConfiguration config)
        {
            _config = config;
        }

        public string MicrosoftAppId => _config[nameof(MicrosoftAppId)];
        public string MicrosoftAppPassword => _config[nameof(MicrosoftAppPassword)];
        public string ApplicationAudience => _config[nameof(ApplicationAudience)];
        public string[] ValidTenantIds => _config[nameof(ValidTenantIds)].Split(',');
        public string TenantId => _config.GetSection("AzureAd")[nameof(TenantId)];
    }
}
