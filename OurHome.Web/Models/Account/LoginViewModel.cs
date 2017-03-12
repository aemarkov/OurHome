using System.ComponentModel.DataAnnotations;

namespace OurHome.Web.Models.Account
{
    public class LoginViewModel
    {

        public string ReturnUrl { get; set; }
        public string ReturnUrlHash { get; set; }
        public bool IsMultiTenancyEnabled { get; set; }

        public string TenancyName { get; set; }

        [Required]
        public string UsernameOrEmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}