using BookFair.Controllers;
using BookFair.Enums;
using BookFair.Models;
using BookFair.Serializable;
using BookFair.Services;
using DevExpress.Web;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class OrdersPage : System.Web.UI.Page
    {
        private OrderService _orderInstance = OrderService.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Customer)
                {
                    GetData();
                }
                else
                {
                    Response.Redirect("~/HomePage.aspx", false);

                }
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);

            }
        }

        private async void GetData()
        {
            try
            {
                int user_id = int.Parse(Session["user_id"].ToString());
                List<OrderInfo> orderInfo = await _orderInstance.Get_User_Orders(user_id);
                BindData(orderInfo);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        private void BindData(List<OrderInfo> dataToBind)
        {
            try
            {
                ASPxGridViewOrderInfo.DataSource = dataToBind;
                ASPxGridViewOrderInfo.DataBind();

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx", false);
        }


        protected void GridView1_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            if (Session["user_id"] != null)
            {
                if (e?.CommandArgs?.CommandName == "Details")
                {

                    Response.Redirect("~/OrderItemPage.aspx?order_id=" + e?.KeyValue, false);

                }
            }


        }
    }
}