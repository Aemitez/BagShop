using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Bagaround.Models
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "user name must be combination of letters and numbers only.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Username range of 6-20 character.")]
        [Remote("DoesUserNameExist", "Login", HttpMethod = "POST", ErrorMessage = "User name already exists.")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password range of 6-20 character.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Password range of 6-20 character.")]
        public string ConfirmPassword { get; set; }

        public int UserId { get; set; }

        [Required]
        [Display(Name = "Firstname")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password range of 3-20 character.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Lastname")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Password range of 3-20 character.")]
        public string LastName { get; set; }

        [Required]
        [Display(Name ="Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Cartdit no")]
        public int CreditCard { get; set; }

        [Required]
        [Display(Name = "Full Address")]
        public string Address { get; set; }

        public string Role { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public List<HistoryPaymentModel> HistoryPayment { get; set; }
    }
}