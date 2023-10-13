using System.ComponentModel.DataAnnotations;

namespace ORAUInterviewEval.Infrastructure.ViewModels
{
    public class Task3ViewModel
    {
        [Required(ErrorMessage = "Comment is required.")]
        public string Comment { get; set; }

    }
}
