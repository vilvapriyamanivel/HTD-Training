using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assessment9
{
    public partial class MenuList : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
           ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM MenuItems", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender,
           System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(
                GridView1.DataKeys[e.RowIndex].Value);

            SqlCommand cmd = new SqlCommand(
                "DELETE FROM MenuItems WHERE MenuId=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadData();
        }
    }
}