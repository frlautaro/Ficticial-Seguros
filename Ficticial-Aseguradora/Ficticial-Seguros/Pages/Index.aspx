<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Ficticial_Seguros.Pages.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <br />
    <asp:Button runat="server" CssClass="button is-primary js-modal-trigger" data-target="modal-js-example" ID="btnCreate" Text="Create" Visible="false" OnClick="btnCreate_Click" />

    <asp:GridView CssClass="table center mx-auto" runat="server" ID="datos">
         <Columns>
             <asp:TemplateField HeaderText="Opciones" runat="server">
                 <ItemTemplate>
                     <asp:Button runat="server" CssClass="button" ID="btnRead" Text="Read" OnClick="btnRead_Click"/>
                     <asp:Button runat="server" CssClass="button" ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" />
                     <asp:Button runat="server" CssClass="button" ID="btnDelete" Text="Delete" OnClick="btnDelete_Click" />
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
    </asp:GridView>


</asp:Content>
