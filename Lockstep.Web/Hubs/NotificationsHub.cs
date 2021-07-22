using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lockstep.Web.Hubs
{
    public class NotificationsHub : Hub
    {
        public async Task Send(string message)
        {
            var userIdentity = Context.User;

            if (!(userIdentity is null)) 
            {
                await Clients.Client(Context.ConnectionId).SendAsync("Send", message);
            }
        }
    }
}
