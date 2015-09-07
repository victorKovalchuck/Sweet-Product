using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.Entity;
using Honey.DAL.CRUD;
using Honey.MetaTagsBase;
namespace Honey
{

    public partial class Unsubscribe : MetaTagsBase.MetaTagsBase
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
                Subscriber subscriber = User;
                if (subscriber.IsActive)
                {
                    subscriber.IsActive = false;
                    subscriberCrud.Update(subscriber);
                }
                ((UserMaster)Page.Master).ShowSuccess("Повідомлення з нашого сайту не надходитимуть на вашу пошту");
                return;
            }
            ((UserMaster)Page.Master).ShowError("Помилка при відписці. Попробуйте ще раз");            
        }
    }
}
