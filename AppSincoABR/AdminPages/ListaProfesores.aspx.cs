using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR.AdminPages
{
    public partial class ListaProfesores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTeachers();
        }
        protected void GetTeachers()
        {
            List<Profesor> teachers = new GetBusinessLogic().GetTeachers();

            GridView1.DataSource = teachers;
            GridView1.DataBind();
        }
    }
}