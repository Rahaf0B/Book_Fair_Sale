using BookFair.Enums;
using BookFair.Models;
using BookFair.Serializable;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Data.ODataLinq.Helpers;
using DevExpress.Office.Utils;
using DevExpress.Xpo;
using DevExpress.XtraScheduler.iCalendar.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static DevExpress.Drawing.Printing.Internal.DXPageSizeInfo;

namespace BookFair.Controllers
{
    public class OrderController
    {


        private static OrderController instance;

        private OrderController() { }
        public static OrderController getInstance()
        {
            if (instance == null)
            {
                instance = new OrderController();
            }
            return instance;

        }


        public async Task<Order> CreateAndGetCreatedOrder(Session session, Customer customer)
        {
            try
            {

                Order order = new Order(session)
                {

                    Customer = customer,
                    Order_Date = DateTime.Now,
                    Order_Status = OrderStatus.pending,
                };


                await session.SaveAsync(order);

                return order;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task addElementToTheOrder(Session session, Book book, Order order, int quantity)
        {
            try
            {

                OrderItem orderItem = new OrderItem(session)
                {
                    Link_Book = book,
                    Link_Order = order,
                    Price = book.Price,
                    Title = book.Title,
                    Quantity = quantity,
                };

                await session.SaveAsync(orderItem);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<List<OrderInfo>> GetOrdersForCustomer(Session session, Customer customer)
        {
            try
            {
                XPQuery<Order> orders = new XPQuery<Order>(session);
                List<OrderInfo> orderInfos = await Task.Run(() => orders.Where((order) => order.Customer == customer)
                .Select(order =>
                new OrderInfo { customer_name = order.Customer.First_Name + " " + order.Customer.Last_Name,
                    date = order.Order_Date,
                    id = order.Order_id, 
                    status = order.Order_Status }).ToList());

                return orderInfos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<OrderInfo> GetSingleOrderInfoByOrderId(Session session, int order_id)
        {
            try
            {
                OrderInfo orderInfo = await session.GetObjectByKeyAsync<Order>(order_id).ContinueWith((order) =>
                new OrderInfo
                {
                    customer_name = order.Result.Customer.First_Name + " " + order.Result.Customer.Last_Name,
                    date = order.Result.Order_Date,
                    id = order.Result.Order_id,
                    status = order.Result.Order_Status
                }

                );


                return orderInfo;


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Order> GetSingleCustomerOrderById(Session session, int order_id)
        {
            try
            {


                Order order = await session.GetObjectByKeyAsync<Order>(order_id);

                return order;


            }
            catch (Exception ex)
            {
                throw;
            }
        }




        public async Task<List<OrderItemInfo>> GetOrderItems(Session session, Order order)
        {
            try
            {
                XPQuery<OrderItem> orderItems = new XPQuery<OrderItem>(session);
                List<OrderItemInfo> ItemInfo = await Task.Run(() => orderItems.Where((item) => item.Link_Order == order)
                    .Select(orderItem => new OrderItemInfo
                    {
                        id = orderItem.Order_Item_id,
                        image = orderItem.Link_Book.Image,
                        title = orderItem.Title,
                        price = orderItem.Price,
                        quantity = orderItem.Quantity,
                        book_id = orderItem.Link_Book.Book_id
                    }).ToList());



                return ItemInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OrderItem> GetOrderItemById(Session session, int order_item_id)
        {
            try
            {
                OrderItem item = await session.GetObjectByKeyAsync<OrderItem>(order_item_id);
                return item;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateQuntityOrderItem(Session session, OrderItem orderItem, int quantity)
        {
            try
            {
                if (orderItem != null)
                {
                    orderItem.Quantity = quantity;

                    await session.SaveAsync(orderItem);
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task removeOrderItem(Session session, OrderItem orderItem)
        {
            try
            {
                await session.DeleteAsync(orderItem);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<bool> CheckBookExistInOrder(Session session, Book book, Order order)
        {
            try
            {

                XPQuery<OrderItem> items = new XPQuery<OrderItem>(session);

                int NumberOfItemsReturned = await Task.Run(items.Where((item) => item.Link_Book == book && item.Link_Order == order).Count);
                return NumberOfItemsReturned != 0;



            }
            catch (Exception ex)
            {
                throw;

            }
        }


        public async Task<(List<OrderInfo>, int)> GetAllOrders(Session session, int PageNumber, int PageSize)
        {
            try
            {

                XPQuery<Order> orders = new XPQuery<Order>(session);
                XPQuery<Customer> customers = new XPQuery<Customer>(session);




                var ordersInfo = orders.Join(customers, o => o.Customer, c => c, (o, c) =>
                new OrderInfo
                {
                    customer_name = c.First_Name + c.Last_Name,
                    id = o.Order_id,
                    date = o.Order_Date,
                    status = o.Order_Status

                }).ToList();

                int numberOfItems = ordersInfo.Count();
                List<OrderInfo> data = await Task.Run(() => ordersInfo.OrderBy(o => o.id).Skip((PageNumber - 1) * PageSize)
                   .Take(PageSize).ToList<OrderInfo>());

                return (data, numberOfItems);


            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task updateOrderStatus(Session session, Order order, OrderStatus status)
        {
            try
            {
                order.Order_Status = status;
                await session.SaveAsync(order);
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task DeleteOrder(Session session, Order order)
        {
            try
            {
                await session.DeleteAsync(order);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}