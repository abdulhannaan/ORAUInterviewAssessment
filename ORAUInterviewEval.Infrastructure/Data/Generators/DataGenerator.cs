using ORAUInterviewEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Infrastructure.Data.Generators
{
	public class DataGenerator
	{
		private AppDbContext _db { get; set; }


		public DataGenerator(AppDbContext db)
		{
			_db = db;
		}

		public void SeedDatabase()
		{
			for(int i = 0; i < 1000;i += 1)//in production this could be hundreds of thousands
			{
				var newUser = new ApplicationUser();
				newUser.Id = Guid.NewGuid().ToString();
				newUser.FirstName = RandomString(12);
				newUser.LastName = RandomString(8);
				newUser.Email = RandomString(10) + "@test.com";

				newUser.ResumeUpload = new byte[100];//in production this would be ~10MB
				random.NextBytes(newUser.ResumeUpload);



				_db.Users.Add(newUser);
				_db.SaveChanges();
            }
			
		}


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
