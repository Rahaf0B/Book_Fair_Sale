using BookFair.Models;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BookFair.Models
{
    [Persistent("Book")]
    public class Book : XPLiteObject
    {
        public Book() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Book(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
        }



        [Persistent("book_id")]
        [Key(true)]
        private int _book_id;
        public int Book_id
        {
            get => _book_id;
        }

        //This Attribute Should have => full-text search index
        private string _title;
        [Persistent("title")]
        [Indexed(Unique = true)]
        public string Title
        {
            get => _title;
            set { SetPropertyValue<string>(nameof(Title), ref _title, value); }
        }




        [Association("Subject-Books")]
        public Subject Subject
        {
            get { return subject; }
            set { SetPropertyValue(nameof(Subject), ref subject, value); }
        }
        Subject subject;


        private string _description;
        [Persistent("description")]
        [Size(250)]
        [Nullable(true)]
        public string Description
        {
            get => _description;
            set { SetPropertyValue<string>(nameof(Description), ref _description, value); }
        }



        [Association("Author-Books")]
        public Author Author
        {
            get { return author; }
            set { SetPropertyValue(nameof(Author), ref author, value); }
        }
        Author author;


        private decimal _price;
        [Persistent("price")]
        public decimal Price
        {
            get => _price;
            set { SetPropertyValue<decimal>(nameof(Price), ref _price, value); }
        }


        private string _publisher;
        [Persistent("publisher")]
        public string Publisher
        {
            get => _publisher;
            set
            {
                SetPropertyValue<string>(nameof(Publisher), ref _publisher, value);

            }
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

        private string _image;
        [Persistent("image")]
        [Nullable(true)]
        [Size(2000)]
        public string Image
        {
            get => _image;
            set
            {
                SetPropertyValue<string>(nameof(Image), ref _image, value);

            }
        }


        [Association, Browsable(false)]
        public IList<CartItems> Cart_Items
        {
            get
            {
                return GetList<CartItems>(nameof(Cart_Items));
            }
        }

       
        [ManyToManyAlias(nameof(Cart_Items), nameof(CartItems.Link_Cart))]
        public IList<Cart> Carts
        {
            get
            {
                return GetList<Cart>(nameof(Carts));
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



      
        [ManyToManyAlias(nameof(Order_Items), nameof(OrderItem.Link_Order))]
        public IList<Order> Orders
        {
            get
            {
                return GetList<Order>(nameof(Orders));
            }
        }






        protected override void OnDeleting()
        {
            var itemsCopyCart = Cart_Items.ToList();

            foreach (var cartItem in itemsCopyCart)
            {
                cartItem.Link_Book = null;
                cartItem.Save();
            }

            foreach (var cart in Carts.ToList())
            {
                cart.Books.Remove(this);
                cart.Save();
            }

            var itemsCopyOrder = Order_Items.ToList();


            foreach (var ordertItem in itemsCopyOrder)
            {
                ordertItem.Link_Book = null;
                ordertItem.Save();
            }

            foreach (var order in Orders.ToList())
            {
                order.Books.Remove(this);
                order.Save();
            }
            
            base.OnDeleting();
        }
    }

}