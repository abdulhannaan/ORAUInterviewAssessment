using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Core.Models
{
    public class Comment
    {
        public string Id { get; set; }
        [MaxLength(99)]
        public string Text { get; set; }
    }
}
