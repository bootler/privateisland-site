using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace COMP228_GroupProject_PrivateIsland
{
    public partial class Login : System.Web.UI.Page
    {
        SqlConnection cn = new SqlConnection("Data Source=SHADETRIX\\SQLEXPRESS;Initial Catalog=MS_Database;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            cn.Open();
        }

        protected void LogInbtn_Click(object sender, EventArgs e)
        {
            string check = "select count(*) from RegisterDatabase where Username = '" + UserNametxtbox.Text + "' and Password = '" + Passwordtxtbox.Text + "'";
            SqlCommand cmd = new SqlCommand(check, cn);
            int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            cn.Close();
            if (temp == 1)
            {
                Session["ActiveUser"] = new DummyCustomer(112);
                Response.Redirect("Islands.aspx");
            }
            else
            {
                LogInLabel.Text = "Incorrect Username and Password";
            }
        }
    }
}