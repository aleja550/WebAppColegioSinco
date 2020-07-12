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
    public partial class Calificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameLabel.Text = $"Notas Estudiante:";
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                int resultUpdate = new UpdateBusinessLogic().EditNotas(new Notas
                {
                    IdNotas = Convert.ToInt32(Request.QueryString["IdNotas"]),
                    Nota1 = txtNota1.Text,
                    Nota2 = txtNota2.Text  
                });

                if(resultUpdate == 0)
                {
                    Response.Write("<script> alert('Las notas no han podido ser actualizadas. ')</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Las notas no han podido ser actualizadas. ')</script>");
                return;
            }

            Response.Write("<script> alert('El estudiante ha sido calificado exitosamente. ')</script>");
            Response.AddHeader("REFRESH", "1;CalificarEstudiantes.aspx");
        }
    }
}