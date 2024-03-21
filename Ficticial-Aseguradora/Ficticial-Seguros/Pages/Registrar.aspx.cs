using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Ficticial_Seguros.Pages
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Para liberar el cache cada vez que entramos a un form
            Response.AppendHeader("Cache-Control", "no-store");
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());

        //Patron de contraseña
        string Passphrase = "542h3I!AEQrh";

        //Limpiamos los campos
        protected void Limpiar()
        {
            Nombre.Text = string.Empty;
            DNI.Text = string.Empty;
            Password.Text = string.Empty;
            Edad.Text = string.Empty;
            AtributosAdicionales.Text = string.Empty;
            EnfermedadesTB.Text = string.Empty;
        }

        protected void Registrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Manejo de datos por campos
                string Genero = GeneroDDL.SelectedValue;

                string Estado = EstadoRBL.SelectedValue;
                bool Estadovalue = Estado == "true";

                string Maneja = ManejaRBL.SelectedValue;
                bool Manejavalue = Maneja == "true";

                string Lentes = LentesRBL.SelectedValue;
                bool Lentesvalue = Lentes == "true";

                string Diabetico = DiabeticoRBL.SelectedValue;
                bool Diabeticovalue = Diabetico == "true";

                string Enfemedades = EnfermedadesRBL.SelectedValue;
                if (Enfemedades == "Si")
                {
                    Enfemedades = EnfermedadesTB.Text;
                }

                SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = Nombre.Text;
                cmd.Parameters.Add("@Identificacion", System.Data.SqlDbType.NVarChar).Value = DNI.Text;
                cmd.Parameters.Add("@Contrasenia", System.Data.SqlDbType.NVarChar).Value = Password.Text;
                cmd.Parameters.Add("@Edad", System.Data.SqlDbType.Int).Value = Edad.Text;
                cmd.Parameters.Add("@Genero", System.Data.SqlDbType.VarChar).Value = Genero;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = Estadovalue ? 1 : 0;
                cmd.Parameters.Add("@AtributosAdicionales", System.Data.SqlDbType.NVarChar).Value = AtributosAdicionales.Text;
                cmd.Parameters.Add("@Maneja", System.Data.SqlDbType.Bit).Value = Manejavalue ? 1 : 0;
                cmd.Parameters.Add("@Lentes", System.Data.SqlDbType.Bit).Value = Lentesvalue ? 1 : 0;
                cmd.Parameters.Add("@Diabetico", System.Data.SqlDbType.Bit).Value = Diabeticovalue ? 1 : 0;
                cmd.Parameters.Add("@Enfermedad", System.Data.SqlDbType.NVarChar).Value = Enfemedades;
                cmd.Parameters.Add("@Passphrase", System.Data.SqlDbType.NVarChar).Value = Passphrase;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Limpiar();
                Response.Redirect("LogIn.aspx");

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void EnfermedadesRBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EnfermedadesRBL.SelectedValue == "Si")
            {
                EnfermedadesLabel.Visible = true;
                EnfermedadesTB.Visible = true;

            }
            else
            {
                EnfermedadesTB.Visible = false;
            }
        }
    }
}