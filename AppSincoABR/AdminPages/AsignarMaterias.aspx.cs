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
    public partial class AsignarMaterias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Estudiante student = new GetBusinessLogic().GetStudent(Convert.ToInt32(Request.QueryString["IdEstudiante"])); 
            NameLabel.Text = $"Estudiante: {student.Nombres} {student.Apellidos}";
            if (!IsPostBack)
            {
                GetAssignatures();
            }               
        }

        private void GetAssignatures()
        {
            List<Materia> assignatures = new GetBusinessLogic().GetAssignaturesList();

            DdlMateria.DataSource = assignatures;
            DdlMateria.DataValueField = "idMateria";
            DdlMateria.DataTextField = "nombreMateria";
            DdlMateria.DataBind();
            DdlMateria.Items.Insert(0, new ListItem("Seleccione", "0", true));
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int notesCreated = new CreateBusinessLogic().CreateNotes(new Notas
                {
                    Nota1 = null,
                    Nota2 = null,
                    FKIdMateria = Convert.ToInt32(DdlMateria.SelectedValue),
                    FKIdEstudiante = Convert.ToInt32(Request.QueryString["IdEstudiante"])
                });

                if (notesCreated == 0)
                {
                    Response.Write("<script> alert('No se ha podido asignar la materia al estudiante ')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('No se ha podido asignar la materia al estudiante ')</script>");
            }
            Response.Write("<script> alert('El estudiante se le ha asignado la materia exitosamente.')</script>");
            Response.AddHeader("REFRESH", "1;ListaEstudiantes.aspx");
        }
    }
}