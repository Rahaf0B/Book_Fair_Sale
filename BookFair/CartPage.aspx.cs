using BookFair.Interfaces;
using BookFair.Serializable;
using DevExpress.Xpo.DB;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraRichEdit.Model;
using System.Data.SqlClient;
using BookFair.Controllers;
using BookFair.Models;
using BookFair.Classes;
using System.Threading.Tasks;
using BookFair.CustomeComponents;
using BookFair.Enums;
using BookFair.Services;
using DevExpress.XtraScheduler.iCalendar.Components;
namespace BookFair
{
    public partial class CartPage : System.Web.UI.Page
    {

        CartService _cartInstance = CartService.getInstance();
        OrderService _orderInstance = OrderService.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Customer)
                {
                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = false;
                    GetInitData();
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

        private async void GetInitData()
        {
            try
            {
                int user_id = int.Parse(Session["user_id"].ToString());
                List<CartInfo> data = await _cartInstance.Get_Cart_Element(user_id);
                BindData(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }


        private async void BindData(List<CartInfo> dataToBind)
        {
            PanleCustomeContainer.Controls.Clear();

            for (int i = 0; i < dataToBind.Count; i++)
            {
                CartOrderItemCustomeComponent customeComponent = (CartOrderItemCustomeComponent)LoadControl("~/CustomeComponents/CartOrderItemCustomeComponent.ascx");

                var imageUrl = "";
                customeComponent.ID = dataToBind[i].id.ToString();
                customeComponent.Element_ID = dataToBind[i].id;
                customeComponent.TitleText = dataToBind[i].title;
                customeComponent.PriceText = dataToBind[i].price;
                customeComponent.Quntity = dataToBind[i].quantity;
                customeComponent.ButtonClickAdd += new EventHandler(ButtonClickIncrease);
                customeComponent.ButtonClickDecrese += new EventHandler(ButtonClickDecrese);
                customeComponent.ButtonClickRemove += new EventHandler(ButtonClickRemove);
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


                PanleCustomeContainer.Controls.Add(customeComponent);
            }
        }




        protected async void ButtonClickIncrease(object sender, EventArgs e)
        {
            try
            {
                CartOrderItemCustomeComponent customControl = (CartOrderItemCustomeComponent)sender;

                int user_id = int.Parse(Session["user_id"].ToString());
                bool status = await _cartInstance.Change_Item_Quntity(user_id, customControl.Element_ID, "increase");



                if (!status)
                {

                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                    ASPxPopupControl1.Windows.Single().Text = "The Book is sold out or there is not enough copies copies";
                }
                else
                {
                    customControl.Quntity = customControl.Quntity + 1;
                    GetInitData();

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
                CartOrderItemCustomeComponent customControl = (CartOrderItemCustomeComponent)sender;

                int user_id = int.Parse(Session["user_id"].ToString());
                bool status = await _cartInstance.Change_Item_Quntity(user_id, customControl.Element_ID, "decrese");

                if (customControl.Quntity != 1)
                {

                    if (!status)
                    {

                        ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                        ASPxPopupControl1.Windows.Single().Text = "The Book is sold out or there is not enough copies copies";
                    }
                    else
                    {
                        customControl.Quntity = customControl.Quntity - 1;

                        GetInitData();

                    }
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
                CartOrderItemCustomeComponent customControl = (CartOrderItemCustomeComponent)sender;

                int user_id = int.Parse(Session["user_id"].ToString());
                await _cartInstance.Remove_Item(user_id, customControl.Element_ID);
                GetInitData();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }


        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx", false);
        }

        protected async void ASPxButtonMakeOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int user_id = int.Parse(Session["user_id"].ToString());

                await _orderInstance.Craete_Order(user_id);
                GetInitData();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }
    }
}