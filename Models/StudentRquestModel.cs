using System.ComponentModel.DataAnnotations;

namespace studentregestration.Models
{
    public class StudentRquestModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "PhoneNumber must be 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        [EmailAddress(ErrorMessage = "Invalid EmailId format")]
        public string EmailId { get; set; }

        public List<int> ClassIds { get; set; }
    }
}
