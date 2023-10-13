using System.ComponentModel.DataAnnotations;

namespace ORAUInterviewEval.Core.Models
{
    public class UserProfile
    {
        public string Id { get; set; }
        [MaxLength(99)]
        public string FullName { get; set; }
        public List<UserContact> UserContacts { get; set; }
    }
}
