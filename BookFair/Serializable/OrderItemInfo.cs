using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookFair.Serializable
{
    public class OrderItemInfo
    {

        public int id { get; set; }
        public int book_id { get; set; }

        public string title { get; set; }
        public int quantity { get; set; }
        public string image { get; set; }
        public decimal price { get; set; }
    }
}