using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required] 
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string HashPassword { get; set; }
        public string ActivationHash { get; set; }
        public bool Active { get; set; }
        public List<PollEvent> Events { get; set; }
        public PollLicense License { get; set; }
    }
}
