using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppSincoABR.AdminPages
{
    public partial class CreateUser : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetTemplates();            
                DdlMateria.Visible = false;
                MateriaLbl.Visible = false;
                if(DdlUserType.SelectedValue == "3")
                {  
                    DdlMateria.Visible = true;
                    MateriaLbl.Visible = true;
                }
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

        private void GetTemplates()
        {
            List<EstiloTemplate> templates = new GetBusinessLogic().GetTemplatesList();

            foreach (EstiloTemplate template in templates)
            {
                ListThemes.Items.Add(new ListItem(
                    $"<img class='size' src='data: image / jpg; base64,{template.ImagenTemplate}' />",
                    template.CodigoTemplate.ToString()));
            }
        }

        protected void ButtonSave_Click1(object sender, EventArgs e)
        {
            Usuario usuario = new GetBusinessLogic().GetUser(Usuariotxt.Text);
            if (usuario != null)
            {
                Response.Write("<script> alert('Ya hay un usuario o un profesor con está cedula en el sistema. Valide por favor.')</script>");
                return;
            }

            try
            {
                int userCreated = CreateUsuario();
                
                if(userCreated == 0)
                {
                    Response.Write("<script> alert('El usuario no ha podido ser creado')</script>");
                    return;
                }

                int resultSaving = 0;

                switch (DdlUserType.SelectedValue)
                {
                    case "2":
                        resultSaving = CreateStudent(userCreated);
                        break;
                    case "3":
                        resultSaving = CreateTeacher(userCreated);
                        break;
                    default:
                        Response.Write("<script> alert('Este tipo de usuario no existe.')</script>");
                        break;
                }   

                if(resultSaving == 0)
                {
                    Response.Write("<script> alert('El usuario no ha podido ser creado')</script>");
                    return;
                }

                Response.Write("<script> alert('El usuario se ha creado exitosamente. ')</script>");
                Response.AddHeader("REFRESH", "3;CreateUser.aspx");
            }
            catch (Exception ex)
            {
                Response.Write($"<script> Console.log({ex.Message}, {ex.InnerException},{ex.Source})</script>");
                Response.Write("<script> alert('Ha ocurrido un error intentelo más tarde. ')</script>");
            }
        }

        protected int CreateUsuario()
        {
            int userCreated = new CreateBusinessLogic().CreateUser(new Usuario
            {
                Username = Usuariotxt.Text,
                Contraseña = Clavetxt.Text,
                TipoUser = Convert.ToInt32(DdlUserType.SelectedValue),
                Avatar = Convert.ToBase64String(ThumnailImage()),
                FKCodigoTemplate = Convert.ToInt32(ListThemes.SelectedValue)
            });

            return userCreated;
        }

        protected int CreateTeacher(int idUser)
        {
            int teacherCreated = new CreateBusinessLogic().CreateTeacher(new Profesor
            {
                Cedula = Convert.ToInt64(Cedulatxt.Text),
                Nombres = Nombrestxt.Text,
                Apellidos = Apellidostxt.Text,
                FKUsuario = idUser,
                FkIdMateria = Convert.ToInt32(DdlMateria.SelectedValue)
            });

            return teacherCreated;
        }

        protected int CreateStudent(int idUser)
        {
            int studentCreated = new CreateBusinessLogic().CreateStudent(new Estudiante
            {
                Cedula = Convert.ToInt64(Cedulatxt.Text),
                Nombres = Nombrestxt.Text,
                Apellidos = Apellidostxt.Text,
                FKUsuario = idUser,
            });

            return studentCreated;
        }

        protected void DdlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DdlUserType.SelectedValue)
            {
                case "2":
                    UserTypeName.InnerText = $"Creación Nuevo Estudiante";
                    DdlMateria.Visible = false;
                    MateriaLbl.Visible = false;
                    break;
                case "3":
                    UserTypeName.InnerText = $"Creación Nuevo Profesor";
                    GetAssignatures();
                    DdlMateria.Visible = true;
                    MateriaLbl.Visible = true;
                    break;
                default:
                    Response.Write("<script> alert('Este tipo de usuario no existe.')</script>");
                    break;
            }           
        }

        protected byte[] ThumnailImage()
        {
            int tamaño = fuploadImagen.PostedFile.ContentLength;
            byte[] ImagenOriginal = new byte[tamaño];
            fuploadImagen.PostedFile.InputStream.Read(ImagenOriginal, 0, tamaño);
            Bitmap imagenOriginalBinaria = new Bitmap(fuploadImagen.PostedFile.InputStream);

            System.Drawing.Image imagenredimensionada;
            int Tamanioredimensinado = 200;
            imagenredimensionada = Redimensionarimagen(imagenOriginalBinaria, Tamanioredimensinado);
            byte[] bImagenredimensionada = new byte[Tamanioredimensinado];
            ImageConverter convertidor = new ImageConverter();
            bImagenredimensionada = (byte[])convertidor.ConvertTo(imagenredimensionada, typeof(byte[]));

            return bImagenredimensionada;
        }

        private System.Drawing.Image Redimensionarimagen(System.Drawing.Image ImagenOriginal, int Alto)
        {
            double Radio = (double)Alto / ImagenOriginal.Height;
            int NuevoAncho = (int)(ImagenOriginal.Width * Radio);
            int NuevoAlto = (int)(ImagenOriginal.Height * Radio);
            Bitmap NuevaImagenRedimensionada = new Bitmap(NuevoAncho, NuevoAlto);
            Graphics g = Graphics.FromImage(NuevaImagenRedimensionada);
            g.DrawImage(ImagenOriginal, 0, 0, NuevoAncho, NuevoAlto);
            return NuevaImagenRedimensionada;
        }
    }
}