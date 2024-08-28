using BookFair.Controllers;
using BookFair.Enums;
using BookFair.Models;
using BookFair.Serializable;
using BookFair.Services;
using DevExpress.DashboardWeb.Native;
using DevExpress.Utils.About;
using DevExpress.Web;
using DevExpress.Web.Internal;
using DevExpress.Xpo;
using DevExpress.XtraExport.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class OrdersManagement : System.Web.UI.Page
    {

        private OrderService _orderInstance = OrderService.getInstance();
        private int _pageSize = 6;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Employee)
                {
                    if (ViewState["PageNumber"] != null)
                    {
                        GetData((int)ViewState["PageNumber"]);
                    }
                    else
                    {
                        GetData(1);
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



        private async void GetData(int pageNumber)
        {
            try
            {
                (List<OrderInfo> Info, int NumberOfItems) = await _orderInstance.Get_All_Customers_Orders(pageNumber, _pageSize);
                BindData(Info, pageNumber, NumberOfItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BindData(List<OrderInfo> dataToBind, int pageNumber, int numberOfItems)
        {

            ViewState.Add("OrderData", dataToBind);
            ViewState.Add("PageNumber", pageNumber);
            ViewState.Add("NumberOfItems", numberOfItems);

            ASPxGridViewOrderData.DataSource = dataToBind;
            ASPxGridViewOrderData.DataBind();

            if (dataToBind.Count != 0)
            {
                decimal NumberOfPages = Math.Ceiling((decimal)((decimal)numberOfItems / (decimal)_pageSize));

                FooterPagerContainer.Visible = true;
                labelPageFooter.Text = $"Page {pageNumber} of {(int)NumberOfPages}";
                labelPagerNumber.Text = pageNumber.ToString();
                btnPagerPrev.Visible = pageNumber != 1;
                btnPagerNext.Visible = (int)NumberOfPages != pageNumber;

            }
            else
            {
                FooterPagerContainer.Visible = false;

            }
        }



        protected void btnPagerPrev_Click(object sender, EventArgs e)
        {
            int pageNumber = (int)ViewState["PageNumber"];
            if (pageNumber != 1)
            {
                GetData(pageNumber - 1);
            }
        }

        protected void btnPagerNext_Click(object sender, EventArgs e)
        {
            int pageNumber = (int)ViewState["PageNumber"];
            GetData(pageNumber + 1);
        }

        protected void GridView1_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {

            if (e?.CommandArgs?.CommandName == "Details")
            {

                Response.Redirect("~/EmployeeEditOrder.aspx?order_id=" + e?.KeyValue, false);
            }


        }


        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx", false);
        }

    }
}