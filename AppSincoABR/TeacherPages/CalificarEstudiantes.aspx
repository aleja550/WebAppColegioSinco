<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/SiteTeacher.Master" AutoEventWireup="true" CodeBehind="CalificarEstudiantes.aspx.cs" Inherits="AppSincoABR.TeacherPages.CalificarEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentD" runat="server">

    <section class="margen" style="margin-left: 40px;">

        <h1>Calificación de Estudiantes  </h1>
        <br />

        <div>
            <asp:Label ID="MateriaLbl" Text="Materias Asignadas: " AssociatedControlID="DdlMateria" runat="server"></asp:Label>
            <asp:DropDownList ID="DdlMateria" runat="server" Style="height: 27px" AutoPostBack="true" OnSelectedIndexChanged="DdlMateria_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="IdNotas" HorizontalAlign="Center">
            <Columns>
                <asp:BoundField DataField="IdNotas" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Nombres" HeaderText="NombresEstudiante" />
                <asp:BoundField DataField="Apellidos" HeaderText="ApellidosEstudiante" />
                <asp:BoundField DataField="Nota1" HeaderText="Nota 1" />
                <asp:BoundField DataField="Nota2" HeaderText="Nota 2" />          
                
                <asp:TemplateField HeaderText="Asignar Materias">
                    <ItemTemplate>
                        <center><a id="redirect2" href="Calificacion.aspx?IdNotas=<%# Eval("IdNotas")%>">Calificar</a></center>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </section>
</asp:Content>