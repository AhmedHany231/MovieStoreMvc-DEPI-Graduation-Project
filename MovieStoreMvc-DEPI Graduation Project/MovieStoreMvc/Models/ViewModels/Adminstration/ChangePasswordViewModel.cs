using System.ComponentModel.DataAnnotations;

namespace MovieStoreMvc.Models.ViewModels.Adminstration
{
    public class ChangePasswordViewModel
    {
        [Display(Name ="Current Password")]
        [DataType(DataType.Password)]
        public string currentPass { get; set; }

        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string newPass { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("newPass")]
        public string confirmPass { get; set; }
    }
}
