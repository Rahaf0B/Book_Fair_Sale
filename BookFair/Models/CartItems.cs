using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace BookFair.Models
{
    public class CartItems : XPObject
    {
        public CartItems() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public CartItems(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }







        private int _quantity;
        [Persistent("quantity")]
        public int Quantity
        {
            get => _quantity;
            set
            {
                SetPropertyValue<int>(nameof(Quantity), ref _quantity, value);

            }
        }



        private Cart _Link_cart;
        [Association]
        public Cart Link_Cart
        {
            get { return _Link_cart; }
            set { SetPropertyValue(nameof(Link_Cart), ref _Link_cart, value); }
        }




        private Book _Link_book;
        [Association]
        public Book Link_Book
        {
            get { return _Link_book; }
            set { SetPropertyValue(nameof(Link_Book), ref _Link_book, value); }
        }



        protected override void OnDeleting()
        {

            Link_Cart = null;
            Link_Book = null;



            base.OnDeleting();
        }

    }





}