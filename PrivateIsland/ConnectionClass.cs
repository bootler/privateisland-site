using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace PrivateIsland
{
    public static class ConnectionClass
    {
        private static string path = HttpRuntime.AppDomainAppPath;
        private static string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + @"\App_Data\PrivateIslandsDB.mdb";

        //adds a cart item to the specified shopping cart
        public static void addCartItem(int island_id, int order_id)
        {
            string query = string.Format("INSERT INTO CartItems (island_id,order_id) VALUES ({0},{1})", island_id, order_id);
            OleDbConnection conn = new OleDbConnection(connString);
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

        //add a new customer to the Customers table
        public static void addCustomer(Customer newCust)
        {
            string query = string.Format("INSERT INTO Customers (firstname,lastname,dob,email,phone) VALUES ('{0}','{1}','{2}','{3}','{4}')", newCust.FirstName, newCust.LastName, newCust.DateOfBirth, newCust.Email, newCust.Phone);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //Adds the info from the contact form
        public static void AddInfo(Info info)
        {

            string query = string.Format(@"INSERT INTO ContactUs (firstname,lastname,phone,email,type_inquiry,pref_ctact_method,message) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                info.FirstName, info.LastName, info.Phone, info.Email, info.TypeInquiry, info.PerferedMethodContact, info.Message);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //add a new login record using the customer ID from the RegisterAccount() method
        public static void addLoginInfo(int cust_id, string user, string ph)
        {
            string query = string.Format("INSERT INTO Logins (customer_id,username,pass_hash) VALUES ({0},'{1}','{2}')", cust_id, user, ph);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //gets the active shopping cart associated with the logged in user
        public static Order getActiveOrder(Customer active)
        {
            Order order = null;
            string query = string.Format("SELECT * FROM Orders WHERE customer_id = {0} AND active = True", active.ID);
            OleDbConnection conn = new OleDbConnection(connString);
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

        //gets a collection of islands that are for sale to display on the islands page
        public static List<Island> getIslands()
        {
            List<Island> islands = new List<Island>();
            string query = "SELECT * FROM Islands WHERE for_sale=True";
            OleDbConnection conn = new OleDbConnection(connString);
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

        //gets all the items inside the user's shopping cart
        public static List<CartItem> getCartItems(Order order)
        {
            List<CartItem> items = new List<CartItem>();
            string query = string.Format("SELECT * FROM CartItems WHERE order_id = {0}", order.ID);
            OleDbConnection conn = new OleDbConnection(connString);
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

        public static bool HasCartItem(Order order, int island_id)
        {
            string query = string.Format("SELECT * FROM CartItems WHERE island_id = {0} AND order_id = {1} ", island_id, order.ID);
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(query, conn);
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else return false;
            }
            finally
            {
                conn.Close();
            }
        }

        //gets the island associated with the related CartItem, meaning an Island that is
        //in a user's shopping cart
        public static Island getCartIsland(CartItem c)
        {
            Island island = null;
            string query = string.Format("SELECT * FROM Islands WHERE ID = {0}", c.IslandID);
            using (OleDbConnection conn = new OleDbConnection(connString))
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

        //gets the customer by its ID. Helper method to set the active customer from the login info.
        public static Customer getCustomer(int id)
        {
            string query = string.Format("SELECT * FROM Customers WHERE ID = {0}", id);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                Customer cust = null;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cust = new Customer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                       reader.GetString(3), reader.GetString(4), reader.GetString(5));
                }
                reader.Close();
                return cust;
            }
        }

        //attempts to match a login record with the entered credentials
        public static Customer getLoggedInCustomer(string user)
        {
            Customer cust;
            string query = string.Format("SELECT customer_id FROM Logins WHERE username = '{0}'", user);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                OleDbCommand cmd = new OleDbCommand(query, conn);
                conn.Open();
                int id = (int)cmd.ExecuteScalar();
                cust = getCustomer(id);
                return cust;
            }
        }

        //check for an active shopping cart associated with the logged in user. 
        public static bool HasActiveOrder(Customer active)
        {

            string query = string.Format("SELECT * FROM Orders WHERE customer_id = {0} AND active = True", active.ID);

            using (OleDbConnection conn = new OleDbConnection(connString))
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

        //verifies that an existing record matching the entered login credentials exist.
        public static bool LoginMatched(string user, string passHash)
        {
            string query = string.Format("SELECT customer_id FROM Logins WHERE username = '{0}' AND pass_hash = '{1}'", user, passHash);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else return false;
            }
        }

        //registers a new Customer record, first without an ID
        //then immediately select the auto-incremented ID for the customer we just created
        //and use that to create the related record in the logins table
        public static void RegisterAccount(Customer createdCust, string user, string phash)
        {
            int cust_id;
            addCustomer(createdCust);
            string query = string.Format("SELECT Max(ID) AS newest FROM Customers");
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cust_id = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }
            addLoginInfo(cust_id, user, phash);
        }

        //removes a cart item from the specified shopping cart
        public static void removeCartItem(int id)
        {
            string query = string.Format("DELETE FROM CartItems WHERE ID = {0}", id);
            OleDbConnection conn = new OleDbConnection(connString);
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

        //removes a cart item from the specified shopping cart
        public static void removeCartItem(int island_id, int order_id)
        {
            string query = string.Format("DELETE FROM CartItems WHERE island_id = {0} AND order_id = {1}", island_id, order_id);
            OleDbConnection conn = new OleDbConnection(connString);
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

        //put all islands back up for sale, meaning they will all be displayed again
        public static void resetSoldStatus()
        {
            string query = string.Format("UPDATE Islands SET for_sale = True");
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //creates a new shopping cart for the logged in user. If the session cannot find
        //an active cart, this method is called automatically to create one
        public static void setActiveOrder(Customer active)
        {
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                Order order = new Order(active.ID, 0, DateTime.Now, true);
                string query = string.Format("INSERT INTO Orders (customer_id,total,ord_date,active) VALUES ({0},{1},'{2}',True)", order.CustomerID, order.Total, order.OrderDate);
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //sets the current active order to inactive, forcing the session to create a new cart for the user.
        public static void setInactiveOrder(Order order)
        {
            string query = string.Format("UPDATE Orders SET active = False WHERE ID = {0}", order.ID);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        //sets the island given by the id to a stauts of sold meaning that it won't display on the product page
        public static void setSold(int island_id)
        {
            string query = string.Format("UPDATE Islands SET for_sale = FALSE WHERE ID = {0}", island_id);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                cmd.ExecuteNonQuery();
            }

        }

        //Check if the username submitted for registration already exists in the database
        public static bool UsernameExists(string username)
        {
            string query = string.Format("SELECT * FROM Logins WHERE username = '{0}'", username);
            using (OleDbConnection conn = new OleDbConnection(connString))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(query, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else return false;
            }
        }

        /* Utility methods */

        //generate a hash of the entered password. 
        //Used so that we never expose plaintext passwords.
        public static string getHashedPassword(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var data = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha1.ComputeHash(data);

            string hashedPass = Convert.ToBase64String(hash);
            return hashedPass;
        }
    }
}