using System;
using System.Collections.Generic;
using System.Web;
using System.Data.OleDb;

namespace PrivateIsland
{
    public static class ConnectionClass
    {
        private static string path = HttpRuntime.AppDomainAppPath;
        private static string cs = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @"\App_Data\PrivateIslandsDB.mdb";
        public static List<Island> getIslands()
        {
            List<Island> islands = new List<Island>();
            string query = "SELECT * FROM Islands WHERE for_sale=True";
            OleDbConnection conn = new OleDbConnection(cs);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            try
            { 
            
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Island island = new Island(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetBoolean(7));
                    islands.Add(island);
                }
                reader.Close();
                return islands;

            } 
            finally
            {
                conn.Close();
            }
        }

        public static Island getCartIsland(CartItem c)
        {
            Island island = null;
            string query = string.Format("SELECT * FROM Islands WHERE ID = {0}", c.IslandID);
            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                     island = new Island(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetBoolean(7));
                    
                }
                reader.Close();
                return island;
            }

        }


        public static bool HasActiveOrder(DummyCustomer active)
        {
            
            string query = string.Format("SELECT * FROM Orders WHERE customer_id = {0} AND active = True", active.ID);

            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else return false;
            }
        }
            

        public static Order getActiveOrder (DummyCustomer active)
        {
            Order order = null;
            string query = string.Format("SELECT * FROM Orders WHERE customer_id = {0} AND active = True", active.ID);
            OleDbConnection conn = new OleDbConnection(cs);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        order = new Order(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)
                           , reader.GetDateTime(3), reader.GetBoolean(4));

                    }
                    reader.Close();
                }
                return order;
            }
            finally
            {
                conn.Close();
            }
        }

        public static void setActiveOrder(DummyCustomer active)
        {
            using (OleDbConnection conn = new OleDbConnection(cs))
            {
                conn.Open();
                Order order = new Order(active.ID, 0, DateTime.Now, true);
                string query = string.Format("INSERT INTO Orders (customer_ID,total,ord_date,active) VALUES ({0},{1},'{2}',True)", order.CustomerID, order.Total, order.OrderDate);
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<CartItem> getCartItems(Order order)
        {
            List<CartItem> items = new List<CartItem>();
            string query = string.Format("SELECT * FROM CartItems WHERE order_id = {0}", order.ID);
            OleDbConnection conn = new OleDbConnection(cs);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            try
            {

                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CartItem c = new CartItem(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2));
                    items.Add(c);
                }
                reader.Close();
                return items;

            }
            finally
            {
                conn.Close();
            }
        }

        public static void addCartItem(int island_id,int order_id)
        {
            string query = string.Format("INSERT INTO CartItems (island_id,order_id) VALUES ({0},{1})",island_id,order_id);
            OleDbConnection conn = new OleDbConnection(cs);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

        public static void removeCartItem(int island_id, int order_id)
        {
            string query = string.Format("DELETE FROM CartItems WHERE island_id = {0} AND order_id = {1}", island_id,order_id);
            OleDbConnection conn = new OleDbConnection(cs);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
        public static void AddInfo(Info info)
        {
            string query = string.Format(@"insert into contactus values(NEXT VALUE FOR CountBy1,'{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                info.FirstName, info.LastName, info.Phone, info.Email, info.TypeInquiry, info.PerferedMethodContact, info.Message);
            OleDbConnection cn = new OleDbConnection(cs);
            OleDbCommand cmd = new OleDbCommand(query, cn);
            try
            {
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                cn.Close();
            }

        }
    }
}