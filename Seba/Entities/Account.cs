using System.ComponentModel.DataAnnotations;

namespace Seba.Entities
{
	public class Account
    {
		[Key]
		public long Id { get; set; }
		public string Email { get; set; }
		public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public string PasswordSalt { get; set; }
		public string PasswordHash { get; set; }
	}
}
