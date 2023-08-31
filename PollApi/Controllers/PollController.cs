using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS;

namespace PollApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollController : ControllerBase
    {
        private readonly IPollEventService _eventService;
        public PollController(IPollEventService pollEventService)
        {
            _eventService = pollEventService;
        }
        [Authorize]
        [HttpGet("GetPollByGuid")]
        public IActionResult GetPollByGuid(Guid id)
        {
            PollEvent pollEvent = _eventService.GetPollEventByGuid(id);
            return Ok(pollEvent);
        }
        [Authorize]
        [HttpPost("CreatePoll")]
        public IActionResult CreatePoll(PollEvent pollEvent)
        {
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
