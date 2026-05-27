using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assessment9
{
    public partial class OrderStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVisitors.Text =
                "Total Visitors : " +
                Application["TotalVisitors"].ToString();

            lblUsers.Text =
                "Current Active Users : " +
                Application["ActiveUsers"].ToString();
        }
    }
}