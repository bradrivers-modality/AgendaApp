using AgendaApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace AgendaApp.Bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgendaItemController : ControllerBase
    {
        private readonly IAgendaItemRepository _agendaItemRepository;

        public AgendaItemController(IAgendaItemRepository agendaItemRepository)
        {
            _agendaItemRepository = agendaItemRepository ?? throw new ArgumentNullException(nameof(agendaItemRepository));
        }

        public IActionResult GetAllForMeeting(string meetingId)
        {
            return string.IsNullOrWhiteSpace(meetingId) ? 
                new ObjectResult("MeetingId not specified") { StatusCode = (int)HttpStatusCode.BadRequest } : 
                new OkObjectResult(_agendaItemRepository.GetAllForMeeting(meetingId));
        }

        public IActionResult Add(AgendaItem agendaItem)
        {
            if (agendaItem == null) return new ObjectResult("No AgendaItem received") { StatusCode = (int)HttpStatusCode.NoContent };

            _agendaItemRepository.Add(agendaItem);
            return new OkResult();
        }
    }
}
