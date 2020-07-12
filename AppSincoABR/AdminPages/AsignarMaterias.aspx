<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="AsignarMaterias.aspx.cs" Inherits="AppSincoABR.AdminPages.AsignarMaterias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Asignar Materias</title>
    <link rel="stylesheet" type="text/css" href="../css/ManagementStyle.css" />
    <script src="../scripts/validations.js" type="text/javascript"></script>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">
    <h1 id="UserTypeName" runat="server">Asignar Materias</h1>
    <p>Asigne las materias: </p>

    <section id="form">
        <div>
            <asp:Label ID="NameLabel" runat="server" Font-Bold="true" Font-Size="Large"></asp:Label>
        </div>
        <div>
            <asp:Label ID="MateriaLbl" Text="Materia: " AssociatedControlID="DdlMateria" runat="server"></asp:Label>
            <asp:DropDownList ID="DdlMateria" runat="server" Style="height: 27px">
            </asp:DropDownList>
        </div>
        <div class="button">
            <asp:Button ID="ButtonSave" runat="server" Text="Guardar" OnClientClick="return crearuserValidate();" Onclick="ButtonSave_Click" />
        </div>
    </section>
    <br />
</asp:Content>
