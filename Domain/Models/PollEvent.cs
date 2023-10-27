using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Models
{
    public class PollEvent
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PollEventId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EventGuid { get; set; }
        [ForeignKey(nameof(User.Id))]
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        [AllowNull]
        public List<PollOption>? Options { get; set; }

    }
}
