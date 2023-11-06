using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ORAUInterviewEval.Core.Models
{
    public partial class ApplicationUser : IdentityUser
    {
        [MaxLength(250)]
        public string? FirstName { get; set; }

        [MaxLength(250)]
        public string? LastName { get; set; }

        public byte[] ResumeUpload { get; set; }

    }
}
