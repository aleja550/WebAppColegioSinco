using System;

using Entities;
using Logic;

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
            Usuario usuario = new GetBusinessLogic().LoginUser(username, password);

            if(usuario == null)
            {
                Response.Write("<script> alert('Verifique los datos. El usuario y/o contraseña son incorrectos.')</script>");
                Session["Usuario"] = ErrorPage;
                return;
            }

            Session["Usuario"] = txtUsuario.Text;
            Session["Clave"] = txtClave.Text;
            Session["TipoUser"] = usuario.TipoUser.ToString();
            Session["Avatar"] = usuario.Avatar;
            Session["FkCodigoTemplate"] = usuario.FKCodigoTemplate.ToString();

            Redirect(usuario.TipoUser);
        }

        protected void Redirect(int tipoUser)
        {
            switch (tipoUser)
            {
                case 1:
                    Response.Redirect($"AdminPages/DefaultAdmin.aspx?Administrador={txtUsuario.Text}");
                    break;
                case 2:
                    Response.Redirect("StudentPages/DefaultStudent.aspx?Estudiante=" + txtUsuario.Text);                   
                    break;
                case 3:
                    Response.Redirect("TeacherPages/DefaultTeacher.aspx?Profesor=" + txtUsuario.Text);
                    break;
                default:
                    Response.Write("<script> alert('Usted no tiene ningún tipo de usuario asignado. Contacte con el administrador.')</script>");
                    Session["Usuario"] = ErrorPage;
                    break;
            }
        }
    }
}