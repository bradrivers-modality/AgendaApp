using AgendaApp.Graph.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaApp.Bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGraphClient _graphClient;

        public UserController(IHttpContextAccessor httpContextAccessor, IGraphClient graphClient)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _graphClient = graphClient ?? throw new ArgumentNullException(nameof(graphClient));
        }

        [HttpGet(nameof(GetSignedInUser))]
        public async Task<IActionResult> GetSignedInUser()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            var userId = claimsPrincipal.Claims.First(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").Value;

            var signedInUserId = Guid.Parse(userId);
            var user = await _graphClient.GetUserByIdAsync(signedInUserId);
            return new OkObjectResult(user);
        }
    }
}
