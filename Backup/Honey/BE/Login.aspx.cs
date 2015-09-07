using System;
using System.Web;
using System.Web.Security;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;

namespace Honey.BE
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) 
        {

      // ((BeMaster)this.Master).d
        }

        public void btnSubmit_Onclick(object sender, EventArgs e)
        {
            UserCRUD userCrud = new UserCRUD();
            User user = userCrud.Login(txtUsername.Text,txtPassword.Text);
            if (user != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                txtUsername.Text,
                DateTime.Now,
                DateTime.Now.AddMinutes(10),
                true,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

                string encTicket = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(
                    FormsAuthentication.FormsCookieName,
                    encTicket);

                HttpContext.Current.Response.Cookies.Add(cookie);
                HttpContext.Current.Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                lblMessage.Visible = true;
                lblMessage.InnerText = "Wrong Input";
            }
        }       
    }
}
