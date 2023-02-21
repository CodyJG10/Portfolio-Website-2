using System.ComponentModel.DataAnnotations;

namespace DevPortfolio.Models
{
    public class ContactFormModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Please enter your message")]
        public string Message { get; set; }
    }
}