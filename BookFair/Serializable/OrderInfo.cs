using BookFair.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookFair.Serializable
{
    [Serializable]
    public class OrderInfo
    {

        public int id { get; set; }
        public OrderStatus status { get; set; }
        public DateTime date { get; set; }
        public string customer_name { get; set; }
        public decimal total_price {  get; set; }
    }
}