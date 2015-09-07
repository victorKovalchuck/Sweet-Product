using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Honey.Controls
{
    public partial class MasterIsSuccessShowControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string request = Request.QueryString["IsSuccess"];
            switch (request)
            {
                case "SuccessPurchase":
                    ((UserMaster)this.Page.Master).ShowSuccess("Замовлення прийнято");
                    break;
                case "ErrorPurchase":
                    ((UserMaster)this.Page.Master).ShowError("Замовлення відхилено");
                    break;
                case "SubscribeSuccess":
                    ((UserMaster)this.Page.Master).ShowSuccess("Реєстрація пройшла успішно");
                    break;
                case "SubscribeError":
                    ((UserMaster)this.Page.Master).ShowError("Помилка реєстрації");
                    break;
                case "PostingSuccess":
                    ((UserMaster)this.Page.Master).ShowSuccess("Ваш відгук прийнятий і знаходиться в процесі обробки");
                    break;
                case "PostingError":
                    ((UserMaster)this.Page.Master).ShowError("Відгук не додано");
                    break;
                case "Forbidden":
                    ((UserMaster)this.Page.Master).ShowError("Опис містить заборонені слова");
                    break;
            }
        }
    }
}