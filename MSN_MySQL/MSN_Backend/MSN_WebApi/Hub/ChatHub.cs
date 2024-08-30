using Microsoft.AspNetCore.SignalR;
using MSN_WebApi.ViewModels_DTO;

namespace MSN_WebApi.Hub
{
    public class ChatHub: Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IDictionary<string, UserChatDTO> _connection;
        public ChatHub(IDictionary<string, UserChatDTO> connection)
        {
            _connection = connection;
        }

        public async Task JoinRoom(UserChatDTO userConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userConnection.room);
            _connection[Context.ConnectionId] = userConnection;
            await Clients.Group(userConnection.room)
                .SendAsync("ReceiveMessage", "MSN Bot", $"{userConnection.user} has Joined the Group", DateTime.UtcNow);
            await SendConnectedUser(userConnection.room);
        }

        public async Task SendMessage(string message)
        {
            if(_connection.TryGetValue(Context.ConnectionId, out UserChatDTO userRoomConnection))
            {
                await Clients.Group(userRoomConnection.room)
                    .SendAsync("ReceiveMessage", userRoomConnection.user, message, DateTime.UtcNow);
            }
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            if(!_connection.TryGetValue(Context.ConnectionId, out UserChatDTO roomConnection))
            {
                return base.OnDisconnectedAsync(exception);
            }
            _connection.Remove(Context.ConnectionId);
            Clients.Group(roomConnection.room).SendAsync("ReceiveMessage", "MSN bot", $"{roomConnection.user} has Left the Group", DateTime.UtcNow);
            SendConnectedUser(roomConnection.room);
            return base.OnDisconnectedAsync(exception);
        }

        public Task SendConnectedUser(string room)
        {
            var users = _connection.Values.Where(z => z.room == room).Select(x => x.user);
            return Clients.Group(room).SendAsync("ConnectedUser", users);
        }
    }
}
