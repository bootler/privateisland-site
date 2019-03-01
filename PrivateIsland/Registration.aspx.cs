using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrivateIsland
{
    
    public partial class Registration : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection cn = new SqlConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = "Data Source=SHADETRIX\\SQLEXPRESS;Initial Catalog=MS_Database;Integrated Security=True";
            cn.Open();
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("insert into RegisterDatabase " + " (Firstname,Lastname,DateofBirth,Email,Phonenumber,Username,Password) values(@Firstname,@Lastname,@DateofBirth,@Email,@Phonenumber,@Username,@Password)", cn);
            cmd.Parameters.AddWithValue("@Firstname", Firstnametxt.Text);
            cmd.Parameters.AddWithValue("@Lastname", Lastnametxt.Text);
            cmd.Parameters.AddWithValue("@DateofBirth", Year.SelectedItem.ToString() + "-" + Month.SelectedItem.ToString() + "-" + Day.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Email", Emailtxt.Text);
            cmd.Parameters.AddWithValue("@Phonenumber", PhoneNumbertxt.Text);
            cmd.Parameters.AddWithValue("@Username", UserNametxt.Text);
            cmd.Parameters.AddWithValue("@Password", Passwordtxt.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            Response.Redirect("Login.aspx");

        }


    }
}