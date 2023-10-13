using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
