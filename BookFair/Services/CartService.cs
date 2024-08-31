using BookFair.Controllers;
using BookFair.CustomeComponents;
using BookFair.Models;
using BookFair.Serializable;
using DevExpress.Data.Filtering;
using DevExpress.Web;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookFair.Services
{
    public class CartService
    {

        private static CartService _instance;
        private BookController _bookInstance = BookController.getInstance();
        private UserController _userController = UserController.getInstance();
        private CartController _cartController = CartController.getInstance();
        private OrderController _orderController = OrderController.getInstance();
        private CartService() { }

        public static CartService getInstance()
        {
            if (_instance == null)
            {
                _instance = new CartService();
            }
            return _instance;

        }

        public async Task<(bool, string)> Add_To_Cart(int user_id, int book_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Customer customer = await _userController.GetCustomer(uow, user_id);
                    string popWindowText = "";

                    Book book = await _bookInstance.GetBookInstanceByID(uow, book_id);
                    if (book != null)
                    {
                        Cart cart = await _cartController.CreateGetUserCart(uow, customer);
                        bool bookStatus = await _cartController.CheckBookExistCart(uow, book, cart);
                        if (!bookStatus)
                        {
                            await uow.CommitChangesAsync();
                            popWindowText = "The Book Is Already in Your Cart";
                            return (false, popWindowText);
                        }
                        else
                        {
                            await _cartController.AddItemToCart(uow, book, cart, 1);
                            await uow.CommitChangesAsync();

                            popWindowText = "The Book has been added to The Cart";
                            return (true, popWindowText);
                        }
                    }
                    else
                    {
                        popWindowText = "The Book is Sold Out";

                        await uow.CommitChangesAsync();

                        return (false, popWindowText);
                    }

                }
            }

            catch (Exception e)
            {

                throw;
            }

        }




        public async Task<List<CartInfo>> Get_Cart_Element(int user_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Customer customer = await _userController.GetCustomer(uow, user_id);
                    Cart cart = await _cartController.CreateGetUserCart(uow, customer);
                    List<CartInfo> data = null;                 
                    data = await _cartController.GetCartItems(uow, cart);
                    await uow.CommitChangesAsync();
                    return data;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }



        public async Task<bool> Change_Item_Quntity(int user_id, int book_id, string operation_type)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    var book = await _bookInstance.GetBookInstanceByID(uow, book_id);

                    Customer customer = await _userController.GetCustomer(uow, user_id);
                    if (customer != null)
                    {
                        Cart cart = await _cartController.CreateGetUserCart(uow, customer);
                        if (book != null)
                        {
                            CartItems cartItem = await _cartController.GetSingleCartItem(uow, cart, book);
                            if (cartItem != null)
                            {
                                int newQuantity = cartItem.Quantity;
                                if (operation_type == "increase")
                                {
                                    newQuantity += 1;
                                }
                                else if (operation_type == "decrese")
                                {
                                    newQuantity -= 1;

                                }
                                if (book.Quantity < newQuantity)
                                {
                                    await uow.CommitChangesAsync();

                                    return false;

                                }
                                else if (cartItem != null)
                                {

                                    cartItem.Quantity = newQuantity;

                                    await uow.CommitChangesAsync();

                                    return true;
                                }
                            }
                        }
                    }
                    await uow.CommitChangesAsync();

                    return false;

                }
            }
            catch (Exception e)
            {

                throw;
            }
        }


        public async Task Remove_Item(int user_id, int book_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {

                    var book = await _bookInstance.GetBookInstanceByID(uow, book_id);

                    Customer customer = await _userController.GetCustomer(uow, user_id);
                    if (customer != null)
                    {
                        Cart cart = await _cartController.CreateGetUserCart(uow, customer);
                        if (cart != null && book != null)
                        {
                            CartItems cartItem = await _cartController.GetSingleCartItem(uow, cart, book);
                            if (cartItem != null)
                            {

                                await uow.DeleteAsync(cartItem);
                            }
                        }
                    }
                    await uow.CommitChangesAsync();


                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        }
    }