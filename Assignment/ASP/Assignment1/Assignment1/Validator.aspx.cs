using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment1
{
    public partial class Validator : System.Web.UI.Page
    {

        protected void CheckNames(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
        {
            args.IsValid = txtName.Text != txtFamily.Text;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                Response.Write("<h2>All validations passed!</h2>");
            }


        }


    }
}