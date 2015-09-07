using System.IO;
using Honey.DAL.Entity;
using System.Reflection;
using System.Web.UI;
using System.Web;
using Honey.Common;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using Honey.DAL.CRUD;
using System.Text;

namespace Honey.Email
{
    public class EmailHelper
    {      

        private void SendEmail(string from, string to, string subject, string email)
        {                        
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;            
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = email;
            mailMessage.BodyEncoding = Encoding.UTF8;
            
            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("victor.kovalchuck@gmail.com", "21842981");
            smtp.Send(mailMessage);
                           
           
        }

        public void SendSubscriptionEmail(Subscriber subscriber, string emailText, string subject)
        {
            if (subscriber == null)
            {
                return;
            }

            using (StreamReader strReader = new StreamReader(HttpContext.Current.Server.MapPath(@"~\Email\Template.html")))
            {
                string emailTemplate = strReader.ReadToEnd();

                emailTemplate = emailTemplate.Replace(Constants.EMAIL, emailText);
                emailTemplate = emailTemplate.Replace(Constants.UNSUBSCRIBE, Subscriber.GetSubscriberKey(subscriber));
                strReader.Close();
                SendEmail("Victor.Kovalchuck@gmail.com", subscriber.EmailAddress, subject, emailTemplate);
            }
        }
    }
}
    
