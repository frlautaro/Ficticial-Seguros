<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/MainPage.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="Ficticial_Seguros.Pages.CRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
 
    <div class="container box">
        <asp:Label runat="server" ID="CRUDlabel" CssClass="title"></asp:Label>
        <div class="field">
            <div>
                <label class="label">Nombre</label>
            </div>
            <div class="control">
                <asp:TextBox runat="server" ID="CRUDnombre" cssClass="input" type="text" placeholder="John Bennet"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">
            <div>
                <label class="label">DNI</label>
            </div>
            <div class="control">
                <asp:TextBox runat="server" ID="CRUDdni" CssClass="input" type="text" placeholder="33.424.254"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">
            <div>
                <label class="label">Contraseña</label>
            </div>
            <div class="control">
                <asp:TextBox runat="server" ID="CRUDpassword" CssClass="input" type="password" placeholder="********"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">
            <div>
                <label class="label">Edad</label>
            </div>
            <div class="control">
                <asp:TextBox runat="server" ID="CRUDedad" CssClass="input" type="number" placeholder="18"> 
                </asp:TextBox>
            </div>
        </div>

        <%-- Hacer dropdown select  --%>
        <div class="field">
            <div>
               <label class="label">Genero</label>
            </div>
        <asp:DropDownList runat="server" ID="CRUDgeneroDDL" CssClass="select">
            <asp:ListItem Text="Masculino" Value="Masculino"></asp:ListItem>
            <asp:ListItem Text="Femenino" Value="Femenino"></asp:ListItem>
            <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
        </asp:DropDownList>
        </div>


        <div class="field">
            <div>
                <label class="label">Estado</label>
            </div>
            <asp:RadioButtonList runat="server" ID="CRUDestadoRBL">
                <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <div>
                <label class="label">Atributos Adicionales</label>
            </div>
            <div class="control">
                <asp:TextBox runat="server" ID="CRUDatributosAdicionales" CssClass="input" mode="MultiLine" type="text" placeholder="ej: narcolepsia "> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field">
            <div>
                <label class="label">Maneja?</label>
            </div>
            <asp:RadioButtonList runat="server" ID="CRUDmanejaRBL">
                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                <asp:ListItem Text="No" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <div>
                <label class="label">¿Usa lentes?</label>
            </div>
            <asp:RadioButtonList runat="server" ID="CRUDlentesRBL">
                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                <asp:ListItem Text="No" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <div>
                <label class="label">¿Es diabetico?</label>
            </div>
            <asp:RadioButtonList runat="server" ID="CRUDdiabeticoRBL">
                <asp:ListItem Text="Si" Value="true"></asp:ListItem>
                <asp:ListItem Text="No" Value="false"></asp:ListItem>
            </asp:RadioButtonList>

        </div>

        <div class="field">
            <div>
                <label class="label">¿Tiene enfermedades adicionales?</label>
            </div>
            <div>
                <asp:RadioButtonList runat="server" ID="CRUDenfermedadesRBL" OnSelectedIndexChanged="CRUDenfermedadesRBL_SelectedIndexChanged" AutoPostBack="true"> 
                    <asp:ListItem Text="Si" Value="Si"></asp:ListItem>
                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                </asp:RadioButtonList>
            </div>            
            <div class="control">
                <asp:Label CssClass="label" ID="CRUDenfermedadesLabel" runat="server" Visible="false">Ingrese su/s enfermedad/es adicional/es</asp:Label>
                <asp:TextBox runat="server" ID="CRUDenfermedadesTB" CssClass="input" type="text" Visible="false"> 
                </asp:TextBox>
            </div>
        </div>

        <div class="field is-group">
            <div class="control">
                <asp:Button runat="server" ID="Crear" CssClass="button is-link" Text="Crear" OnClick="Crear_Click" Visible="false"/>
                <asp:Button runat="server" ID="Actualizar" CssClass="button is-link" Text="Actualizar" OnClick="Actualizar_Click" Visible="false"/>
                <asp:Button runat="server" ID="Eliminar" CssClass="button is-link" Text="Eliminar" OnClick="Eliminar_Click" Visible="false"/>

                <asp:Button runat="server" ID="Volver" CssClass="button is-link" Text="Volver" OnClick="Volver_Click" Visible="True"/>
                
                <%--<a class="button is-link is-light" href="Index.aspx">Volver</a>--%>
            </div>
        </div>
    </div>


</asp:Content>
