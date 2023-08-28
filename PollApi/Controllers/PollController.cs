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
        [HttpGet("GetPollById")]
        public IActionResult GetPollById(int id)
        {
            try
            {
                PollEvent pollEvent = _eventService.GetPollEventById(id);
                return Ok(pollEvent);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("CreatePoll")]
        public IActionResult CreatePoll(PollEvent pollEvent)
        {
            try
            {
                PollEvent createdEvent = _eventService.CreatePollEvent(pollEvent);
                return Ok(createdEvent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost("UpdatePoll")]
        public IActionResult UpdatePoll(PollEvent pollEvent)
        {
            return Ok();
        }
        [Authorize]
        [HttpPost("DeletePoll")]
        public IActionResult DeletePoll(int pollId)
        {
            try
            {
                _eventService.DeletePollEvent(pollId);
                return Ok();
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
