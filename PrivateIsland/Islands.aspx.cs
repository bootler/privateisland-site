using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace PrivateIsland
{
    public partial class Islands : System.Web.UI.Page
    {
        List<Island> islands = ConnectionClass.getIslands();       
        bool flag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //replacement for pending work - remove when user page is done.
            //Session["ActiveUser"] = new DummyCustomer(1);

            if (ConnectionClass.HasActiveOrder((DummyCustomer)Session["ActiveUser"]))
            {
                Session["ActiveOrder"] = ConnectionClass.getActiveOrder((DummyCustomer)Session["ActiveUser"]);
            }
            else
            {
                ConnectionClass.setActiveOrder((DummyCustomer)Session["ActiveUser"]);
                Session["ActiveOrder"] = ConnectionClass.getActiveOrder((DummyCustomer)Session["ActiveUser"]);
            }

            DummyCustomer c = (DummyCustomer)Session["ActiveUser"];
            Order o = (Order)Session["ActiveOrder"];

            Label menuLabel = (Label)Master.FindControl("Label1");
            menuLabel.Text = string.Format("Welcome UserID: {0} | Cart: {1}", c.ID, o.ID);
            GenerateContent();
            
        }

        protected void button_Click(Object sender, EventArgs e)
        {
            Order o = Session["ActiveOrder"] as Order;
            ConnectionClass.addCartItem(1, o.ID);
            
            Button thisBtn = sender as Button;
            thisBtn.Text = "Added to Cart";
            thisBtn.Enabled = false;
            thisBtn.CssClass = "btn btn-primary btn-disabled";

            Button neighbor = thisBtn.Parent.Controls[1] as Button;
            neighbor.Visible = true;
            neighbor.Enabled = true;
            neighbor.Text = "Remove from Cart";
        }

        protected void unload_Click(Object sender, EventArgs e)
        {
            Order o = Session["ActiveOrder"] as Order;
            ConnectionClass.removeCartItem(1, o.ID);

            Button thisBtn = sender as Button;
            thisBtn.Text = "Removed from Cart";
            thisBtn.Enabled = false;
            thisBtn.CssClass = "btn btn-primary btn-disabled";
            //thisBtn.Visible = false;

            Button neighbor = thisBtn.Parent.Controls[0] as Button;
            neighbor.Text = "Add to Cart";
            neighbor.Enabled = true;

        }

        protected void GenerateContent()
        {
            HtmlGenericControl[] rows = new HtmlGenericControl[4];
            //HtmlGenericControl[] cols = new HtmlGenericControl[12];
            Island island = islands[0];

            for(int i = 0; i < rows.Length; i++)
            {
                rows[i] = new HtmlGenericControl("div");
                rows[i].Attributes.Add("class", "row");
                PlaceHolder1.Controls.Add(rows[i]);
                for (int j = 0; j < 3; j++)
                {
                    
                    HtmlGenericControl col = new HtmlGenericControl("div");
                    HtmlGenericControl h2 = new HtmlGenericControl("h2");
                    Label lbl1 = new Label();
                    Image img = new Image();
                    HtmlGenericControl p = new HtmlGenericControl("p");
                    Label lbl2 = new Label();
                    HtmlGenericControl ul = new HtmlGenericControl("ul");
                    HtmlGenericControl l1 = new HtmlGenericControl("li");
                    HtmlGenericControl l2 = new HtmlGenericControl("li");
                    HtmlGenericControl l3 = new HtmlGenericControl("li");
                    HtmlGenericControl p2 = new HtmlGenericControl("p");
                    Button btn = new Button();
                    Button unloadBtn = new Button();

                    col.Attributes.Add("class", "col-md-4");

                    if (!flag)
                    {
                        lbl1.Text = island.Name;

                        img.CssClass = "island-img";
                        img.ImageUrl = "https://i.imgur.com/"+island.ImageUrl;
                        img.Height = 300;
                        img.Width = 350;

                        lbl2.Text = island.Description;

                        l1.InnerText = island.Location;
                        l2.InnerText = string.Format("{0}", island.Acres);
                        l3.InnerText = string.Format("{0}", island.Price);
                        flag = true;
                    }
                    else
                    {
                        lbl1.Text = "Island Name";

                        img.CssClass = "island-img";
                        img.ImageUrl = "https://i.imgur.com/I5DkMRy.jpg";
                        img.Height = 300;
                        img.Width = 350;

                        lbl2.Text = "Beautiful Island off the coast of Antarctica. It's freezing and uninhabitable.";

                        l1.InnerText = "Location";
                        l2.InnerText = "Size";
                        l3.InnerText = "Price";
                    }
                    btn.CssClass = "btn btn-primary";
                    btn.Text = "Add to Picks";
                    btn.Click += new EventHandler(button_Click);

                    unloadBtn.CssClass = "btn btn-danger";
                    unloadBtn.Text = "Remove from cart";
                    //unloadBtn.Visible = false;
                    unloadBtn.Click += new EventHandler(unload_Click);
                    

                    rows[i].Controls.Add(col);
                    col.Controls.Add(h2);
                    h2.Controls.Add(lbl1);
                    col.Controls.Add(img);
                    col.Controls.Add(p);
                    col.Controls.Add(ul);

                    ul.Controls.Add(l1);
                    ul.Controls.Add(l2);
                    ul.Controls.Add(l3);

                    p.Controls.Add(lbl2);
                    col.Controls.Add(p2);
                    p2.Controls.Add(btn);
                    p2.Controls.Add(unloadBtn);
                }
            }
        }
    }
}