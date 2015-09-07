using System.IO;
using Honey.DAL.Entity;
using System.Web;
using Honey.Common;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace Honey.Email
{
    public class EmailHelper
    {      

        private void SendEmail(string from, string to, string subject, string email)
        {
            string pathToLinkedResource = HttpRuntime.AppDomainAppPath+"App_Themes\\Honey\\Img\\honey-jar.png";

            AlternateView objHTLMAltView = AlternateView.CreateAlternateViewFromString(email, new System.Net.Mime.ContentType("text/html"));
            LinkedResource lincted = new LinkedResource(pathToLinkedResource, MediaTypeNames.Image.Jpeg);
            lincted.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            lincted.ContentId = "SampleImage";
            objHTLMAltView.LinkedResources.Add(lincted);


            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.AlternateViews.Add(objHTLMAltView);


            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("victor.kovalchuck@gmail.com", "none");
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
                SendEmail("victor.Kovalchuck@gmail.com", subscriber.EmailAddress, subject, emailTemplate);
            }
        }
    }
}
    
