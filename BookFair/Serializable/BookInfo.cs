using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookFair.Serializable
{
    [Serializable]
    public class BookInfo
    {
        public int id { get; set; }
        public string title { get; set; }
        public string subject { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public decimal price { get; set; }
        public string publisher { get; set; }
        public int quantity { get; set; }
        public string image { get; set; }
    }
}