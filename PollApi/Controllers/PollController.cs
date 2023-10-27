using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace PollApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollController : Controller
    {
        private readonly IPollEventService _eventService;
        public PollController(IPollEventService pollEventService)
        {
            _eventService = pollEventService;
        }
        [Authorize]
        [HttpGet("GetAllUserPolls")]
        public IActionResult GetAllUserPolls()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<PollEvent> pollEvents = _eventService.GetAllUserPolls(userId);
            return Ok(pollEvents);
        }
        [HttpGet("GetPollByGuid")]
        public IActionResult GetPollByGuid(Guid id)
        {
            PollEvent pollEvent = _eventService.GetPollEventByGuid(id);
            return Ok(pollEvent);
        }
        [Authorize]
        [HttpGet("GetPollById")]
        public IActionResult GetPollById(int id)
        {
            PollEvent pollEvent = _eventService.GetPollEventById(id);
            return Ok(pollEvent);
        }
        [Authorize]
        [HttpPost("CreatePoll")]
        public IActionResult CreatePoll(PollEvent pollEvent)
        {
            pollEvent.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            PollEvent createdEvent = _eventService.CreatePollEvent(pollEvent);
            return Created("", createdEvent);
        }
        [Authorize]
        [HttpPost("UpdatePoll")]
        public IActionResult UpdatePoll(PollEvent pollEvent)
        {
            PollEvent updatedPoll = _eventService.UpdatePollEvent(pollEvent);
            return Ok(updatedPoll);
        }
        [Authorize]
        [HttpPost("DeletePoll")]
        public IActionResult DeletePoll(int pollId)
        {
            _eventService.DeletePollEvent(pollId);
            return Ok();
        }
    }
}
