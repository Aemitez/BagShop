using Bagaround.Entity;
using Bagaround.Models;
using System.Linq;

namespace Bagaround.Repository
{
    public class UserRepository
    {
        public User GetUser(string username)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                return db.User.SingleOrDefault(x => x.Username == username);
            }
        }

        public void SaveUser(RegisterViewModel dataUser)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var UserData = db.User
                .SingleOrDefault(x => x.UserId == dataUser.UserId);   ////// - selest ID - /////

                UserData.Name = dataUser.Name;
                UserData.LastName = dataUser.LastName;
                UserData.CreditCard = dataUser.CreditCard;
                UserData.Address = dataUser.Address;
                UserData.Description = dataUser.Description;
                db.SaveChanges();
                
            }
        }

        public void Register(RegisterViewModel dataUer)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var UserData = new Entity.User()
                {
                    Username = dataUer.Username,
                    Password = dataUer.Password,
                    Name = dataUer.Name,
                    LastName = dataUer.LastName,
                    CreditCard = dataUer.CreditCard,
                    Email = dataUer.Email,
                    Address = dataUer.Address,
                    Role = "User"
                };
                db.User.Add(UserData);
                db.SaveChanges();
            }
        }

        public User CheckLogin(string username,string password)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var userData = db.User.SingleOrDefault(x=>x.Username==username&&x.Password==password);
                return userData;
            }
            
        }
    }
}