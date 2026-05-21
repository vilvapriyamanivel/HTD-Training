using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Product : System.Web.UI.Page
    {
       
            public class Products 
            {
                public string Name { get; set; }
                public string ImageUrl { get; set; }
                public decimal Price { get; set; }
            }

            // Store products (static for simplicity)
            static List<Products> products = new List<Products>()
        {
            new Products { Name = "Laptop", ImageUrl = "~/Images/laptop.jpg", Price = 50000 },
            new Products { Name = "Phone", ImageUrl = "~/Images/phone.jpg", Price = 20000 },
            new Products { Name = "Headphones", ImageUrl = "~/Images/headphones.jpg", Price = 3000 }
        };

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    ddlProducts.DataSource = products;
                    ddlProducts.DataTextField = "Name";
                    ddlProducts.DataValueField = "Name";
                    ddlProducts.DataBind();

                    // default image
                    ShowImage();
                }
            }

            protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
            {
                ShowImage();
            }

            private void ShowImage()
            {
                var selected = products.Find(p => p.Name == ddlProducts.SelectedValue);
                if (selected != null)
                {
                    imgProduct.ImageUrl = selected.ImageUrl;
                }
            }

        protected void btnPrice_Click(object sender, EventArgs e)
        {

            var selected = products.Find(p => p.Name == ddlProducts.SelectedValue);
            if (selected != null)
            {
                lblPrice.Text = "Price: ₹" + selected.Price;
            }

        }
    }
    }
