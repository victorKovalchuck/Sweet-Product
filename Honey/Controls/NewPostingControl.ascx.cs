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
        public enum BadWords { Блін, Фігня, Лох };
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
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            PostingCRUD postings = new PostingCRUD();
            if (PageID == 0)
            {
                if (ValidateDescription())
                {
                    int result = postings.Add(new Posting
                           {
                               Description = txtDescription.Text,
                               Show = checkShow.Checked,
                               PostedDate = DateTime.Now,
                               UserName = txtUserName.Text,
                               Id = new PostingCRUD().GetNextNumber(),
                               IPAddress = GetIPAddress()
                           });
                    if (result != 0)
                    {
                        Response.Redirect("~/Postings.aspx?IsSuccess=PostingSuccess");
                    }
                    else
                    {
                        Response.Redirect("~/Postings.aspx?IsSuccess=PostingError");
                    }
                }
                else
                {
                    Response.Redirect("~/Postings.aspx?IsSuccess=Forbidden");
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
                Response.Redirect("~/BE/NewPosting.aspx");
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


        public bool ValidateDescription()
        {
            string[] words = txtDescription.Text.Split(' ');
            foreach (string word in words)
            {
                foreach (BadWords badword in Enum.GetValues(typeof(BadWords)))
                {
                    if (string.Equals(word, badword.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }

                }
            }
            return true;
        }

    }
    
}