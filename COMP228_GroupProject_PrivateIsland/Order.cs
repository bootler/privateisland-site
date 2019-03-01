using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COMP228_GroupProject_PrivateIsland
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public long Total { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsActive { get; set; }

        public Order(int id,int cust_id,long total,DateTime date,bool active)
        {
            ID = id;
            CustomerID = cust_id;
            Total = total;
            OrderDate = date;
            IsActive = active;
        }

        public Order(int cust_id,long total,DateTime date,bool active)
        {
            CustomerID = cust_id;
            Total = total;
            OrderDate = date;
            IsActive = active;
        }
    }
}