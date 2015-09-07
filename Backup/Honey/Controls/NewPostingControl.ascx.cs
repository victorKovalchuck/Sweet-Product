using System;
using System.Web.UI;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Honey.Controls
{  
    public partial class NewPostingControl : UserControl
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
        public int IsSuccess
        {
            get
            {
                if (Request.QueryString["IsSuccess"]=="Success")
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
            
            PostingCRUD postingCrud = new PostingCRUD();
            if (!IsPostBack && PageID != 0)
            {

                Posting postings = postingCrud.GetList()
                    .Where(x => x.Id == PageID)
                    .FirstOrDefault();

                txtUserName.Text = postings.UserName;
                txtDescription.Text = postings.Description;
                checkShow.Checked = postings.Show;
            }

            if (DeleteID != 0)
            {

                postingCrud.Delete(DeleteID);
                Response.Redirect("~/Postings.aspx");
            }

            if (IsSuccess == 1)
            {
                ((UserMaster)this.Page.Master).ShowSuccess("Posting edited succesfuly");              
            }
            else if (IsSuccess == 0)
            {
                ((UserMaster)this.Page.Master).ShowError("Posting edited error");              
            }
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            PostingCRUD postings = new PostingCRUD();           
            if (PageID == 0)
            {
             int result= postings.Add(new Posting
                    {
                        Description = txtDescription.Text,
                        Show = true,
                        PostedDate = DateTime.Now,
                        UserName = txtUserName.Text,
                        Id = new PostingCRUD().GetNextNumber(),
                        IPAddress = GetIPAddress()
                    });
             if (result != 0)
             {

                 Response.Redirect("~/Postings.aspx?IsSuccess=Success");
             }
             else
             {
                 Response.Redirect("~/Postings.aspx?IsSuccess=Error");
             }
            }
            else
            {

                postings.Update(new Posting
                        {
                            Description = txtDescription.Text,
                            Show = checkShow.Checked,
                            UserName = txtUserName.Text,
                            Id = PageID
                        });
                Response.Redirect("~/Postings.aspx");
            }
        }

        public string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return context.Request.ServerVariables["remote_addr"];
        }              
    }
    
}