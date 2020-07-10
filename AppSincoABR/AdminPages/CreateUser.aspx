<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="AppSincoABR.AdminPages.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Crear Usuario</title>

    <link rel="stylesheet" type="text/css" href="../css/ManagementStyle.css" />
    <script src="scripts/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">

    <h1 id="UserTypeName" runat="server">Creación Nuevo Usuario</h1>
    <p>LLene por favor los siguientes campos: </p>

    <section id="form">
        <div>
            <asp:Label ID="TipoUser" Text="Tipo Usuario: " AssociatedControlID="DdlUserType" runat="server"></asp:Label>
            <asp:DropDownList ID="DdlUserType" runat="server" OnSelectedIndexChanged="DdlUserType_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True" Value="0">Seleccione</asp:ListItem>
                <asp:ListItem Value="1">Estudiante</asp:ListItem>
                <asp:ListItem Value="2">Profesor</asp:ListItem>
                <asp:ListItem Value="3">Administrador</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div>
            <asp:Label ID="Usuario" Text="Usuario:" AssociatedControlID="Usuariotxt" runat="server"></asp:Label>
            <asp:TextBox ID="Usuariotxt" runat="server" ToolTip="El usuario puede contener letras, números y carácteres especiales."></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Pass" Text="Contraseña: " AssociatedControlID="Clavetxt" runat="server"></asp:Label>
            <asp:TextBox ID="Clavetxt" runat="server" TextMode="Password" ToolTip="La contraseña puede contener letras, números y carácteres especiales."></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="CedulaLbl" Text="Cedula: " AssociatedControlID="Cedulatxt" runat="server"></asp:Label>
            <asp:TextBox ID="Cedulatxt" runat="server"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Nombrelbl" Text="Nombres:" AssociatedControlID="Nombrestxt" runat="server"></asp:Label>
            <asp:TextBox ID="Nombrestxt" runat="server" placeholder="Nombre"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="Apellido" Text="Apellidos:" AssociatedControlID="Apellidostxt" runat="server"></asp:Label>
            <asp:TextBox ID="Apellidostxt" runat="server" placeholder="Apellido"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="MateriaLbl" Text="Materia: " AssociatedControlID="DdlMateria" runat="server"></asp:Label>
            <asp:DropDownList ID="DdlMateria" runat="server" Style="height: 27px">
            </asp:DropDownList>
        </div>


        <div class="container">
            <div class="row">
                <div>
                    <asp:Label ID="Avatar" Text="Avatar: " runat="server" Font-Bold="true"></asp:Label>
                    <asp:FileUpload ID="fuploadImagen" accept=".jpg" runat="server" CssClass="form-control" />
                    <br />
                    <br />
                </div>
            </div>
        </div>
        <div>
            <asp:Label ID="TemplateDdl" Text="Temas: " AssociatedControlID="ListThemes" runat="server"></asp:Label>
        </div>
        <div class="align-items-md-start">
            <asp:RadioButtonList ID="ListThemes" runat="server">
            </asp:RadioButtonList>
        </div>
        <div class="button">
            <asp:Button ID="ButtonS" runat="server" Text="Guardar" OnClientClick="return crearuserValidate();" OnClick="ButtonSave_Click1" />
        </div>
    </section>
    <br />
</asp:Content>
