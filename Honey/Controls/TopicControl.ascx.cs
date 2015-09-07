using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Honey.DAL.CRUD;
using Honey.DAL.Entity;
using System.Text;
using System.Web.Resources;
using System.IO;


namespace Honey.Controls
{
    public partial class TopicControl : UserControl
    {
        private string _code;
        public string Code
        {
            get
            {
                return _code;
            }
            set 
            {
                _code = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            TopicCRUD topicCrud = new TopicCRUD();
            Topic topic = topicCrud.GetList()
                .Where(x => x.Code == Code)
                .FirstOrDefault();
            if (topic == null || topic.Content=="")
            {
                return;
            }
            string encode = Encoding.UTF8.GetString(Convert.FromBase64String(topic.Content));
            litContent.Text = encode;
        }
    }
}