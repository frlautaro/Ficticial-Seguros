<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="Ficticial_Seguros.Pages.LogIn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container-box">
        <h1 class="title">Iniciar Sesion</h1>

        <div class="field">
            <label class="label">DNI</label>
            <asp:TextBox runat="server" ID="IdentificacionDNI" CssClass="input" type="text" placeholder="Juan Schiaretti"></asp:TextBox>
        </div>

        <div class="field">
            <label class="label">Clave</label>
            <div>
                <asp:TextBox runat="server" ID="Contrasenia" CssClass="input" type="password" placeholder="*********"></asp:TextBox>
            </div>
        </div>

        <asp:Button runat="server" ID="ingresar" CssClass="button is-primary" text="Ingresar" OnClick="ingresar_Click" />

    </div>


</asp:Content>
