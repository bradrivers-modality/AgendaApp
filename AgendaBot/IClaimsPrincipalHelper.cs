using System;

namespace AgendaApp.Bot
{
    public interface IClaimsPrincipalHelper
    {
        Guid GetSignedInUserId();
    }
}
