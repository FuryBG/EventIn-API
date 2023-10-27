using Domain.Models;

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
        public PollVote? UserVote { get; set; }
        public int VotesCount { get; set; }
        public List<PollOptionDto> Options { get; set; }
    }
}
