using System.Threading.Tasks;

namespace AgendaApp.Graph.Abstract
{
    public interface IAuthenticationClient
    {
        Task<string> GetApplicationGraphTokenAsync();
    }
}
