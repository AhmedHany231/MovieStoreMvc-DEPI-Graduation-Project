using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvc.Models.ViewModels
{
	public class RegisterViewModel
	{
		[StringLength(256)]
		[Display(Name="User Name")]
		public string UserName { get; set; }
		[StringLength(256)]
		[Display(Name = "Email")]
		[EmailAddress]
		public string Email { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
        [DataType(DataType.Password)]
		[Compare("Password")]
        [Display(Name = "Confirm Password")]

        public string ConfirmPassword { get; set; }

	}
}
