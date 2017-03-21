using System.ComponentModel.DataAnnotations;

namespace CloudApp.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "الأيميل")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمة المرور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تأكيد كلمه المرور")]
        [Compare("Password", ErrorMessage = "كلمات المرور غير متشابهة الرجاء التعديل")]
        public string ConfirmPassword { get; set; }
    }
}
