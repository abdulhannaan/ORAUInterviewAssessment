using Microsoft.EntityFrameworkCore;
using ORAUInterviewEval.Core.Interfaces;
using ORAUInterviewEval.Core.Models;
using ORAUInterviewEval.Infrastructure.Data;
using System.Net.Http.Headers;

namespace ORAUInterviewEval.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private AppDbContext _db { get; set; }
        public TaskService(AppDbContext db)
        {
            _db = db;
        }


        public void SaveEmail(string email)
        {
            var user = _db.Users.FirstOrDefault();
            if(user != null)
            {
                user.Email = email;
                _db.Users.Update(user);
                _db.SaveChanges();
            }
            else
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
        }

        public void SaveComment(string commentStr)
        {
            var comment = new Comment();
            comment.Id = Guid.NewGuid().ToString();
            comment.Text = commentStr;
            _db.Comments.Add(comment);
            _db.SaveChanges();
        }

        public void SaveProfile(ProfileModel profile)
        {
            if (profile != null)
            {
                var userProfile = new UserProfile();
                userProfile.Id = Guid.NewGuid().ToString();
                userProfile.FullName = profile.FullName;
                _db.UserProfiles.Add(userProfile);

                var userContacts = profile.Contacts.Select(contact => new UserContact
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = contact.Address,
                    City = contact.City,
                    UserProfileId = userProfile.Id
                }).ToList();

                _db.UserContacts.AddRange(userContacts);
                _db.SaveChanges();
            }
            else
                throw new ArgumentNullException(nameof(profile), "User cannot be null.");
        }

		/// <summary>
		/// Retrieves a paginated list of users from the database.
		/// </summary>
		/// <param name="pageIndex">The index of the page to retrieve (1-based).</param>
		/// <param name="pageSize">The number of users per page.</param>
		/// <returns>A list of ApplicationUser objects.</returns>
		public List<ApplicationUser> GetUsers(int pageIndex, int pageSize)
        {
            var result = _db.Users
                .Skip((pageIndex - 1) * pageSize)  // Skip the first (pageIndex - 1) * pageSize records
				.Take(pageSize).Select(u => new ApplicationUser // Take only 'pageSize' records
				{
					
					Id = u.Id,
                    FirstName =u.FirstName,
                    LastName =u.LastName,
                    Email = u.Email
                }).AsNoTracking(); // Mark the objects as not being tracked by the context
                                   // No-tracking queries are useful when the results are used in a read-only scenario.
								   // They're generally quicker to execute because there's no need to set up the change tracking information

			return result.ToList();
        }

		public int GetTotalUsersCount()
		{
			return _db.Users.ToList().Count();
		}
	}
}
