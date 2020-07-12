<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="ListaEstudiantes.aspx.cs" Inherits="AppSincoABR.AdminPages.ListaEstudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">

    <section class="margen" style="margin-left: 40px;">

        <h1>Estudiantes </h1>
        <br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="IdEstudiante" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="IdEstudiante" HeaderText="Código" ReadOnly="True" />
                <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" ReadOnly="true" />

                <asp:TemplateField HeaderText="Editar/Eliminar">
                    <ItemTemplate>
                        <center><a id="redirect" href="EditStudent.aspx?IdEstudiante=<%# Eval("IdEstudiante")%>"><img src="../images/edit.png" /></a></center>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Asignar Materias">
                    <ItemTemplate>
                        <center><a id="redirect2" href="AsignarMaterias.aspx?IdEstudiante=<%# Eval("IdEstudiante")%>">Asignar Materias</a></center>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </section>
</asp:Content>
