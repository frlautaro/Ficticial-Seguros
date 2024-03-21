<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainPage.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Ficticial_Seguros.Pages.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="container box">
        <h1 class="title">Registro de usuarios</h1>
        <div class="field">
            <label class="label">Nombre</label>
            <div class="control">
                <asp:TextBox runat="server" ID="Nombre" CssClass="input" type="text" placeholder="John Bennet"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label class="label">DNI</label>
            <div class="control">
                <asp:TextBox runat="server" ID="DNI" CssClass="input" type="text" placeholder="33.424.254"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label class="label">Contraseña</label>
            <div class="control">
                <asp:TextBox runat="server" ID="Password" CssClass="input" type="password" placeholder="********"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">
            <label class="label">Edad</label>
            <div class="control">
                <asp:TextBox runat="server" ID="Edad" CssClass="input" type="number" placeholder="18"> 
                </asp:TextBox>
            </div>
        </div>

        <%-- Hacer dropdown select  --%>
        <div class="field">
        <asp:DropDownList runat="server" ID="GeneroDDL" CssClass="select">
            <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
            <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
        </asp:DropDownList>
        </div>


        <div class="field">
            <label class="label">Estado</label>
            <asp:RadioButtonList runat="server" ID="EstadoRBL">
                <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <label class="label">Atributos Adicionales</label>
            <div class="control">
                <asp:TextBox runat="server" ID="AtributosAdicionales" CssClass="input" mode="MultiLine" type="text" placeholder="ej: narcolepsia "> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">

            <label class="label">¿Maneja?</label>
            <asp:RadioButtonList runat="server" ID="ManejaRBL">
                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                <asp:ListItem Text="No" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <label class="label">¿Usa Lentes?</label>
            <asp:RadioButtonList runat="server" ID="LentesRBL">
                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                <asp:ListItem Text="No" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <label class="label">¿Es Diabetico?</label>
            <asp:RadioButtonList runat="server" ID="DiabeticoRBL">
                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                <asp:ListItem Text="No" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <label class="label">¿Tiene Enfermedades adicionales?</label>
            <div>
                <asp:RadioButtonList runat="server" ID="EnfermedadesRBL" OnSelectedIndexChanged="EnfermedadesRBL_SelectedIndexChanged" AutoPostBack="true"> 
                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                </asp:RadioButtonList>
            </div>            
            <div class="control">
                <asp:Label CssClass="label" ID="EnfermedadesLabel" runat="server" Visible="false">Ingrese su/s enfermedad/es adicional/es</asp:Label>
                <asp:TextBox runat="server" ID="EnfermedadesTB" CssClass="input" type="text" Visible="false"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field is-group">
            <div class="control">
                <asp:Button runat="server" ID="Registrarse" CssClass="button is-link" Text="Enviar" OnClientClick="return validarFormulario();" OnClick="Registrar_Click" />
                <a class="button is-link is-light" href="Index.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
