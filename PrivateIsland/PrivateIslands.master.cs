using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrivateIsland
{
    public partial class PrivateIslands : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ActiveUser"] != null)
            {
                navMenu.Items[5].Text = "Log Out";
            }
            else
            {
                navMenu.Items[5].Text = "Login";
            }
        }

        protected void MenuItem_Clicked(object sender, MenuEventArgs e)
        {
            Label1.Text = e.Item.Text;

            if (e.Item.Text == "Login")
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (e.Item.Text == "Log Out")
            {
                Session.Abandon();
                Response.Redirect("~/Islands.aspx");
                return;
            }
        }

        public void Logout()
        {
            Session.Abandon();
            Response.Redirect("~/Islands.aspx");
            return;
        }
    }
}