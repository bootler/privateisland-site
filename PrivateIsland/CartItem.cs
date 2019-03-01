using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrivateIsland
{
    public class CartItem
    {
        public int ID { get; }
        public int IslandID { get; set; }
        public int OrderID { get; set; }

        public CartItem(int id, int isl_id,int ord_id)
        {
            ID = id;
            IslandID = isl_id;
            OrderID = ord_id;
        }

        public CartItem(int isl_id, int ord_id)
        {
            IslandID = isl_id;
            OrderID = ord_id;
        }
    }
}