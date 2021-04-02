using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiperChatWebApiCore.Hubs
{
    public class ChatHub:Hub
    {
        Dictionary<int, string> onlineUsers = new Dictionary<int, string>();

        public async Task UserConnected(string user)
        {
            
            Console.WriteLine(user);
            await Clients.Others.SendAsync("NewUserConnected", user);
        }

        public async Task SendMessageToServer(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
            Console.WriteLine("Recieved message" + message);
        }
    }
}
