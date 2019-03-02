using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PrivateIsland
{
    public partial class Cart : System.Web.UI.Page
    {
        List<CartItem> cartItems;
        bool loggedOut;
        bool noItems;
        int count;
        long total;
        long taxes;
        Order o;
        protected void Page_Load(object sender, EventArgs e)
        {
            loggedOut = false;
            noItems = false;
            total = 0;

            Label menuLabel;
            if (Session["ActiveUser"] != null)
            {
                Customer c = (Customer)Session["ActiveUser"];
                o = (Order)Session["ActiveOrder"];
                cartItems = ConnectionClass.getCartItems(o);
                if (cartItems.Count == 0) noItems = true;
                count = cartItems.Count;

                menuLabel = (Label)Master.FindControl("Label1");
                menuLabel.Text = string.Format("Welcome, {0} {1} | Cart: {2}", c.FirstName, c.LastName, o.ID);
            }
            else
            {
                loggedOut = true;
                menuLabel = (Label)Master.FindControl("Label1");
                menuLabel.Text = string.Format("Welcome! Please login");
            }

            GenerateContent();
        }

        protected void btnCheckout_Click(Object sender, EventArgs e)
        {
            payments.Visible = true;
        }

        protected void btnRemove_Click(Object sender, EventArgs e)
        {
            Button thisbtn = sender as Button;
            HiddenField hf = thisbtn.Parent.Controls[3] as HiddenField;
            int id = int.Parse(hf.Value);
            ConnectionClass.removeCartItem(id);
            Response.Redirect("~/Cart.aspx");
        }

        protected void btnProceed_Click(object sender, EventArgs e)
        {
            foreach (CartItem item in cartItems)
            {
                ConnectionClass.setSold(item.IslandID);
            }
            ConnectionClass.setInactiveOrder(o);
            Response.Redirect("~/Islands.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ConnectionClass.resetSoldStatus();
            Response.Redirect("~/Islands.aspx");
        }

        protected void GenerateContent()
        {
            if (!loggedOut && !noItems)
            {
                foreach (CartItem item in cartItems)
                {
                    HtmlGenericControl row = new HtmlGenericControl("div");
                    HtmlGenericControl col1 = new HtmlGenericControl("div");
                    Image previewImg = new Image();
                    HtmlGenericControl col2 = new HtmlGenericControl("div");
                    HtmlGenericControl h4 = new HtmlGenericControl("h4");
                    HtmlGenericControl ul = new HtmlGenericControl("ul");
                    HtmlGenericControl l1 = new HtmlGenericControl("li");
                    HtmlGenericControl l2 = new HtmlGenericControl("li");
                    HtmlGenericControl l3 = new HtmlGenericControl("li");
                    HiddenField hidden = new HiddenField();
                    Button btn = new Button();

                    row.Attributes.Add("class", "row");
                    col1.Attributes.Add("class", "col-md-5");

                    col2.Attributes.Add("class", "col-md-7");
                    col2.Attributes.Add("style", "background-color:#EEEEEE;");
                    previewImg.CssClass = "preview";

                    Island island = ConnectionClass.getCartIsland(item);
                    total += island.Price;

                    previewImg.ImageUrl = "https://i.imgur.com/" + island.ImageUrl;
                    h4.InnerText = island.Name.ToUpper();

                    l1.Attributes.Add("class", "loc-bullet");
                    l1.InnerText = island.Location;

                    l2.Attributes.Add("class", "size-bullet");
                    l2.InnerText = string.Format("{0} acre(s)", island.Acres);

                    l3.Attributes.Add("class", "money-bullet");
                    l3.InnerText = string.Format("${0:n0}", island.Price);

                    hidden.Value = "" + item.ID;
                    btn.CssClass = "btn btn-danger btn-cart-special";
                    btn.Text = "Remove from Cart";
                    btn.Click += new EventHandler(btnRemove_Click);

                    itemsPlaceHolder.Controls.Add(row);
                    row.Controls.Add(col1);
                    col1.Controls.Add(previewImg);

                    row.Controls.Add(col2);
                    col2.Controls.Add(h4);
                    col2.Controls.Add(ul);
                    ul.Controls.Add(l1);
                    ul.Controls.Add(l2);
                    ul.Controls.Add(l3);
                    col2.Controls.Add(hidden);
                    col2.Controls.Add(btn);
                }

                HtmlGenericControl s_row = new HtmlGenericControl("div");
                HtmlGenericControl s_col1 = new HtmlGenericControl("div");
                HtmlGenericControl s_col2 = new HtmlGenericControl("div");
                HtmlGenericControl s_p1 = new HtmlGenericControl("p");
                HtmlGenericControl s_p2 = new HtmlGenericControl("p");

                s_row.Attributes.Add("class", "row");
                s_col1.Attributes.Add("class", "col-md-8");
                s_col2.Attributes.Add("class", "col-md-4");

                s_p1.InnerText = string.Format("{0} island(s)", count);
                s_p2.InnerText = string.Format("${0:n}", total);

                summaryPlaceHolder.Controls.Add(s_row);
                s_row.Controls.Add(s_col1);
                s_col1.Controls.Add(s_p1);
                s_row.Controls.Add(s_col2);
                s_col2.Controls.Add(s_p2);

                taxes = (long)(total * 0.05);
                fees.InnerText = string.Format("${0:n}", taxes);
                grandtotal.InnerText = string.Format("${0:n}", total + taxes);

                btnCheckout.Click += new EventHandler(btnCheckout_Click);
            }
            else
            {
                summary.Visible = false;
                HtmlGenericControl h1 = new HtmlGenericControl("h1");
                HtmlGenericControl h3 = new HtmlGenericControl("h3");
                if (loggedOut)
                {
                    Response.Redirect("~/Login.aspx");
                    return;
                }
                h1.InnerText = "No items to display.";
                h3.InnerText = "You have not added any items to your cart. Try adding some from the Islands page!";
                itemsPlaceHolder.Controls.Add(h1);
                itemsPlaceHolder.Controls.Add(h3);
            }
        }
    }
}