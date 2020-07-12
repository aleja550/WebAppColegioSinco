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
    public partial class CrearMateria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonS_Click(object sender, EventArgs e)
        {
            Materia materia = new GetBusinessLogic().GetMateriaByName(Materiatxt.Text);
            if (materia != null)
            {
                Response.Write("<script> alert('Ya hay una materia creada con este nombre. Valide por favor.')</script>");
                return;
            }

            try
            {
                int assignatureCreated = new CreateBusinessLogic().CreateAssignature(Materiatxt.Text);

                if (assignatureCreated == 0)
                {
                    Response.Write("<script> alert('La materia no ha podido ser creada')</script>");
                    return;
                }
                Materiatxt.Text = string.Empty;
                Response.Write("<script> alert('La materia se ha creado exitosamente. ')</script>");               
                Response.AddHeader("REFRESH", "3;CrearMateria.aspx");
            }
            catch(Exception ex)
            {
                Response.Write($"<script> Console.log({ex.Message}, {ex.InnerException},{ex.Source})</script>");
                Response.Write("<script> alert('Ha ocurrido un error intentelo más tarde. ')</script>");
            }
        }
    }
}