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

        protected void Page_Load(object sender, EventArgs e)
        {
            Label menuLabel;
            if (Session["ActiveUser"] != null)
            {
                Customer c = (Customer)Session["ActiveUser"];
                Order o = (Order)Session["ActiveOrder"];

                menuLabel = (Label)Master.FindControl("Label1");
                menuLabel.Text = string.Format("Welcome {0} {1} | Cart: {2}", c.FirstName, c.LastName, o.ID);
            }
            else
            {
                menuLabel = (Label)Master.FindControl("Label1");
                menuLabel.Text = string.Format("Welcome! Please login");
            }
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string dobString = Year.SelectedItem.ToString() + "-" + Month.SelectedItem.ToString() + "-" + Day.SelectedItem.ToString();

            Customer newCust = new Customer(Firstnametxt.Text, Lastnametxt.Text, dobString, Emailtxt.Text, PhoneNumbertxt.Text);
            string username = UserNametxt.Text;
            string passHash = ConnectionClass.getHashedPassword(Passwordtxt.Text);

            if (ConnectionClass.UsernameExists(username))
            {
                //it's the label in the top right hand corner of the menu
                Label lbl = Master.FindControl("Label1") as Label;
                lbl.Text = "That username already exists!";
                UserNametxt.Text = "";
                UserNametxt.Focus();
                return;
            }
            ConnectionClass.RegisterAccount(newCust, username, passHash);
            Response.Redirect("Login.aspx");

        }


    }
}