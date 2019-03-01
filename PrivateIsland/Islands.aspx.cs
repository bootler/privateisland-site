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
        List<Island> islands;
        int index;
        bool flag;
        Order o;
        protected void Page_Load(object sender, EventArgs e)
        {
            flag = false;
            islands = ConnectionClass.getIslands();
            Label menuLabel;

            if (Session["ActiveUser"] != null)
            {
                if (ConnectionClass.HasActiveOrder((Customer)Session["ActiveUser"]))
                {
                    Session["ActiveOrder"] = ConnectionClass.getActiveOrder((Customer)Session["ActiveUser"]);
                }
                else
                {
                    ConnectionClass.setActiveOrder((Customer)Session["ActiveUser"]);
                    Session["ActiveOrder"] = ConnectionClass.getActiveOrder((Customer)Session["ActiveUser"]);
                }

                Customer c = (Customer)Session["ActiveUser"];
                o = (Order)Session["ActiveOrder"];

                menuLabel = (Label)Master.FindControl("Label1");
                menuLabel.Text = string.Format("Welcome, {0} {1} | Cart: {2}", c.FirstName, c.LastName, o.ID);
            }
            else
            {
                flag = true;
                menuLabel = (Label)Master.FindControl("Label1");
                menuLabel.Text = string.Format("Welcome! Please login");
            }
            GenerateContent();
        }

        protected void button_Click(Object sender, EventArgs e)
        {
            if (flag)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            Button thisBtn = sender as Button;
            HiddenField hidden = thisBtn.Parent.Controls[2] as HiddenField;
            int id = int.Parse(hidden.ID);
            Order o = Session["ActiveOrder"] as Order;

            ConnectionClass.addCartItem(id, o.ID);

            thisBtn.Text = "Added to Cart";
            thisBtn.Enabled = false;
            thisBtn.CssClass = "btn btn-primary btn-disabled btn-asp-special";

            Button neighbor = thisBtn.Parent.Controls[1] as Button;
            neighbor.Visible = true;
            neighbor.Text = "Remove from Cart";
        }

        protected void unload_Click(Object sender, EventArgs e)
        {
            if (flag)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            Button thisBtn = sender as Button;
            HiddenField hidden = thisBtn.Parent.Controls[2] as HiddenField;
            int id = int.Parse(hidden.ID);
            Order o = Session["ActiveOrder"] as Order;

            ConnectionClass.removeCartItem(id, o.ID);

            thisBtn.Text = "Removed from Cart";
            //thisBtn.Enabled = false;
            thisBtn.CssClass = "btn btn-danger btn-disabled";
            thisBtn.Visible = false;

            Button neighbor = thisBtn.Parent.Controls[0] as Button;
            neighbor.Text = "Add to Cart";
            neighbor.Enabled = true;

        }

        protected void GenerateContent()
        {
            int records = islands.Count;

            //figure out how many row elements we need to display every island in the table.
            //each row element contains up to 3 column elements, representing a record from the database
            //so if the number of records is a multiple of 3 we need 1/3rd as many rows as records
            //if not, we need 1/3rd as many rows, +1 extra row to hold the leftover records.
            HtmlGenericControl[] rows = (records % 3 == 0) ? new HtmlGenericControl[records / 3]
                : new HtmlGenericControl[(records / 3) + 1];

            //HtmlGenericControl[] cols = new HtmlGenericControl[12];
            Island island;

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = new HtmlGenericControl("div");
                rows[i].Attributes.Add("class", "row");
                PlaceHolder1.Controls.Add(rows[i]);
                for (int j = 0; j < 3; j++)
                {
                    //do not attempt to put any more records in the current row if we have
                    //reached the end of the data source
                    if (index >= records) break;

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
                    HiddenField hidden = new HiddenField();

                    col.Attributes.Add("class", "col-md-4");

                    island = islands[index];
                    index++;

                    hidden.ID = string.Format("{0}", island.ID);


                    lbl1.Text = island.Name.ToUpper();

                    img.CssClass = "island-img";
                    img.ImageUrl = "https://i.imgur.com/" + island.ImageUrl;
                    img.Height = 300;
                    img.Width = 350;

                    lbl2.Text = island.Description;

                    l1.Attributes.Add("class", "loc-bullet");
                    l1.InnerText = island.Location;

                    l2.Attributes.Add("class", "size-bullet");
                    l2.InnerText = string.Format("{0} acre(s)", island.Acres);

                    l3.Attributes.Add("class", "money-bullet");
                    l3.InnerText = string.Format("${0:n0}", island.Price);

                    if (!flag && ConnectionClass.HasCartItem(o, int.Parse(hidden.ID)))
                    {
                        btn.CssClass = "btn btn-primary btn-disabled btn-asp-special";
                        btn.Enabled = false;
                        btn.Text = "Added to Cart";
                        btn.Click += new EventHandler(button_Click);

                        unloadBtn.CssClass = "btn btn-danger";
                        unloadBtn.Text = "Remove from Cart";
                        unloadBtn.Visible = true;
                        unloadBtn.Click += new EventHandler(unload_Click);
                    }
                    else
                    {
                        btn.CssClass = "btn btn-primary btn-asp-special";
                        btn.Text = "Add to Cart";
                        btn.Click += new EventHandler(button_Click);

                        unloadBtn.CssClass = "btn btn-danger";
                        unloadBtn.Text = "Remove from Cart";
                        unloadBtn.Visible = false;
                        unloadBtn.Click += new EventHandler(unload_Click);
                    }

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
                    p2.Controls.Add(hidden);

                }
            }
        }
    }
}