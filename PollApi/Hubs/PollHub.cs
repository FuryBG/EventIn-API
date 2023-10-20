using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.SignalR;

namespace PollApi.Hubs
{
    public class PollHub : Hub
    {
        IPollEventService _eventService;
        IPollVoteService _voteService;
        public PollHub(IPollEventService pollEventService, IPollVoteService voteService)
        {
            _eventService = pollEventService;
            _voteService = voteService;

        }
        public async Task JoinRoom(Guid pollGuid)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, pollGuid.ToString());
            PollEvent pollEvent = _eventService.GetPollEventByGuid(pollGuid);
            Clients.Group(pollGuid.ToString()).SendAsync("PollVote", pollEvent);
        }

        public async Task LeaveRoom(string pollGuid)
        {
            Groups.RemoveFromGroupAsync(Context.ConnectionId, pollGuid);
        }

        public async Task PollVote(PollVote pollVote, Guid pollGuid)
        {
            _voteService.CreateVote(pollVote);
            PollEvent pollEvent = _eventService.GetPollEventByGuid(pollGuid);
            Clients.Group(pollGuid.ToString()).SendAsync("PollVote", pollEvent);
        }
    }
}
