using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ficticial_Seguros.Pages
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Para liberar el cache cada vez que entramos a un form
            Response.AppendHeader("Cache-Control", "no-store");
        }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());

        //Patron de contraseña
        string Passphrase = "542h3I!AEQrh";
        //string Passphrase = "VolaDeAca";

        protected void ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_LogInCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Identificacion", System.Data.SqlDbType.NVarChar).Value = IdentificacionDNI.Text;
                cmd.Parameters.Add("@Contrasenia", System.Data.SqlDbType.NVarChar).Value = Contrasenia.Text;
                cmd.Parameters.Add("@Passphrase", System.Data.SqlDbType.NVarChar).Value = Passphrase;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    //Session["Id_Rol"] = rd["IdRol"].ToString();
                    //Session["Identificacion"] = rd["Identificacion"].ToString();
                    Session["Id_Rol"] = rd[1].ToString();
                    Session["Identificacion"] = rd[3].ToString();
                    Response.Redirect("Index.aspx");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }
    }
}