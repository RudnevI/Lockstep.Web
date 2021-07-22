using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lockstep.Web
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "lobby");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if(exception is null)
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "lobby");
            }
        }
    }
}
