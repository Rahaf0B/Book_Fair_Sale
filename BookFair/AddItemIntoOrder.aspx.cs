using BookFair.Classes;
using BookFair.Controllers;
using BookFair.CustomeComponents;
using BookFair.Enums;
using BookFair.Models;
using BookFair.Serializable;
using BookFair.Services;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class AddItemIntoOrder : System.Web.UI.Page
    {
        BookService _bookInstance = BookService.getInstance();
        OrderService _orderInsatnce = OrderService.getInstance();
        private int _pageSize = 6;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Customer)
                {
                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = false;
                    FooterPagerContainer.Visible = false;
                    string SearchValue = ViewState["SearchValue"]?.ToString();
                    if (!IsPostBack)
                    {
                        GetData(0, SearchValue);

                    }
                    else
                    {
                        if (ViewState["BookData"] != null && ViewState["NumberOfItems"] != null && ViewState["PageNumber"] != null)
                        {
                            BindGrid((List<BookInfo>)ViewState["BookData"], (int)ViewState["NumberOfItems"], (int)ViewState["PageNumber"]);
                        }
                        else
                        {
                            GetData(0, SearchValue);

                        }
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









        private async void GetData(int pageNumber, string searchValue)
        {
            try
            {

                if (searchValue?.ToString() != string.Empty && searchValue != null && pageNumber != 0)
                {

                    var (dataToBind, numberOfItems) = await _bookInstance.Get_Books_Info_By_Title(pageNumber, _pageSize, searchValue);
                    BindGrid(dataToBind, numberOfItems, pageNumber);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
        private async void BindGrid(List<BookInfo> dataToBind, int numberOfItems, int pageNumber)
        {
            try
            {


                ViewState.Add("BookData", dataToBind);
                ViewState.Add("PageNumber", pageNumber);
                ViewState.Add("NumberOfItems", numberOfItems);


                ElementPanelContainer.Controls.Clear();
                for (int i = 0; i < dataToBind.Count; i++)
                {

                    CustomeCardView customeViewCard = (CustomeCardView)LoadControl("~/CustomeComponents/CustomeCardView.ascx");

                    var imageUrl = "";
                    customeViewCard.ID = dataToBind[i].id.ToString();
                    customeViewCard.Element_ID = dataToBind[i].id;
                    customeViewCard.TitleText = dataToBind[i].title;
                    customeViewCard.SubjectText = dataToBind[i].subject;
                    customeViewCard.AuthorText = dataToBind[i].author;
                    customeViewCard.PriceText = dataToBind[i].price;
                    customeViewCard.OptionText = "Add To Order";
                    customeViewCard.ButtonClick += new EventHandler(btnAddToOrder_Click);

                    bool validImage = await UrlChecker.IsValidUrl(dataToBind[i].image);

                    if (dataToBind[i].image != string.Empty && validImage)
                    {
                        imageUrl = dataToBind[i].image;
                    }
                    else
                    {
                        imageUrl = ResolveUrl("~/utlis/Images/BookImageNotFound.svg");
                    }
                    customeViewCard.Image_Url = imageUrl;


                    ElementPanelContainer.Controls.Add(customeViewCard);

                }


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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }


        }


        protected async void btnAddToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                CustomeCardView customeViewCard = (CustomeCardView)sender;
                int book_id = customeViewCard.Element_ID;
                int order_id;
                if (int.TryParse(Request.QueryString["order_id"], out order_id))
                {

                    (bool status, string statusText) = await _orderInsatnce.Add_Item_To_Order(book_id, order_id);
                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                    ASPxPopupControl1.Windows.Single().Text = statusText;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected async void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (SearchTextInput.Text == "" || SearchTextInput.Text == string.Empty || SearchTextInput.Text.Trim().Length == 0)
                {
                    ElementPanelContainer.Controls.Clear();
                    ViewState.Add("SearchValue", null);

                }
                else
                {
                    ViewState.Add("SearchValue", SearchTextInput.Text);
                    GetData(1, SearchTextInput.Text);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void btnPagerPrev_Click(object sender, EventArgs e)
        {
            string SearchValue = ViewState["SearchValue"]?.ToString();
            int pageNumber = (int)ViewState["PageNumber"];

            if (pageNumber != 1)
            {

                GetData(pageNumber - 1, SearchValue);
            }
        }

        protected void btnPagerNext_Click(object sender, EventArgs e)
        {
            string SearchValue = ViewState["SearchValue"]?.ToString();
            int pageNumber = (int)ViewState["PageNumber"];

            GetData(pageNumber + 1, SearchValue);
        }

        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            int order_id;
            if (int.TryParse(Request.QueryString["order_id"], out order_id))
            {
                Response.Redirect("~/OrderItemPage.aspx?order_id=" + order_id, false);
            }
        }
    }
}