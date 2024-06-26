﻿using Microsoft.AspNetCore.SignalR;

namespace ChatService.Hubs
{
    public class ChatHub: Hub
    {
        private readonly string _botUser;
        private readonly IDictionary<string, UserConnection> _connections;
        public ChatHub(IDictionary<string, UserConnection> connections)
        {
            _botUser = "MyChat Bot";
            _connections = connections;
        }

        public async Task SendMessage(string message)
        {
            if(_connections.TryGetValue(Context.ConnectionId, out UserConnection userConnection))
            {
                await Clients.Group(userConnection.Room)
                    .SendAsync("Receive Message", userConnection.User, message);
            }
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);

            _connections[Context.ConnectionId] = userConnection;

            await Clients.Groups(userConnection.Room).SendAsync("Receive Message", _botUser, 
                $"{userConnection.User} has joined {userConnection.Room}");
        }
    }
}