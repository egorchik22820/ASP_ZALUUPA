using System.ComponentModel.DataAnnotations;

namespace ASP_ZALUUPA.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string? UserName {  get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [UIHint("Password")]
        public string? Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
