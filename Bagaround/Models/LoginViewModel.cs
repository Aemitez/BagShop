using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bagaround.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Username range of 6-20 character.")]
        [Display(Name = "Username")]
        public string LoginUserName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password range of 6-20 character.")]
        [Display(Name = "Password")]
        public string LoginPassWord { get; set; }
        public bool RememberMe { get; set; }

    }
}