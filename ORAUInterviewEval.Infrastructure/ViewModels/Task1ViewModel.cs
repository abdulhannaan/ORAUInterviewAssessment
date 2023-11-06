using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORAUInterviewEval.Infrastructure.ViewModels
{
    public class Task1ViewModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Primary Email")]
        public string PrimaryEmail { get; set; }
    }
}
