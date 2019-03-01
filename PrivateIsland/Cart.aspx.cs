using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PrivateIsland
{
    public partial class Cart : System.Web.UI.Page
    {
        List<CartItem> cartItems;
        bool flag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            DummyCustomer c = (DummyCustomer)Session["ActiveUser"];
            Order o = (Order)Session["ActiveOrder"];
            cartItems = ConnectionClass.getCartItems(o);

            Label menuLabel = (Label)Master.FindControl("Label1");
            menuLabel.Text = string.Format("Welcome UserID: {0} | Cart: {1}", c.ID, o.ID);

            GenerateContent();
        }

        protected void GenerateContent()
        {
            CartItem cartItem = cartItems[0];
            Island island = ConnectionClass.getCartIsland(cartItem);

            for (int i = 0; i < 3; i++)
            {
                HtmlGenericControl row = new HtmlGenericControl("div");
                HtmlGenericControl col1 = new HtmlGenericControl("div");
                Image previewImg = new Image();
                HtmlGenericControl col2 = new HtmlGenericControl("div");
                HtmlGenericControl h4 = new HtmlGenericControl("h4");
                HtmlGenericControl p1 = new HtmlGenericControl("p");
                HtmlGenericControl p2 = new HtmlGenericControl("p");

                row.Attributes.Add("class","row");
                col1.Attributes.Add("class", "col-md-5");

                col2.Attributes.Add("class", "col-md-7");
                col2.Attributes.Add("style", "background-color:#EEEEEE;");
                previewImg.CssClass = "preview";

                if (!flag)
                {
                    previewImg.ImageUrl = "https://i.imgur.com/"+island.ImageUrl;
                    h4.InnerText = island.Name;
                    p1.InnerText = "This island was successfully loaded from the user's active shopping cart";
                    p2.InnerText = "All database connections are working!";
                    flag = true;
                }
                else
                {
                    previewImg.ImageUrl = "https://i.imgur.com/I5DkMRy.jpg";
                    h4.InnerText = "ISLAND NAME";

                    p1.InnerText = "Some text";
                    p2.InnerText = "Some text";
                }

                               
                itemsPlaceHolder.Controls.Add(row);
                    row.Controls.Add(col1);
                        col1.Controls.Add(previewImg);

                    row.Controls.Add(col2);
                        col2.Controls.Add(h4);
                        col2.Controls.Add(p1);
                        col2.Controls.Add(p2);
            }

            for (int i = 0; i < 7; i++)
            {
                HtmlGenericControl s_row = new HtmlGenericControl("div");
                HtmlGenericControl s_col1 = new HtmlGenericControl("div");
                HtmlGenericControl s_col2 = new HtmlGenericControl("div");
                HtmlGenericControl s_p1 = new HtmlGenericControl("p");
                HtmlGenericControl s_p2 = new HtmlGenericControl("p");

                s_row.Attributes.Add("class", "row");
                s_col1.Attributes.Add("class", "col-md-8");
                s_col2.Attributes.Add("class", "col-md-4");

                s_p1.InnerText = "Some text";
                s_p2.InnerText = "$MONEY$";

                summaryPlaceHolder.Controls.Add(s_row);
                s_row.Controls.Add(s_col1);
                s_col1.Controls.Add(s_p1);
                s_row.Controls.Add(s_col2);
                s_col2.Controls.Add(s_p2);

            }
        }
    }
}