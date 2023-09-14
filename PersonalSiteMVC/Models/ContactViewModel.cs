using System.ComponentModel.DataAnnotations;// Added to grant access to annotations for validation

namespace PersonalSiteMVC.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "A message is required")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}
