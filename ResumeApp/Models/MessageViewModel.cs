

using System.ComponentModel.DataAnnotations;

namespace ResumeApp.Models
{
    public class MessageViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
