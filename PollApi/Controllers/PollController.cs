using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PollApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PollController : ControllerBase
    {
        [HttpGet("GetPollById")]
        public IActionResult GetPollById(int id)
        {
            return Ok();
        }
        [HttpPost("CreatePoll")]
        public IActionResult CreatePoll(PollEvent pollEvent)
        {
            return Ok();
        }
        [HttpPost("UpdatePoll")]
        public IActionResult UpdatePoll(PollEvent pollEvent)
        {
            return Ok();
        }
        [HttpPost("DeletePoll")]
        public IActionResult DeletePoll(int pollId)
        {
            return Ok();
        }
    }
}
