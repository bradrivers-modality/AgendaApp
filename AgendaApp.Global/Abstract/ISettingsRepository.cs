namespace AgendaApp.Global.Abstract
{
    public interface ISettingsRepository
    {
        string MicrosoftAppId { get; }
        string MicrosoftAppPassword { get; }
        string ApplicationAudience { get; }
        string[] ValidTenantIds { get; }
        string TenantId { get; }
    }
}
