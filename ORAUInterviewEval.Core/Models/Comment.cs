using System.ComponentModel.DataAnnotations;

namespace ORAUInterviewEval.Core.Models
{
    public class Comment
    {
        public string Id { get; set; }
        [MaxLength(99)]
        public string Text { get; set; }
    }
}
