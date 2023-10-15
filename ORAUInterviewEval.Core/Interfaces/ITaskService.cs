using ORAUInterviewEval.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace ORAUInterviewEval.Core.Interfaces
{
    public interface ITaskService
    {
        void SaveEmail(string email);

        void SaveComment(string commentStr);

        void SaveProfile(ProfileModel profile);
        Task6ViewModel GetUsers(int pageIndex, int pageSize, string searchKeywords, string sortColumn, string sortColumnDirection);
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

	public class Task6ViewModel
	{
		public List<ApplicationUser> Users { get; set; }
		public int Total { get; set; }

	}

}
