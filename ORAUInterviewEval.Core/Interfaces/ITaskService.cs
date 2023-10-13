using ORAUInterviewEval.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Core.Interfaces
{
    public interface ITaskService
    {
        void SaveEmail(string email);

        void SaveComment(string commentStr);

        void SaveProfile(ProfileModel profile);
		List<ApplicationUser> GetUsers(int pageIndex, int pageSize);
        int GetTotalUsersCount();
	}

    public class ProfileModel
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; }

        public List<ContactModel> Contacts { get; set; }

    }

    public class ContactModel
    {
        public string Address { get; set; }

        public string City { get; set; }

    }

}
