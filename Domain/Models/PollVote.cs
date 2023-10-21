using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class PollVote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollVoteId { get; set; }
        [ForeignKey(nameof(PollOption.PollOptionId))]
        public int PollOptionId { get; set; }
        [ForeignKey(nameof(PollEvent.PollEventId))]
        public int PollEventId { get; set; }
        public string? CustomValue { get; set; }
    }
}
