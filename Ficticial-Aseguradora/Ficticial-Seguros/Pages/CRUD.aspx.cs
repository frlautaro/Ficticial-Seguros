using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Ficticial_Seguros.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);
        string Passphrase = "542h3I!AEQrh";
        public static string sID = "-1";
        public static string sOpc = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if(Request.QueryString["op"]!= null)
                {
                    sOpc = Request.QueryString["op"].ToString();

                    switch (sOpc)
                    {
                        case "C":
                            this.CRUDlabel.Text = "Ingrese nuevo usuario";
                            this.Crear.Visible = true;
                            break;
                        case "R":
                            this.CRUDlabel.Text = "Consulta de usuario";
                            DeshabilitarCampos();
                            break;
                        case "U":
                            this.CRUDlabel.Text = "Actualizar Usuario";
                            this.Actualizar.Visible = true;
                            break;
                        case "D":
                            this.CRUDlabel.Text = "¿Eliminar usuario?";
                            DeshabilitarCampos();
                            this.Eliminar.Visible = true;
                            break;
                    }
                }
            }
        }


        void DeshabilitarCampos()
        {
            CRUDnombre.Enabled = false;
            CRUDnombre.Enabled = false;
            CRUDdni.Enabled = false;
            CRUDpassword.Enabled = false;
            CRUDedad.Enabled = false;
            CRUDgeneroDDL.Enabled = false;
            CRUDestadoRBL.Enabled = false;
            CRUDatributosAdicionales.Enabled = false;
            CRUDmanejaRBL.Enabled = false;
            CRUDlentesRBL.Enabled = false;
            CRUDdiabeticoRBL.Enabled = false;
            CRUDenfermedadesRBL.Enabled=false;
            CRUDenfermedadesTB.Enabled=false;
        }

        void CargarDatos()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_Read", con);
            con.Open();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@Identificacion", SqlDbType.NVarChar).Value = sID;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow row = dt.Rows[0];

            CRUDnombre.Text = row[2].ToString();
            CRUDdni.Text =row[3].ToString();
            CRUDpassword.Text = row[4].ToString();
            CRUDedad.Text = row[5].ToString();
            CRUDgeneroDDL.SelectedValue = row[6].ToString();
            CRUDestadoRBL.SelectedValue = row[7].ToString();
            CRUDatributosAdicionales.Text = row[8].ToString();
            CRUDmanejaRBL.SelectedValue =row[9].ToString();
            CRUDlentesRBL.SelectedValue=row[10].ToString();
            CRUDdiabeticoRBL.SelectedValue = row[11].ToString();

            if (row[12].ToString()== "Si"|| row[12].ToString() == "No")
            {

                CRUDenfermedadesTB.Visible = false;
                CRUDenfermedadesRBL.SelectedValue=row[12].ToString();
            }
            else
            {
                CRUDenfermedadesTB.Visible = true;
                CRUDenfermedadesTB.Text= row[12].ToString();
            }
            con.Close();
        }

        protected void Crear_Click(object sender, EventArgs e)
        {
            try
            {
                string Genero = CRUDgeneroDDL.SelectedValue;

                string Estado = CRUDestadoRBL.SelectedValue;
                bool Estadovalue = Estado == "true";

                string Maneja = CRUDmanejaRBL.SelectedValue;
                bool Manejavalue = Maneja == "true";

                string Lentes = CRUDlentesRBL.SelectedValue;
                bool Lentesvalue = Lentes == "true";

                string Diabetico = CRUDdiabeticoRBL.SelectedValue;
                bool Diabeticovalue = Diabetico == "true";

                string Enfemedades = CRUDenfermedadesRBL.SelectedValue;
                if (Enfemedades == "Si")
                {
                    Enfemedades = CRUDenfermedadesTB.Text;
                }

                SqlCommand cmd = new SqlCommand("sp_RegistrarCliente", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = CRUDnombre.Text;
                cmd.Parameters.Add("@Identificacion", System.Data.SqlDbType.NVarChar).Value = CRUDdni.Text;
                cmd.Parameters.Add("@Contrasenia", System.Data.SqlDbType.NVarChar).Value = CRUDpassword.Text;
                cmd.Parameters.Add("@Edad", System.Data.SqlDbType.Int).Value = CRUDedad.Text;
                cmd.Parameters.Add("@Genero", System.Data.SqlDbType.VarChar).Value = Genero;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = Estadovalue ? 1 : 0;
                cmd.Parameters.Add("@AtributosAdicionales", System.Data.SqlDbType.NVarChar).Value = CRUDatributosAdicionales.Text;
                cmd.Parameters.Add("@Maneja", System.Data.SqlDbType.Bit).Value = Manejavalue ? 1 : 0;
                cmd.Parameters.Add("@Lentes", System.Data.SqlDbType.Bit).Value = Lentesvalue ? 1 : 0;
                cmd.Parameters.Add("@Diabetico", System.Data.SqlDbType.Bit).Value = Diabeticovalue ? 1 : 0;
                cmd.Parameters.Add("@Enfermedad", System.Data.SqlDbType.NVarChar).Value = Enfemedades;
                cmd.Parameters.Add("@Passphrase", System.Data.SqlDbType.NVarChar).Value = Passphrase;

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Index.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void Actualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Genero = CRUDgeneroDDL.SelectedValue;

                string Estado = CRUDestadoRBL.SelectedValue;
                bool Estadovalue = Estado == "true";

                string Maneja = CRUDmanejaRBL.SelectedValue;
                bool Manejavalue = Maneja == "true";

                string Lentes = CRUDlentesRBL.SelectedValue;
                bool Lentesvalue = Lentes == "true";

                string Diabetico = CRUDdiabeticoRBL.SelectedValue;
                bool Diabeticovalue = Diabetico == "true";

                string Enfemedades = CRUDenfermedadesRBL.SelectedValue;
                if (Enfemedades == "Si")
                {
                    Enfemedades = CRUDenfermedadesTB.Text;
                }

                SqlCommand cmd = new SqlCommand("sp_Actualizar", con);
                con.Open();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Identificacion", System.Data.SqlDbType.NVarChar).Value = sID;
                cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.NVarChar).Value = CRUDnombre.Text;
                cmd.Parameters.Add("@Contrasenia", System.Data.SqlDbType.NVarChar).Value = CRUDpassword.Text;
                cmd.Parameters.Add("@Edad", System.Data.SqlDbType.Int).Value = CRUDedad.Text;
                cmd.Parameters.Add("@Genero", System.Data.SqlDbType.VarChar).Value = Genero;
                cmd.Parameters.Add("@Estado", System.Data.SqlDbType.Bit).Value = Estadovalue ? 1 : 0;
                cmd.Parameters.Add("@AtributosAdicionales", System.Data.SqlDbType.NVarChar).Value = CRUDatributosAdicionales.Text;
                cmd.Parameters.Add("@Maneja", System.Data.SqlDbType.Bit).Value = Manejavalue ? 1 : 0;
                cmd.Parameters.Add("@Lentes", System.Data.SqlDbType.Bit).Value = Lentesvalue ? 1 : 0;
                cmd.Parameters.Add("@Diabetico", System.Data.SqlDbType.Bit).Value = Diabeticovalue ? 1 : 0;
                cmd.Parameters.Add("@Enfermedad", System.Data.SqlDbType.NVarChar).Value = Enfemedades;
                cmd.Parameters.Add("@Passphrase", System.Data.SqlDbType.NVarChar).Value = Passphrase;

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Index.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarCliente", con);
                con.Open();
                
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Identificacion", System.Data.SqlDbType.NVarChar).Value = sID;
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("Index.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }

        protected void CRUDenfermedadesRBL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CRUDenfermedadesRBL.SelectedValue == "Si")
            {
                CRUDenfermedadesLabel.Visible = true;
                CRUDenfermedadesTB.Visible = true;

            }
            else
            {
                CRUDenfermedadesTB.Visible = false;
            }
        }
    }
}