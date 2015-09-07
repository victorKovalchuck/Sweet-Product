using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.Entity;
using System.Text;
using Honey.DAL.CRUD;

namespace Honey.Controls
{
    public partial class NewTopicControl : System.Web.UI.UserControl
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

        TopicCRUD topicCrud = new TopicCRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && PageID != 0)
            {
                Topic topic = topicCrud.GetList()
                    .Where(x => x.Id == PageID)
                    .FirstOrDefault();

                string encode = Encoding.UTF8.GetString(Convert.FromBase64String(topic.Content));
                txtbxCode.Text = topic.Code;
                txtbxContent.Text = encode;
            }            
        }
        public void btnSubmit_Click(object sender, EventArgs e)
        {
            if (PageID != 0)
            {
                var bytes = Encoding.UTF8.GetBytes(txtbxContent.Text);
                topicCrud.Update(new Topic
                {
                    Code = txtbxCode.Text,
                    Content = Convert.ToBase64String(bytes),
                    Id = PageID
                });                
            }
            else
            {
                var bytes = Encoding.UTF8.GetBytes(txtbxContent.Text);
                topicCrud.Add(new Topic
                {
                    Code = txtbxCode.Text,
                    Content = Convert.ToBase64String(bytes),
                    Id = topicCrud.GetNextNumber()
                });                
            }
            Response.Redirect("~/BE/Topics.aspx");
        }
    }
}