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
    public partial class OrderItemPage : System.Web.UI.Page
    {

        private OrderService _orderInstance = OrderService.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Customer)
                {
                    int order_id;
                    if (int.TryParse(Request.QueryString["order_id"], out order_id))
                    {
                        GetData(order_id);

                    }
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

        private async void GetData(int order_id)
        {


            try
            {
                (List<OrderItemInfo> DataBind, OrderStatus status) = await _orderInstance.Get_Customer_Order_Items(order_id);


                await BindData(DataBind, status);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task BindData(List<OrderItemInfo> dataToBind, OrderStatus order_status)
        {

            CustomeComponentContainer.Controls.Clear();
            for (int i = 0; i < dataToBind.Count; i++)
            {
                CartOrderItemCustomeComponent customeComponent = (CartOrderItemCustomeComponent)LoadControl("~/CustomeComponents/CartOrderItemCustomeComponent.ascx");

                var imageUrl = "";
                customeComponent.ID = dataToBind[i].id.ToString();
                customeComponent.Element_ID = dataToBind[i].id;
                customeComponent.TitleText = dataToBind[i].title;
                customeComponent.PriceText = dataToBind[i].price;
                customeComponent.Quntity = dataToBind[i].quantity;
                if (order_status == OrderStatus.rejected)
                {
                    customeComponent.setItemOptionVisability = false;
                    ContainerButtonManageOrder.Visible = false; 
                }
                else
                {
                    customeComponent.ButtonClickAdd += new EventHandler(ButtonClickIncrease);
                    customeComponent.ButtonClickDecrese += new EventHandler(ButtonClickDecrese);
                    customeComponent.ButtonClickRemove += new EventHandler(ButtonClickRemove);
                }
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

        private int _get_item_id(object sender)
        {
            CartOrderItemCustomeComponent customeComponent = (CartOrderItemCustomeComponent)sender;
            int id = customeComponent.Element_ID;
            return id;
        }

        protected async void ButtonClickIncrease(object sender, EventArgs e)
        {
            try
            {

                int id = _get_item_id(sender);

                await _orderInstance.Update_Quantity_Customer_Order_Single_Item(id, "add");
                int order_id;
                if (int.TryParse(Request.QueryString["order_id"], out order_id))
                {
                    GetData(order_id);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }



        protected async void ButtonClickDecrese(object sender, EventArgs e)
        {
            try
            {
                int id = _get_item_id(sender);


                await _orderInstance.Update_Quantity_Customer_Order_Single_Item(id, "sub");
                int order_id;
                if (int.TryParse(Request.QueryString["order_id"], out order_id))
                {
                    GetData(order_id);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }


        protected async void ButtonClickRemove(object sender, EventArgs e)
        {
            try
            {
                int id = _get_item_id(sender);
                await _orderInstance.Remove_Item_From_Order(id);
                int order_id;
                if (int.TryParse(Request.QueryString["order_id"], out order_id))
                {
                    GetData(order_id);

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        protected void ASPxButtonAddItem_Click(object sender, EventArgs e)
        {
            int order_id;
            if (int.TryParse(Request.QueryString["order_id"], out order_id))
            {
                Response.Redirect("~/AddItemIntoOrder.aspx?order_id=" + order_id, false);
            }
        }

        protected async void ASPxButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int order_id;
                if (int.TryParse(Request.QueryString["order_id"], out order_id))
                {
                    await _orderInstance.Delete_User_Order(order_id);
                    Response.Redirect("~/OrdersPage.aspx", false);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/OrdersPage.aspx", false);
        }
    }
}