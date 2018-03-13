using System.Web;

namespace Bagaround.Models
{
    public static class SessionMenager
    {
        public static string UserId
        {
            get { return HttpContext.Current.Session["UserId"] as string; }
            set { HttpContext.Current.Session["UserId"] = value; }
        }

        public static string Role
        {
            get { return HttpContext.Current.Session["Role"] as string; }
            set { HttpContext.Current.Session["Role"] = value; }
        }

        public static string Name
        {
            get { return HttpContext.Current.Session["Name"] as string; }
            set { HttpContext.Current.Session["Name"] = value; }
        }

        public static string Username
        {
            get { return HttpContext.Current.Session["Username"] as string; }
            set { HttpContext.Current.Session["Username"] = value; }
        }
    }
}