using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace PollApi.Hubs
{
    public class PollHub : Hub
    {
        IPollEventService _eventService;
        public PollHub(IPollEventService pollEventService)
        {
            _eventService = pollEventService;
        }
        public async Task JoinRoom(string roomId)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task LeaveRoom(string roomId)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId);
        }

        public async Task PollVote(PollVote pollVote, string roomId)
        {
            Clients.Group(roomId).SendAsync("Test", pollVote);
        }
    }
}
