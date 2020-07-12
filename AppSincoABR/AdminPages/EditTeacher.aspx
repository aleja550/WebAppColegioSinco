<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="EditTeacher.aspx.cs" Inherits="AppSincoABR.AdminPages.EditTeacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="../css/ManagementStyle.css" />
    <script src="../scripts/validations.js" type="text/javascript"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">

    <h1>Actualización de Profesor </h1>

    <p>LLene por favor los siguientes campos: </p>

    <section runat="server">
         
                <hr />
                <div>
                    <asp:Label ID="Cedula" Text="Cedula:" AssociatedControlID="txtCedula" runat="server"></asp:Label>
                    <asp:TextBox ID="txtCedula" runat="server" placeholder="Cedula"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="Nombre" Text="Nombres:" AssociatedControlID="txtNombre" runat="server"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" placeholder="Nombre"></asp:TextBox>
                </div>

                <div>
                    <asp:Label ID="Apellido" Text="Apellidos:" AssociatedControlID="txtApellido" runat="server"></asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" placeholder="Apellido"></asp:TextBox>
                </div>           
                           
        <div class="button">
            <asp:Button ID="ButtonSave" type="submit" runat="server" Text="Actualizar" OnClientClick="return edituserValid();" OnClick="ButtonSave_Click" />
            <asp:Button ID="ButtonDelete" type="submit" runat="server" Text="Eliminar" OnClick="ButtonDelete_Click" />
        </div>
    </section>
</asp:Content>
