using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Ficticial_Seguros.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        int id_rol = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Cache-Control", "no-store");
            
            if(!IsPostBack && Session["Identificacion"] != null)
            {
                id_rol = Convert.ToInt32(Session["id_rol"].ToString());
                Datos();
                Permisos(id_rol);
            }
        }

        void Datos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Datos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                datos.DataSource = dt;
                datos.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void Permisos(int id_rol)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Permisos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdRol", SqlDbType.Int).Value = id_rol;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                bool Create, Read, Update, Delete;

                while (reader.Read())
                {
                    foreach (GridViewRow fila in datos.Rows)
                    {
                        switch (reader[0].ToString())
                        {
                            case "Create":
                                Create = Convert.ToBoolean(reader[1].ToString());
                                if (Create)
                                {
                                    btnCreate.Visible = true;
                                }
                                else
                                {
                                    btnCreate.Visible = false;
                                }
                                break;

                            case "Read":
                                Read = Convert.ToBoolean(reader[1].ToString());
                                Button btn1 = fila.FindControl("btnRead") as Button;
                                if (Read)
                                {
                                    btn1.Visible = true;
                                    datos.Visible = true;
                                }
                                else
                                {
                                    btn1.Visible = false;
                                    datos.Visible = false;
                                }
                                break;

                            case "Update":
                                Update = Convert.ToBoolean(reader[1].ToString());
                                Button btn2 = fila.FindControl("btnUpdate") as Button;
                                if (Update)
                                {
                                    btn2.Visible = true;
                                }
                                else
                                {
                                    btn2.Visible = false;
                                }
                                break;

                            case "Delete":
                                Delete = Convert.ToBoolean(reader[1].ToString());
                                Button btn3 = fila.FindControl("btnDelete") as Button;
                                if (Delete)
                                {
                                    btn3.Visible = true;
                                }
                                else
                                {
                                    btn3.Visible = false;
                                }
                                break;
                        }
                    }
                }
                con.Close();
                reader.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[4].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id="+id+"&op=R");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[4].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectedrow.Cells[4].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=D");
        }
    }
}