using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using Honey.Email;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Net.Mail;


namespace Honey.BE
{
    public partial class SendEmail : Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubscriberCRUD subscriberCrud = new SubscriberCRUD();
                
                List<string> listOfAddresses = (subscriberCrud.GetList()
                .Where(x => x.IsActive == true))
                .Select(x => x.EmailAddress)
                .ToList();

                listOfAddresses.ForEach(address =>
                {
                    lblAddresses.Text += address + ", ";
                });
            }                                 
        }

        public void btnSend_OnClick(object sender, EventArgs e)
        {
            int error = 0;
            int succes = 0;            
            List<Subscriber> subscribers = GetListOFSubscribers();
            // EmailHelper
            foreach (Subscriber subscriber in subscribers)
            {
                try
                {
                    // send
                    // ---> subscriber.UpdatedAt = DateTime.Today
                    EmailHelper helper = new EmailHelper();
                    helper.SendSubscriptionEmail(subscriber, txtEmail.Text, txtSubject.Text);
                    new SubscriberCRUD().UpdateByEmail(subscriber.EmailAddress);
                    succes++;
                }
                catch (SmtpException)
                {
                    error++;
                }            
            }
           
            if (succes > error)
            {
                ((BeMaster)this.Page.Master).ShowSuccess(string.Format("Success:{0},Error:{1}", succes, error));
            }
            else
            {
                ((BeMaster)this.Page.Master).ShowError(string.Format("Error:{0},Success:{1}", error, succes));
            }
        }

        public List<Subscriber> GetListOFSubscribers()
        {
            SubscriberCRUD subscriberCrud = new SubscriberCRUD();
            List<Subscriber> subscribers = subscriberCrud.GetList()
            .Where(x => x.IsActive == true)
            .OrderBy(x => x.Id)
            .ToList();
            return subscribers;
        }
    }
}
