<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteStudent.Master" AutoEventWireup="true" CodeBehind="ReporteNotas.aspx.cs" Inherits="AppSincoABR.StudentPages.ReporteNotas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">

    <section class="margen" style="margin-left: 40px;">

        <h1>Reporte de Notas:</h1>
        <br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="IdEstudiante" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="IdEstudiante" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                <asp:BoundField DataField="Nombres" HeaderText="NombresEstudiante" />
                <asp:BoundField DataField="Apellidos" HeaderText="ApellidosEstudiante" />
                <asp:BoundField DataField="Nota1" HeaderText="Nota 1" />
                <asp:BoundField DataField="Nota2" HeaderText="Nota 2" />          
                <asp:BoundField DataField="Materia" HeaderText="Materia"/> 
                <asp:BoundField DataField="Profesor" HeaderText="Profesor"/>    
            </Columns>
        </asp:GridView>
    </section>
</asp:Content>
