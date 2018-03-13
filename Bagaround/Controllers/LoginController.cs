using Bagaround.Models;
using Bagaround.Repository;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace Bagaround.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository userRepository = new UserRepository();
        private readonly EncryptRepository encrypyRepository = new EncryptRepository();
        public ActionResult Login()
        {
            UserListModel model = new UserListModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CheckLogin(UserListModel usermodel)
        {
            
            var checkLogin = userRepository.CheckLogin(usermodel.LoginModel.LoginUserName,encrypyRepository.Encrypt(usermodel.LoginModel.LoginPassWord));
            if (this.ModelState.IsValid && checkLogin != null)
            {
                FormsAuthentication.SetAuthCookie(usermodel.LoginModel.LoginUserName, usermodel.LoginModel.RememberMe);
                SessionMenager.UserId = checkLogin.UserId.ToString();
                SessionMenager.Role = checkLogin.Role;
                SessionMenager.Name = checkLogin.Name;
                SessionMenager.Username = checkLogin.Username;
            }
            else
            {
                TempData["Message"] = "Login failed.Username or password is invalid!!.";
                return RedirectToAction("Login", "Login");
            }

            return RedirectToAction("Home", "BagShop");
        }

        [HttpPost]
        public ActionResult Register(UserListModel registerData)
        {
            registerData.RegisterModel.Password = encrypyRepository.Encrypt(registerData.RegisterModel.Password);
            userRepository.Register(registerData.RegisterModel);
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Home", "BagShop");
        }
        [HttpPost]
        public JsonResult DoesUserNameExist(UserListModel registerData)
        {
            var user = userRepository.GetUser(registerData.RegisterModel.Username);
            return Json(user == null);
        }
       
    }
}