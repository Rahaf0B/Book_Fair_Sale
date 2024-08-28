using DevExpress.Xpo;
using System;

namespace BookFair.Models
{
    public class Customer : User
    {
        public Customer() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Customer(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }



        private string _order_address;
        [Persistent("order_address")]
        [Nullable(true)]
        public string Order_Address
        {
            get => _order_address;
            set
            {
                SetPropertyValue(nameof(Order_Address), ref _order_address, value);
            }
        }

        [Association("Customer-Orders")]
        public XPCollection<Order> Orders
        {
            get { return GetCollection<Order>(nameof(Orders)); }
        }



    }

}