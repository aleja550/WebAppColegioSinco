using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtClave.Text;
            Usuario usuario = new BusinessLogic().LoginUser(username, password);

            if(usuario == null)
            {
                Response.Write("<script> alert(" + "'Verifique los datos'" + ") </script>");
                Session["Usuario"] = ErrorPage;

            } else {
                Session["Usuario"] = usuario.Username;
                Session["Clave"] = usuario.Contraseña;
                Session["TipoUser"] = usuario.TipoUser.ToString();

                if(usuario.TipoUser == 1)
                {
                    Response.Redirect("DefaultStudent.aspx?Estudiante=" + txtUsuario.Text);
                }
            }           
        }
    }
}