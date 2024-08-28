using DevExpress.Xpo;
using System;

namespace BookFair.Models
{
    public class OrderItem : XPLiteObject
    {
        public OrderItem() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public OrderItem(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        [Key(true, AutoGenerate = true)]
        [Persistent("order_item_id")]

        private int _order_item_id;
        public int Order_Item_id
        {
            get => _order_item_id;
        }

        private string _title;
        [Persistent("title")]
        public string Title
        {
            get => _title;
            set { SetPropertyValue<string>(nameof(Title), ref _title, value); }
        }


        private decimal _price;
        [Persistent("price")]
        public decimal Price
        {
            get => _price;
            set { SetPropertyValue<decimal>(nameof(Price), ref _price, value); }
        }

        private int _quantity;
        [Nullable(true)]
        [Persistent("quantity")]
        public int Quantity
        {
            get => _quantity;
            set
            {
                SetPropertyValue<int>(nameof(Quantity), ref _quantity, value);

            }
        }

        private Order _Link_order;
        [Association]
        public Order Link_Order
        {
            get { return _Link_order; }
            set { SetPropertyValue(nameof(Link_Order), ref _Link_order, value); }
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
          
               Link_Order = null;
               Link_Book = null;

           
          
            base.OnDeleting();
        }


    }




}