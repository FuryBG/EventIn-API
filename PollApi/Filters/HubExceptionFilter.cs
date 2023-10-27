using Microsoft.AspNetCore.SignalR;

namespace PollApi.Filters
{
    public class HubExceptionFilter: IHubFilter
    {
        public async ValueTask<object?> InvokeMethodAsync(HubInvocationContext invocationContext, Func<HubInvocationContext, ValueTask<object?>> next)
        {
            try
            {
                return await next(invocationContext);
            }
            catch (Exception ex)
            {
                return invocationContext.Hub.Clients.Client(invocationContext.Context.ConnectionId).SendAsync("Exception", ex.Message);
            }
        }
    }
}
