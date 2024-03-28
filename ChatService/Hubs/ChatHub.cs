using Microsoft.AspNetCore.SignalR;

namespace ChatService.Hubs
{
    public class ChatHub: Hub
    {
        private readonly string _botUser;
    public ChatHub()
        {
            _botUser = "MyChat Bot";
        }

        public async Task JoinRoom(UserConnection userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.Room);
            await Clients.Groups(userConnection.Room).SendAsync("Receive Message", _botUser, 
                $"{userConnection.User} has joined {userConnection.Room}");
        }
    }
}