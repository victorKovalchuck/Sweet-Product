using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.Entity;
using Honey.DAL.CRUD;

namespace Honey
{

    public partial class Unsubscribe : Page
    {
        public Subscriber User
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.Url.Query))
                {
                    try
                    {
                        Subscriber subscriber = Subscriber.GetSubscriberFromKey(Request.Url.Query);
                        return subscriber;
                    }
                    catch
                    {
                        return null;
                    }
                }
                return null;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User != null)
            {
                SubscriberCRUD subscriberCrud = new SubscriberCRUD();
                //subscriberCrud.Delete(User.Id);
            }
        }
    }
}
