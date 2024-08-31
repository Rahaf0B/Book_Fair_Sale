using BookFair.Controllers;
using BookFair.CustomeComponents;
using BookFair.Enums;
using BookFair.Models;
using BookFair.Serializable;
using DevExpress.Web;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookFair.Services
{
    public class OrderService
    {

        private static OrderService _instance;
        private BookController _bookInstance = BookController.getInstance();
        private UserController _userController = UserController.getInstance();
        private CartController _cartController = CartController.getInstance();
        private OrderController _orderController = OrderController.getInstance();
        private OrderService() { }

        public static OrderService getInstance()
        {
            if (_instance == null)
            {
                _instance = new OrderService();
            }
            return _instance;

        }

        public async Task Craete_Order(int user_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Customer customer = await _userController.GetCustomer(uow, user_id);


                    Cart cart = await _cartController.CreateGetUserCart(uow, customer);
                    if (cart != null)
                    {

                        List<CartInfo> cartItems = await _cartController.GetCartItems(uow, cart);
                        Order order = await _orderController.CreateAndGetCreatedOrder(uow, customer);
                            decimal Total_Price = 0;

                        foreach (CartInfo item in cartItems)
                        {
                            Book book = await _bookInstance.GetBookInstanceByID(uow, item.id);

                            if (book.Quantity >= item.quantity)
                            {
                                Total_Price= Total_Price+ book.Price;
                                CartItems cartItem = await _cartController.GetSingleCartItem(uow, cart, book);
                                book.Quantity = book.Quantity - item.quantity;
                                await uow.SaveAsync(book);
                                await _orderController.addElementToTheOrder(uow, book, order, item.quantity);
                                await uow.DeleteAsync(cartItem);
                            }
                        }
                        
                            order.Total_Price = order.Total_Price + Total_Price;
                            await uow.SaveAsync(order);

                    }

                    await uow.CommitChangesAsync();

                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<OrderInfo>> Get_User_Orders(int user_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Customer customer = await _userController.GetCustomer(uow, user_id);
                    List<OrderInfo> orderInfo = await _orderController.GetOrdersForCustomer(uow, customer);
                    await uow.CommitChangesAsync();
                    return orderInfo;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<(List<OrderItemInfo>, OrderStatus)> Get_Customer_Order_Items(int order_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {

                    Order order = await _orderController.GetSingleCustomerOrderById(uow, order_id);
                    List<OrderItemInfo> orderItems = await _orderController.GetOrderItems(uow, order);
                    return (orderItems, order.Order_Status);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }





        public async Task Update_Quantity_Customer_Order_Single_Item(int order_item_id, string op_type)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {

                    OrderItem item = await _orderController.GetOrderItemById(uow, order_item_id);
                    if (item != null)
                    {
                        if (op_type == "add")
                        {
                            if (item.Link_Book != null && item.Link_Book.Quantity >= item.Quantity + 1)
                            {
                                await _orderController.UpdateQuntityOrderItem(uow, item, item.Quantity + 1);
                                await _bookInstance.UpdateBookQuantity(uow, item.Link_Book, item.Link_Book.Quantity - 1);

                            }
                        }
                        else if (op_type == "sub")
                        {
                            if (item.Link_Book != null && item.Quantity != 1)
                            {
                                await _orderController.UpdateQuntityOrderItem(uow, item, item.Quantity - 1);
                                await _bookInstance.UpdateBookQuantity(uow, item.Link_Book, item.Link_Book.Quantity + 1);

                            }
                        }
                    }

                    await uow.CommitChangesAsync();

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public async Task Remove_Item_From_Order(int order_item_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {

                    OrderItem item = await _orderController.GetOrderItemById(uow, order_item_id);
                    if (item != null)
                    {
                        await _orderController.removeOrderItem(uow, item);
                        await uow.CommitChangesAsync();

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        public async Task<(bool, string)> Add_Item_To_Order(int book_id, int order_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Book book = await _bookInstance.GetBookInstanceByID(uow, book_id);

                    string statusText;
                    bool status;
                    if (book != null && book.Quantity <= 0)
                    {
                        statusText = "The Book Is Sold Out";
                        status = false;
                    }
                    else
                    {
                        Order order = await _orderController.GetSingleCustomerOrderById(uow, order_id);

                        bool ItemExist = await _orderController.CheckBookExistInOrder(uow, book, order);
                        if (ItemExist)
                        {
                            statusText = "The Book Is Already in Your Order";
                            status = false;
                        }

                        else
                        {
                            statusText = "The Book has been added to The Order";
                            status = true;
                            await _orderController.addElementToTheOrder(uow, book, order, 1);

                        }
                    }

                    await uow.CommitChangesAsync();
                    return (status, statusText);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }






        public async Task<(List<OrderInfo>, int)> Get_All_Customers_Orders(int pageNumber, int pageSize)
        {
            try
            {

                using (Session session = new Session())
                {
                    (List<OrderInfo> info, int NumberOfItems) = await _orderController.GetAllOrders(session, pageNumber, pageSize);

                    return (info, NumberOfItems);

                }
            }
            catch (Exception ex) { throw; }
        }




        public async Task<OrderInfo> Get_Single_Order_With_Customer_Info(int order_id)
        {
            try
            {

                using (Session session = new Session())
                {

                    OrderInfo info = await _orderController.GetSingleOrderInfoByOrderId(session, order_id);
                    return info;
                }

            }
            catch (Exception ex) { return null; }
        }


        public async Task Update_Order_Status(int order_id, OrderStatus status)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Order order = await _orderController.GetSingleCustomerOrderById(uow, order_id);



                    await _orderController.updateOrderStatus(uow, order, status);
                    await uow.CommitChangesAsync();

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task Delete_User_Order(int order_id)
        {
            try
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    Order order = await _orderController.GetSingleCustomerOrderById(uow, order_id);
                    await _orderController.DeleteOrder(uow, order);
                    await uow.CommitChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}