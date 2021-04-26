using AgendaApp.Models.Graph;
using System;
using System.Threading.Tasks;

namespace AgendaApp.Graph.Abstract
{
    public interface IGraphClient
    {
        Task<User> GetUserByIdAsync(Guid userId);
        Task<Meeting> GetMeetingForUser(string meetingId, Guid userId);
    }
}
