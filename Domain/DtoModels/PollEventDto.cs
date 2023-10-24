using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.DtoModels
{
    public class PollEventDto
    {
        public int PollEventId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public Guid EventGuid { get; set; }
        public bool IsActive { get; set; }
        public List<PollOptionDto> Options { get; set; }
    }
}
