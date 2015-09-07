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
        public int IsSuccess
        {
            get
            {
                if (Request.QueryString["IsSuccess"] == "Success")
                {
                    return 1;
                }
                else if (Request.QueryString["IsSuccess"] == "Error")
                {
                    return 0;
                }
                return -1;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsSuccess == 1)
            {
                ((UserMaster)this.Page.Master).ShowSuccess("Subscriber edited succesfuly");
            }
            else if (IsSuccess == 0)
            {
                ((UserMaster)this.Page.Master).ShowError("Subscriber edited error");
            }
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
                Response.Redirect("~/Default.aspx?IsSuccess=Error");
            }
            Response.Redirect("~/Default.aspx?IsSuccess=Success");
        }
    }
}