using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class PollVote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(PollOption.Id))]
        public int PollOptionId { get; set; }
        public string? CustomValue { get; set; }
    }
}
