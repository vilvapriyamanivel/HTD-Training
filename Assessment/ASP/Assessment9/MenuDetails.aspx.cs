using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace Assessment9
{
    public partial class MenuDetails : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM MenuItems WHERE MenuId=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Response.Write("Item Name : " + dr["ItemName"]);
                Response.Write("<br/>Category : " + dr["Category"]);
                Response.Write("<br/>Price : " + dr["Price"]);
            }

            con.Close();
        }
    }
}