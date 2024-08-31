
using BookFair.Classes;
using BookFair.Controllers;
using BookFair.CustomeComponents;
using BookFair.Enums;
using BookFair.Interfaces;
using BookFair.Models;
using BookFair.Serializable;
using BookFair.Services;
using DevExpress.CodeParser;
using DevExpress.Data.Filtering;
using DevExpress.Web;
using DevExpress.Xpo;
using DevExpress.XtraScheduler.iCalendar.Components;
using MailKit.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using static DevExpress.Drawing.Printing.Internal.DXPageSizeInfo;

namespace BookFair
{

    public partial class HomePage : System.Web.UI.Page
    {

        private int _pageSize = 6;
        private BookService _bookInstance = BookService.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["user_id"] != null)
            {




                if (Session["user_role"] != null)
                {
                    UserRole UserStatus = (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true);
                    if (UserStatus == UserRole.Customer)
                    {
                        ASPxMainMenu.Items.FindByName("AddEmpItem").Visible = false;
                        ASPxMainMenu.Items.FindByName("MangeOrderItem").Visible = false;
                        ASPxMainMenu.Items.FindByName("AddBookItem").Visible = false;

                    }
                    else if (UserStatus == UserRole.Employee)
                    {
                        ASPxMainMenu.Items.FindByName("CartItem").Visible = false;
                        ASPxMainMenu.Items.FindByName("OrderItem").Visible = false;
                        if (Session["emp_role"] != null)
                        {
                            EmployeeRole EmpStatus = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), Session["emp_role"].ToString(), true);

                            if (EmpStatus == EmployeeRole.Other)
                            {
                                ASPxMainMenu.Items.FindByName("AddEmpItem").Visible = false;
                            }
                        }
                        else
                        {
                            Response.Redirect("~/HomePage.aspx", false);

                        }

                    }
                    if (!IsPostBack)
                    {
                        GetInitData(1);
                        BindFilterData();
                    }

                    else
                    {
                        if (ViewState["BookData"] != null && ViewState["NumberOfItems"] != null && ViewState["PageNumber"] != null)
                        {
                            BindGrid((List<BookInfo>)ViewState["BookData"], (int)ViewState["NumberOfItems"], (int)ViewState["PageNumber"]);
                        }

                        else { GetInitData(1); }

                    }
                }
                else
                {
                    Response.Redirect("~/HomePage.aspx", false);

                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }


        private async void BindFilterData()
        {
            try
            {

                List<Subject> Subjects = await _bookInstance.Get_Subjects();

                DropFilter.DataSource = Subjects;
                DropFilter.DataTextField = "title";
                DropFilter.DataValueField = "subject_id";
                DropFilter.DataBind();
                ListItem defultItem = new ListItem("Select a Subject", "-1");
                DropFilter.Items.Insert(0, defultItem);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private async void GetInitData(int pageNumber)
        {
            try
            {
                var (dataToBind, numberOfItems) = await _bookInstance.Get_Books_Info(pageNumber, _pageSize);
                if (dataToBind != null)
                {
                    NoDataLabel.Visible = false;

                    BindGrid(dataToBind, numberOfItems, pageNumber);
                }
                else
                {
                    NoDataLabel.Visible = true;
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

                foreach (var item in dataToBind)
                {

                    CustomeCardView customeViewCard = (CustomeCardView)LoadControl("~/CustomeComponents/CustomeCardView.ascx");

                    var imageUrl = "";
                    customeViewCard.ID = item.id.ToString() ;
                    customeViewCard.Element_ID = item.id;
                    customeViewCard.TitleText = item.title;
                    customeViewCard.SubjectText = item.subject;
                    customeViewCard.OptionText = "View Details";
                    customeViewCard.ButtonClick += new EventHandler(ViewDetailsHandler);


                    bool validImage = await UrlChecker.IsValidUrl(item.image);

                    if (item.image != string.Empty && validImage)
                    {
                        imageUrl = item.image;
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


        protected async void btnPagerPrev_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = ViewState["searchText"]?.ToString() ?? null;
                string filterText = ViewState["filterText"]?.ToString() ?? null;


                int pageNumber = (int)ViewState["PageNumber"];
                if (pageNumber != 1)
                {
                    if (searchText != null && filterText != null)
                    {
                        await _searchAndFilter(searchText, filterText);

                    }
                    else if (searchText != null)
                    {
                        await _search(searchText);

                    }
                    else if (filterText != null)
                    {
                        await _filter(filterText);
                    }
                    else
                    {
                        GetInitData(pageNumber - 1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        protected async void btnPagerNext_Click(object sender, EventArgs e)
        {
            try
            {
                string searchText = ViewState["searchText"]?.ToString() ?? null;
                string filterText = ViewState["filterText"]?.ToString() ?? null;


                int pageNumber = (int)ViewState["PageNumber"];

                if (searchText != null && filterText != null)
                {
                    await _searchAndFilter(searchText, filterText);

                }
                else if (searchText != null)
                {
                    await _search(searchText);

                }
                else if (filterText != null)
                {
                    await _filter(filterText);
                }
                else
                {
                    Response.Write(pageNumber);

                    GetInitData(pageNumber + 1);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }




        protected void ViewDetailsHandler(object sender, EventArgs e)
        {
            try
            {
             

                CustomeCardView customControl = (CustomeCardView)sender;
                Response.Redirect("~/BookDetails.aspx?book_id=" + customControl.Element_ID, false);

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
                if (SearchTextInput.Text == "")
                {
                    ViewState.Add("searchText", null);

                    GetInitData(1);
                }
                else
                {
                    ViewState.Add("searchText", SearchTextInput.Text);
                    DropFilter.SelectedIndex = 0;
                    ViewState.Add("filterText", null);

                    await _search(SearchTextInput.Text);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }




        protected async void DropFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropFilter.SelectedItem.Value == "-1")
            {
                GetInitData(1);
            }
            else
            {
                ViewState.Add("filterText", DropFilter.SelectedItem.Text);

                string searchText = ViewState["searchText"]?.ToString() ?? null;

                if (searchText != null)
                {
                    await _searchAndFilter(searchText, DropFilter.SelectedItem.Text);
                }
                else
                {
                    await _filter(DropFilter.SelectedItem.Text);
                }
            }

        }

        private async Task _search(string title)
        {
            try
            {

                if (title != null)
                {
                    var (dataToBind, numberOfItems) = await _bookInstance.Get_Books_Info_By_Title(1, _pageSize, title);

                    BindGrid(dataToBind, numberOfItems, 1);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task _filter(string subject)
        {
            try
            {
                if (subject != null)
                {
                    var (dataToBind, numberOfItems) = await _bookInstance.Get_Books_Info_By_Subject(1, _pageSize, subject);

                    BindGrid(dataToBind, numberOfItems, 1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private async Task _searchAndFilter(string title, string subject)
        {
            try
            {

                if (title != null && subject != null)
                {
                    var (dataToBind, numberOfItems) = await _bookInstance.Get_Books_Info_By_Title_And_Subject(1, _pageSize, title, subject);


                    BindGrid(dataToBind, numberOfItems, 1);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        protected void UserMenuItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Name == "SignOutItem")
            {
                Session["user_id"] = null;
                Session["user_role"] = null;
                Session["emp_role"] = null;
                Response.Redirect("~/Login.aspx", false);
            }
        }

    }
}




