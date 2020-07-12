using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR.StudentPages
{
    public partial class ReporteNotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetReporte();
        }

        protected void GetReporte()
        {
            string userName = Convert.ToString(Session["Usuario"]);
            GridView1.DataSource = new GetBusinessLogic().GetReport(userName);
            GridView1.DataBind();
        }
    }
}