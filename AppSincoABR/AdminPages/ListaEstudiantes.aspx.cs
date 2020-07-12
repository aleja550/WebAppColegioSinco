using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR.AdminPages
{
    public partial class ListaEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetStudents();
        }

        protected void GetStudents()
        {
            List<Estudiante> students = new GetBusinessLogic().GetStudents();

            GridView1.DataSource = students;
            GridView1.DataBind();
        }
    }
}