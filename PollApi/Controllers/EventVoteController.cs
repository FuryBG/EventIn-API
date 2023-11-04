using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;
using System.Security.Claims;

namespace PollApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollVoteController : Controller
    {
        private readonly IPollVoteService _pollVoteService;
        public PollVoteController(IPollVoteService pollEventService)
        {
            _pollVoteService = pollEventService;
        }
        [Authorize]
        [HttpPost("CreateVote")]
        public IActionResult CreateVote(PollVote pollVote)
        {
            PollVote vote = _pollVoteService.CreateVote(pollVote);
            return Ok(vote);
        }
        [Authorize]
        [HttpPost("UpdateVote")]
        public IActionResult UpdateVote(PollVote pollVote)
        {
            PollVote vote = _pollVoteService.UpdateVote(pollVote);
            return Ok(vote);
        }
        [Authorize]
        [HttpGet("ResetVotes")]
        public IActionResult ResetVotes(int pollEventId)
        {
            _pollVoteService.DeleteEventVotes(pollEventId);
            return Ok();
        }
    }
}
