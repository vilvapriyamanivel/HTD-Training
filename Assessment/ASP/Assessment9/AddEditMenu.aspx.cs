using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Assessment9
{
    public partial class AddEditMenu : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString);

        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            // Get MenuId from QueryString
            if (Request.QueryString["MenuId"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["MenuId"]);

                if (!IsPostBack)
                {
                    LoadMenuData();
                }
            }
        }

        // LOAD OLD VALUES
        void LoadMenuData()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM MenuItems WHERE MenuId=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtItemName.Text = dr["ItemName"].ToString();
                txtCategory.Text = dr["Category"].ToString();
                ddlFoodType.Text = dr["FoodType"].ToString();
                txtPrice.Text = dr["Price"].ToString();
                txtQty.Text = dr["AvailableQuantity"].ToString();

                chkAvailable.Checked =
                    Convert.ToBoolean(dr["IsAvailable"]);
            }

            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // EDIT
            if (Request.QueryString["MenuId"] != null)
            {
                id = Convert.ToInt32(Request.QueryString["MenuId"]);

                SqlCommand cmd = new SqlCommand(
                @"UPDATE MenuItems
                  SET ItemName=@name,
                      Category=@cat,
                      FoodType=@type,
                      Price=@price,
                      AvailableQuantity=@qty,
                      IsAvailable=@avail
                  WHERE MenuId=@id", con);

                cmd.Parameters.AddWithValue("@name", txtItemName.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                cmd.Parameters.AddWithValue("@type", ddlFoodType.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@avail", chkAvailable.Checked);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("Updated Successfully");
            }

            // ADD NEW
            else
            {
                SqlCommand cmd = new SqlCommand(
                @"INSERT INTO MenuItems
                (ItemName,Category,FoodType,Price,
                AvailableQuantity,IsAvailable)

                VALUES
                (@name,@cat,@type,@price,@qty,@avail)", con);

                cmd.Parameters.AddWithValue("@name", txtItemName.Text);
                cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
                cmd.Parameters.AddWithValue("@type", ddlFoodType.Text);
                cmd.Parameters.AddWithValue("@price", txtPrice.Text);
                cmd.Parameters.AddWithValue("@qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@avail", chkAvailable.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("Inserted Successfully");
            }
        }
    }
}