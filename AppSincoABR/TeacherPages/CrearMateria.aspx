<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="CrearMateria.aspx.cs" Inherits="AppSincoABR.TeacherPages.CrearMateria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Crear materia</title>

    <link rel="stylesheet" type="text/css" href="../css/ManagementStyle.css" />
    <script src="../scripts/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">

    <h1 id="UserTypeName" runat="server">Creación Nueva Materia</h1>
    <p>LLene por favor los siguientes campos: </p>

    <section id="form">
        <div>
            <asp:Label ID="Materia" Text="Nombre" AssociatedControlID="Materiatxt" runat="server"></asp:Label>
            <asp:TextBox ID="Materiatxt" runat="server"></asp:TextBox>
        </div>


        <div class="button">
            <asp:Button ID="ButtonS" runat="server" Text="Guardar" OnClientClick="return materiaValid();" OnClick="ButtonS_Click"/>
        </div>
    </section>
    <br />
</asp:Content>

