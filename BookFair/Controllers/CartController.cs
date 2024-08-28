using BookFair.Interfaces;
using BookFair.Models;
using BookFair.Serializable;
using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Native.Web;
using DevExpress.Web.ASPxScheduler.Rendering;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.XtraReports.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
using static Google.Apis.Requests.BatchRequest;

namespace BookFair.Controllers
{

    public class CartController
    {

        private static CartController instance;

        private CartController() { }
        public static CartController getInstance()
        {
            if (instance == null)
            {
                instance = new CartController();
            }
            return instance;

        }




        public async Task<Cart> CreateGetUserCart(Session session, Customer customer)
        {
            try
            {
                Cart cart = await session.FindObjectAsync<Cart>(new BinaryOperator("Customer", customer.User_id));
                if (cart == null)
                {
                    cart = new Cart(session)
                    {

                        Customer = customer,
                    };
                }
                await session.SaveAsync(cart);
                return cart;
            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public async Task<bool> CheckBookExistCart(Session session, Book book, Cart cart)
        {
            try

            {

                CriteriaOperator ItemFilter = CriteriaOperator.Parse("Link_Book = ? and Link_Cart", book, cart);

                CartItems item = await session.FindObjectAsync<CartItems>(ItemFilter);

                return item != null;


            }
            catch (Exception ex)
            {
                throw;

            }
        }

        public async Task AddItemToCart(Session session, Book book, Cart cart, int quantity)
        {
            try

            {
                CartItems cartItems = new CartItems(session)
                {

                    Link_Cart = cart,
                    Link_Book = book,
                    Quantity = quantity


                };

                await session.SaveAsync(cartItems);

            }
            catch (Exception ex)
            {
                throw;

            }
        }



        public async Task<List<CartInfo>> GetCartItems(Session session, Cart cart)
        {
            try
            {


                XPQuery<Book> books = new XPQuery<Book>(session);
                XPQuery<CartItems> items = new XPQuery<CartItems>(session);

                List<CartInfo> cartItems = await Task.Run(() => items.Where(item => item.Link_Cart == cart)
                .Join(books, item => item.Link_Book, book => book, (item, book) => new CartInfo
                {
                    id = book.Book_id,
                    image = book.Image != null ? book.Image.ToString() : string.Empty,
                    price = book.Price,
                    title = book.Title != null ? book.Title.ToString() : string.Empty,

                    quantity = item.Quantity

                }).ToList());


                return cartItems;




            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public async Task<CartItems> GetSingleCartItem(Session session, Cart cart, Book book)
        {
            try
            {


                XPQuery<CartItems> items = new XPQuery<CartItems>(session);

                CartItems cartItem = await items.FirstOrDefaultAsync(item => item.Link_Book == book && item.Link_Cart == cart);


                return cartItem;




            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task UpdateQuntityCartItem(Session session, CartItems cartItem, int quantity)
        {
            try
            {
                if (cartItem != null)
                {
                    cartItem.Quantity = quantity;

                    await session.SaveAsync(cartItem);
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }




    }
}