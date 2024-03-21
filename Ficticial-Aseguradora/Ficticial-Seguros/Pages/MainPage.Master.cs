using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ficticial_Seguros.Pages
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");

            //divuser.Visible = false;
            //divbuttons.Visible = true;


            if (Session["Identificacion"] != null)
            {

                divuser.Visible = true;
                divbuttons.Visible = false;
                lblusuario.Text = Session["Identificacion"].ToString();
            }
            else
            {
                divuser.Visible = false;
                divbuttons.Visible = true;
                lblusuario.Visible = false;
            }
        }

        protected void Registrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }

        protected void LogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx");
        }


        protected void Unnamed_Click (object sender, EventArgs e)
        {
            Session["Identificacion"] = null;
            Session["Id_Rol"] = null;
            Response.Redirect("Login.aspx");
            HttpContext.Current.Session.Abandon();
        }


    }
}