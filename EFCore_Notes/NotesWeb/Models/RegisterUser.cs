using System.ComponentModel.DataAnnotations;

namespace NotesWeb.Models
{
	public class RegisterUser
	{
		[Required(ErrorMessage = "Please enter firstname")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Please enter lastname")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter email"), EmailAddress]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter password")]
		public string Password { get; set; }
	}
}
