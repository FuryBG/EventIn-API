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
        public async Task JoinRoom(string pollGuid)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, pollGuid);
        }

        public async Task LeaveRoom(string pollGuid)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, pollGuid);
        }

        public async Task PollVote(PollVote pollVote, string pollGuid)
        {
            Clients.Group(pollGuid).SendAsync("PollVote", pollGuid);
        }
    }
}
