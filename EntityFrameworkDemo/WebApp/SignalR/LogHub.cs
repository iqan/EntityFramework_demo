using Microsoft.AspNet.SignalR;

namespace WebApp.SignalR
{
    public class LogHub : Hub
    {
        public static void Send(string log)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<LogHub>();
            context.Clients.All.addLog(log);
        }
    }
}