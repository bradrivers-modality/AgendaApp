using AgendaApp.Graph.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendaApp.Bot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IClaimsPrincipalHelper _claimsPrincipalHelper;
        private readonly IGraphClient _graphClient;

        public UserController(IClaimsPrincipalHelper claimsPrincipalHelper, IGraphClient graphClient)
        {
            _claimsPrincipalHelper = claimsPrincipalHelper ?? throw new ArgumentNullException(nameof(claimsPrincipalHelper));
            _graphClient = graphClient ?? throw new ArgumentNullException(nameof(graphClient));
        }

        [HttpGet(nameof(GetSignedInUser))]
        public async Task<IActionResult> GetSignedInUser()
        {
            var signedInUserId = _claimsPrincipalHelper.GetSignedInUserId();
            var user = await _graphClient.GetUserByIdAsync(signedInUserId);
            return new OkObjectResult(user);
        }
    }
}
