using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ORAUInterviewEval.Infrastructure.ViewModels
{
    public class Task2ViewModel
    {
        [Required]
        [DisplayName("Program")]
        public int ProgramId { get; set; }


        public string? Other { get; set; }

    }
}
