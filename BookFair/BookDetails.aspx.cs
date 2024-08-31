using BookFair.Classes;
using BookFair.Enums;
using BookFair.Serializable;
using BookFair.Services;
using DevExpress.Charts.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class BookDetails : System.Web.UI.Page
    {
        private BookService _bookInstance = BookService.getInstance();
        private CartService _cartInstance = CartService.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {

                ASPxPopupControl1.Windows.Single().ShowOnPageLoad = false;


                int book_id;
                if (Request.QueryString["book_id"] != null && int.TryParse(Request.QueryString["book_id"], out book_id))
                {
                    if (Session["user_id"] != null)
                    {

                        if (Session["user_role"] != null)
                        {
                            UserRole UserRole = (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true);
                            if (UserRole == UserRole.Customer)
                            {
                                ASPxButtonDelete.Visible = false;
                                ASPxButtonEdit.Visible = false;
                                ASPxLabelinfoQ.Visible = false;
                                ASPxInfQuantity.Visible = false;
                            }
                            else if (UserRole == UserRole.Employee)
                            {
                                ASPxButtonAddToCart.Visible = false;

                            }

                        }
                        GetData(book_id);

                    }
                }
                else
                {
                    ASPxPanelContentContainer.Visible = false;
                }


            }
            else
            {
                Response.Redirect("~/Login.aspx", false);

            }
        }
        private async void GetData(int book_id)
        {

            try
            {
                BookInfo book = await _bookInstance.Get_Book_By_ID(book_id);
                if (book != null)
                {
                    ASPxInfoTitle.Text = book.title;

                    ASPxInfoSubject.Text = book.subject;
                    ASPxInfoDescription.Text = book.description;
                    ASPxInfoAuthor.Text = book.author;
                    ASPxInfPrice.Text = book.price.ToString();
                    ASPxInfQuantity.Text = book.quantity.ToString();
                    ASPxHiddenFieldID["ID"] = book.id;


                    bool validImage = await UrlChecker.IsValidUrl(book.image);
                    string imageUrl = null;
                    if (book.image != string.Empty && validImage)
                    {
                        imageUrl = book.image;
                    }
                    else
                    {
                        imageUrl = ResolveUrl("~/utlis/Images/BookImageNotFound.svg");
                    }
                    ASPxImageItem.ImageUrl = imageUrl;
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx", false);
        }

        protected async void ASPxButtonAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                await AddToCart((int)Session["user_id"], (int)ASPxHiddenFieldID["ID"]);
            }
            catch (Exception ex)
            {
                throw;
            }
        }





        private async Task AddToCart(int user_id, int book_id)
        {


            try
            {

                (bool status, string status_text) = await _cartInstance.Add_To_Cart(user_id, book_id);

                ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                ASPxPopupControl1.Windows.Single().Text = status_text;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }
        }

        protected void ASPxButtonEdit_Click(object sender, EventArgs e)
        {
            int id = (int)ASPxHiddenFieldID["ID"];
            Response.Redirect("~/EditBook.aspx?book_id=" + id, false);



        }

        protected async void ASPxButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)ASPxHiddenFieldID["ID"];
                string status_text = "";
                bool status = await _bookInstance.Delete_Book(id);
                if (status)
                {
                    status_text = "The Book Has Been Deleted";
                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                    ASPxPopupControl1.Windows.Single().Text = status_text;
                    Response.Redirect("~/HomePage.aspx");
                }
                else
                {
                    status_text = "There Is An Error Occurred";
                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                    ASPxPopupControl1.Windows.Single().Text = status_text;
                }

               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }
}