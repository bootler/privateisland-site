using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace PrivateIsland
{
    public partial class SampleForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpRuntime.AppDomainAppPath;
            string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+path+@"\App_Data\PrivateIslandsDB.mdb";
            OleDbConnection cn = new OleDbConnection(cs);
            try
            {
                cn.Open();
                Label1.Text = "Successful Connection to DB";
            }
            catch
            {
                Label1.Text = path;
            }
            finally
            {
                cn.Close();
            }
        }
    }
}