using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR.TeacherPages
{
    public partial class CalificarEstudiantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAssignatures();
            }
        }

        protected void GetAssignatures()
        {
            List<Materia> assignatures = new GetBusinessLogic().GetAssignaturesByTeacher(Session["Usuario"].ToString());

            DdlMateria.DataSource = assignatures;
            DdlMateria.DataValueField = "idMateria";
            DdlMateria.DataTextField = "nombreMateria";
            DdlMateria.DataBind();
            DdlMateria.Items.Insert(0, new ListItem("Seleccione", "0", true));
        }

        protected void DdlMateria_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridView1.DataSource = new GetBusinessLogic().GetNotesWithStudents(Convert.ToInt32(DdlMateria.SelectedValue));
            GridView1.DataBind();
        }
    }
}