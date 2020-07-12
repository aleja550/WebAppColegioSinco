<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteTeacher.Master" AutoEventWireup="true" CodeBehind="Calificacion.aspx.cs" Inherits="AppSincoABR.TeacherPages.Calificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Calificación</title>
    <link rel="stylesheet" type="text/css" href="../css/ManagementStyle.css" />
    <script src="../scripts/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">
    <h1 id="UserTypeName" runat="server">Calificación</h1>
    <p>Calificar Estudiante: </p>

    <section id="form">
        <div>
            <asp:Label ID="NameLabel" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
        </div>
         <div>
            <asp:Label ID="Nota1lbl" Text="Nota 1er Periodo:" AssociatedControlID="txtNota1" runat="server"></asp:Label>
            <asp:TextBox ID="txtNota1" runat="server"></asp:TextBox>
        </div>

         <div>
            <asp:Label ID="Nota2lbl" Text="Nota 2do Periodo:" AssociatedControlID="txtNota2" runat="server"></asp:Label>
            <asp:TextBox ID="txtNota2" runat="server"></asp:TextBox>
        </div>
        <div class="button">
            <asp:Button ID="ButtonSave" runat="server" Text="Guardar" OnClientClick="return crearuserValidate();" OnClick="ButtonSave_Click" />
        </div>
    </section>
    <br />
</asp:Content>
