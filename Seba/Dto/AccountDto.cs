using System.ComponentModel.DataAnnotations;

namespace Seba.Dto
{
	public class AccountDto
    {
		[EmailAddress, Required]
		public string Email { get; set; }
		[MinLength(6, ErrorMessage = "Minimalna długość ")]
		public string Login { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
		public string Password { get; set; }
    }
}
