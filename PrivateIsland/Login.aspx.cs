using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PrivateIsland
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginAttempts"] == null)
                Session["LoginAttempts"] = 0;

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

        protected void LogInbtn_Click(object sender, EventArgs e)
        {
            int i = (int)Session["LoginAttempts"];
            if (i >= 5)
            {
                LogInLabel.Text = "Too many unsuccesful login attempts, please try again later.";
            }

            string username = UserNametxtbox.Text;
            string passHash = ConnectionClass.getHashedPassword(Passwordtxtbox.Text);

            if (ConnectionClass.LoginMatched(username, passHash))
            {
                Session["ActiveUser"] = ConnectionClass.getLoggedInCustomer(username);
                Response.Redirect("Islands.aspx");
            }
            else
            {
                LogInLabel.Text = "Incorrect Username and Password";
                i++;
                Session["LoginAttempts"] = i;
            }
        }

        private void Warn()
        {
            cont.Visible = false;
            HtmlGenericControl h3 = new HtmlGenericControl("h3");
            h3.InnerText = "You are already logged in!";
            cont.Parent.Controls.Add(h3);
        }
    }
}