using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR.AdminPages
{
    public partial class DefaultAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserName.Text = $"   Bienvenido a tu Dashboard {Convert.ToString(Session["Usuario"])}";
        }
    }
}