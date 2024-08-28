using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFair.Interfaces
{
    internal interface IBook
    {
        string title { get; set; }
   string subject { get; set; }
        string description { get; set; }
        string    author { get; set; }
         decimal   price { get; set; }
         string   publisher    { get; set; }
            int quantity { get; set; }
        string img {  get; set; }
    }
}
