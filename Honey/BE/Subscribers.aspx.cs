using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;

namespace Honey.BE
{
    public partial class Subscribers : Page
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
            SubscriberCRUD subscriberCrud = new SubscriberCRUD();          
            if (PageID == 0)
            {
                editSubscriber.Visible = false;
                List<Subscriber> subscribers = subscriberCrud.GetList()
                    .OrderByDescending(x => x.CreatedAt)
                    .ToList();
                rptSubscribers.DataSource = subscribers;
                rptSubscribers.DataBind();
            }
            if (DeleteID != 0)
            {
                subscriberCrud.Delete(DeleteID);
                Response.Redirect(@"~/BE/Subscribers.aspx");
            }
        }
    }
}
