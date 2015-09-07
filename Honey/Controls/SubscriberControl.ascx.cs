using System;
using System.Web.UI;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Honey.Controls
{
    public partial class SubscriberControl : UserControl
    {      

        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int result = 0;
            Subscriber subsriber = new Subscriber
            {
                EmailAddress = txtEmailAddress.Text,
                IsActive = true,
                CreatedAt = DateTime.Now,
            };
            SubscriberCRUD subscriberCrud = new SubscriberCRUD();
            Subscriber isExists = subscriberCrud.GetList()
                .Where(x => x.EmailAddress == txtEmailAddress.Text)
                .FirstOrDefault();


            if (isExists == null)
            {
                result = subscriberCrud.Add(subsriber);
            }
            else if (!isExists.IsActive)
            {
                isExists.IsActive = !isExists.IsActive;
                subscriberCrud.Update(isExists);
            }

            if (result == -1)
            {
                Response.Redirect("~/Default.aspx?IsSuccess=SubscribeError");
            }
            Response.Redirect("~/Default.aspx?IsSuccess=SubscribeSuccess");
        }
    }
}