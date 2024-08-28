using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BookFair.Models
{
    public class Cart : XPLiteObject
    {
        public Cart() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Cart(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        private int _cart_id;
        [Persistent("cart_id")]
        [Key(true)]
        public int Cart_Id
        {
            get => _cart_id;
            set { SetPropertyValue(nameof(Cart_Id), ref _cart_id, value); }

        }




        [Association, Browsable(false)]
        public IList<CartItems> Cart_Items
        {
            get
            {
                return GetList<CartItems>(nameof(Cart_Items));
            }
        }

        [ManyToManyAlias(nameof(Cart_Items), nameof(CartItems.Link_Book))]
        public IList<Book> Books
        {
            get
            {
                return GetList<Book>(nameof(Books));
            }
        }


        private Customer _customer;
        [Aggregated]
        [Persistent("user_id")]
        public Customer Customer
        {
            get => _customer;
            set { SetPropertyValue<Customer>(nameof(Customer), ref _customer, value); }
        }


    }
}