using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class PollOption
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollOptionId { get; set; }
        [ForeignKey(nameof(PollEvent.PollEventId))]
        public int PollEventId { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public string Type { get; set; }
        public List<PollVote>? Votes { get; set; }
    }
}
