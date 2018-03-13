using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bagaround.Models
{
    public class UserListModel
    {
        public LoginViewModel LoginModel { get; set; } = new LoginViewModel();
        public RegisterViewModel RegisterModel { get; set; } = new RegisterViewModel();
    }
}