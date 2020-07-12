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
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EditStudent();
            }
        }

        protected void EditStudent()
        {
            int idStudent = Convert.ToInt32(Request.QueryString["IdEstudiante"]);

            Estudiante estudiante = new GetBusinessLogic().GetStudent(idStudent);

            txtCedula.Text = estudiante.Cedula.ToString();
            txtNombre.Text = estudiante.Nombres;
            txtApellido.Text = estudiante.Apellidos;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {

            int idStudent = Convert.ToInt32(Request.QueryString["IdEstudiante"]);

            try
            {
                int resultUpdate = new UpdateBusinessLogic().EditStudent(new Estudiante
                {
                    IdEstudiante = idStudent,
                    Cedula = Convert.ToInt64(txtCedula.Text),
                    Nombres = txtNombre.Text,
                    Apellidos = txtApellido.Text
                });
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('El estudiante no ha podido ser actualizado. ')</script>");
            }
           
            Response.Write("<script> alert('El estudiante se ha actualizado exitosamente. ')</script>");
            Response.AddHeader("REFRESH", "1;ListaEstudiantes.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int resultDelete = new DeleteBusinessLogic().DeleteStudent(Convert.ToInt32(Request.QueryString["IdEstudiante"]));
                if(resultDelete == 0)
                {
                    Response.Write("<script> alert('No se ha realizado modificación en el usuario.')</script>");
                    return;
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('El estudiante no ha podido ser eliminado. ')</script>");
            }
         
            Response.Write("<script> alert('El estudiante se ha eliminado exitosamente. ')</script>");
            Response.AddHeader("REFRESH", "1;ListaEstudiantes.aspx");
        }
    }
}