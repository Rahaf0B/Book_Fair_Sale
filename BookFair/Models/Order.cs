using BookFair.Enums;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BookFair.Models
{
    public class Order : XPLiteObject
    {
        public Order() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Order(Session session) : base(session)
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
        [Persistent("order_id")]

        private int _order_id;
        public int Order_id
        {
            get => _order_id;
        }

        private OrderStatus _order_status;
        [Persistent("order_status")]
        public OrderStatus Order_Status
        {
            get => _order_status;
            set
            {
                SetPropertyValue<OrderStatus>(nameof(Order_Status), ref _order_status, value);
            }
        }

        private DateTime _oder_date;
        [Persistent("order_date")]
        public DateTime Order_Date
        {
            get => _oder_date;
            set
            {
                SetPropertyValue<DateTime>(nameof(Order_Date), ref _oder_date, value);
            }
        }

        [Association, Browsable(false)]
        public IList<OrderItem> Order_Items
        {
            get
            {
                return GetList<OrderItem>(nameof(Order_Items));
            }
        }

        [ManyToManyAlias(nameof(Order_Items), nameof(OrderItem.Link_Book))]
        public IList<Book> Books
        {
            get
            {
                return GetList<Book>(nameof(Books));
            }
        }



        [Association("Customer-Orders")]
        public Customer Customer
        {
            get { return customer; }
            set { SetPropertyValue(nameof(Customer), ref customer, value); }
        }
        Customer customer;


        protected override void OnDeleting()
        {
            var itemsCopy = Order_Items.ToList();

            foreach (var item in itemsCopy)
            {
                item.Link_Order = null;
                item.Link_Book = null;
                item.Delete();
            }
            Customer = null;

            base.OnDeleting();
        }

    }



}