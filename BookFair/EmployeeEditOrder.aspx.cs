using BookFair.Classes;
using BookFair.Controllers;
using BookFair.CustomeComponents;
using BookFair.Enums;
using BookFair.Models;
using BookFair.Serializable;
using BookFair.Services;
using DevExpress.Web;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class EmployeeEditOrder : System.Web.UI.Page
    {

        private OrderService _orderInstance = OrderService.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Employee)
                {
                    if (!IsPostBack)
                    {
                        ASPxComboBoxOrderStatus.DataSource = Enum.GetValues(typeof(OrderStatus)).Cast<OrderStatus>().ToList();
                        ASPxComboBoxOrderStatus.DataBind();
                        ListEditItem defultItem = new ListEditItem("Select Status", "-1");
                        ASPxComboBoxOrderStatus.Items.Insert(0, defultItem);

                        ASPxComboBoxOrderStatus.SelectedItem = defultItem;
                    }



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
                int order_id;
                if (int.TryParse(Request.QueryString["order_id"], out order_id))
                {
                    OrderInfo order = await _orderInstance.Get_Single_Order_With_Customer_Info(order_id);

                    ASPxHiddenFieldId["ID"] = order.id;

                    ASPxLabelCustomerName.Text = "Customer Name : " + order.customer_name;
                    ASPxLabelOrderNumber.Text = "Order Number : " + order.id;
                    ASPxLabelOrderStatus.Text = "Order Status : " + order.status;
                    ASPxLabelOrderDate.Text = "Order Date : " + order.date;
                    (List<OrderItemInfo> orderItems, OrderStatus status) = await _orderInstance.Get_Customer_Order_Items(order.id);
                    await BindData(orderItems);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task BindData(List<OrderItemInfo> dataToBind)
        {
            var OrderType = OrderStatus.pending;
            for (int i = 0; i < dataToBind.Count; i++)
            {
                CartOrderItemCustomeComponent customeComponent = (CartOrderItemCustomeComponent)LoadControl("~/CustomeComponents/CartOrderItemCustomeComponent.ascx");

                var imageUrl = "";
                customeComponent.ID = dataToBind[i].id.ToString();
                customeComponent.Element_ID = dataToBind[i].id;
                customeComponent.TitleText = dataToBind[i].title;
                customeComponent.PriceText = dataToBind[i].price;
                customeComponent.Quntity = dataToBind[i].quantity;
                customeComponent.setItemOptionVisability = false;

                bool validImage = await UrlChecker.IsValidUrl(dataToBind[i].image);

                if (dataToBind[i].image != string.Empty && validImage)
                {
                    imageUrl = dataToBind[i].image;
                }
                else
                {
                    imageUrl = ResolveUrl("~/utlis/Images/BookImageNotFound.svg");
                }
                customeComponent.Image_Url = imageUrl;


                CustomeComponentContainer.Controls.Add(customeComponent);

            }
        }

        protected async void ASPxButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ASPxComboBoxOrderStatus.SelectedItem.Value.ToString() != "-1")
                {

                    OrderStatus newStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), ASPxComboBoxOrderStatus.SelectedItem.Text.ToString());
                    int order_id = (int)ASPxHiddenFieldId["ID"];
                    await _orderInstance.Update_Order_Status(order_id, newStatus);
                    ASPxLabelOrderStatus.Text = "Order Status : " + newStatus.ToString();

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/OrdersManagement.aspx", false);
        }


    }
}