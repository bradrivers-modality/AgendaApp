using AgendaApp.Graph.Abstract;
using AgendaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AgendaApp.Bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgendaItemController : ControllerBase
    {
        private readonly IAgendaItemRepository _agendaItemRepository;
        private readonly IClaimsPrincipalHelper _claimsPrincipalHelper;
        private readonly IGraphClient _graphClient;

        public AgendaItemController(IAgendaItemRepository agendaItemRepository, IClaimsPrincipalHelper claimsPrincipalHelper, IGraphClient graphClient)
        {
            _agendaItemRepository = agendaItemRepository ?? throw new ArgumentNullException(nameof(agendaItemRepository));
            _claimsPrincipalHelper = claimsPrincipalHelper ?? throw new ArgumentNullException(nameof(claimsPrincipalHelper));
            _graphClient = graphClient ?? throw new ArgumentNullException(nameof(graphClient));
        }

        [HttpGet(nameof(GetAllForMeeting))]
        public IActionResult GetAllForMeeting(string meetingId)
        {
            return string.IsNullOrWhiteSpace(meetingId) ? 
                new ObjectResult("MeetingId not specified") { StatusCode = (int)HttpStatusCode.BadRequest } : 
                new OkObjectResult(_agendaItemRepository.GetAllForMeeting(meetingId));
        }

        [HttpPost(nameof(AddAsync))]
        public async Task<IActionResult> AddAsync(AgendaItem agendaItem)
        {
            if (agendaItem == null) return new ObjectResult("No AgendaItem received") { StatusCode = (int)HttpStatusCode.NoContent };

            _agendaItemRepository.Add(agendaItem);

            // TODO: Set start and end times, call to Graph to get team is not working
            //var agendaItems = _agendaItemRepository.GetAllForMeeting(agendaItem.MeetingId);
            //var signedInUserId = _claimsPrincipalHelper.GetSignedInUserId();
            //var meeting = await _graphClient.GetMeetingForUser(agendaItem.MeetingId, signedInUserId);

            //var sortedAgendaItems = agendaItems.OrderBy(i => i.Order).ToList();
            //var firstAgendaItem = sortedAgendaItems[0];
            //firstAgendaItem.StarTime = meeting.StartDate;
            //firstAgendaItem.EndTime = meeting.StartDate.Add(firstAgendaItem.Duration);

            //for (var i = 1; i < sortedAgendaItems.Count; i++)
            //{
            //    var currentAgendaItem = sortedAgendaItems[i];
            //    currentAgendaItem.StarTime = sortedAgendaItems[i - 1].EndTime;
            //    currentAgendaItem.EndTime = currentAgendaItem.StarTime.Add(currentAgendaItem.Duration);
            //}

            return new OkResult();
        }
    }
}
