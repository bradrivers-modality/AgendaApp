using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace AgendaApp.Bot
{
    public class ClaimsPrincipalHelper : IClaimsPrincipalHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimsPrincipalHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public Guid GetSignedInUserId()
        {
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;
            var userId = claimsPrincipal.Claims.First(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier").Value;

            return Guid.Parse(userId);
        }
    }
}
