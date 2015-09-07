using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using Honey.BE;

namespace Honey.Controls
{
    public partial class EditSubscriberControl : UserControl
    {
        public int PageID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    return int.Parse(Request.QueryString["ID"]);
                }
                return 0;
            }
        }

        public int DeleteID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["DeleteID"]))
                {
                    return int.Parse(Request.QueryString["DeleteID"]);
                }
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SubscriberCRUD subscriberCrud = new SubscriberCRUD();
                Subscriber subscriber = subscriberCrud.GetList()
                     .Where(x => x.Id == PageID)
                     .FirstOrDefault();
                if (subscriber != null)
                {
                    txtEmail.Text = subscriber.EmailAddress;
                    txtIsActive.Text = subscriber.IsActive.ToString();
                    txtCreatedAt.Text = subscriber.CreatedAt.ToString();
                    txtUpdatedAt.Text = subscriber.UpdatedAt.ToString();
                }
            }
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            Subscriber subscriber = new Subscriber();
            SubscriberCRUD subscriberCrud = new SubscriberCRUD();
            try
            {
                subscriber = new Subscriber()
               {
                   Id = PageID,
                   EmailAddress = txtEmail.Text,
                   IsActive = Convert.ToBoolean(txtIsActive.Text),
                   CreatedAt = Convert.ToDateTime(txtCreatedAt.Text),
                   UpdatedAt = Convert.ToDateTime(txtUpdatedAt.Text)
               };
            }
            catch (Exception ex)
            {
                ((BeMaster)Page.Master).ShowError(ex.Message);
                return;
            }
            subscriberCrud.Update(subscriber);
            Response.Redirect("~/BE/Subscribers.aspx");
        }
    }
}