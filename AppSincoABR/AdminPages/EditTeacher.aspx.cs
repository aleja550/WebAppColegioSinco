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
    public partial class EditTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EditProfesor();
            }
        }

        protected void EditProfesor()
        {
            int IdProfesor = Convert.ToInt32(Request.QueryString["IdProfesor"]);

            Profesor profesor = new GetBusinessLogic().GetTeacher(IdProfesor);

            txtCedula.Text = profesor.Cedula.ToString();
            txtNombre.Text = profesor.Nombres;
            txtApellido.Text = profesor.Apellidos;
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            int IdProfesor = Convert.ToInt32(Request.QueryString["IdProfesor"]);

            try
            {
                int resultUpdate = new UpdateBusinessLogic().EditProfesor(new Profesor
                {
                    IdProfesor = IdProfesor,
                    Cedula = Convert.ToInt64(txtCedula.Text),
                    Nombres = txtNombre.Text,
                    Apellidos = txtApellido.Text
                });

                if(resultUpdate == 0)
                {
                    Response.Write("<script> alert('El profesor no ha podido ser actualizado. ')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('El profesor no ha podido ser actualizado. ')</script>");
                return;
            }

            Response.Write("<script> alert('El profesor se ha actualizado exitosamente. ')</script>");
            Response.AddHeader("REFRESH", "1;ListaProfesores.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int resultDelete = new DeleteBusinessLogic().DeleteTeacher(Convert.ToInt32(Request.QueryString["IdProfesor"]));
                if (resultDelete == 0)
                {
                    Response.Write("<script> alert('No se ha realizado modificación en el usuario.')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('El profesor no ha podido ser eliminado. ')</script>");
                return;
            }

            Response.Write("<script> alert('El profesor se ha eliminado exitosamente. ')</script>");
            Response.AddHeader("REFRESH", "1;ListaProfesores.aspx");
        }
    }
}