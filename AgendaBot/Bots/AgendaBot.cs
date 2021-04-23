using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace AgendaApp.Bot.Bots
{
    public class AgendaBot : ActivityHandler
    {
        public AgendaBot()
        {
            
        }

        protected override Task OnConversationUpdateActivityAsync(ITurnContext<IConversationUpdateActivity> turnContext,
            CancellationToken cancellationToken)
        {
            return base.OnConversationUpdateActivityAsync(turnContext, cancellationToken);
        }

        protected override Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            return base.OnMessageActivityAsync(turnContext, cancellationToken);
        }
    }
}
