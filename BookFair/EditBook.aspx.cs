using BookFair.Classes;
using BookFair.Enums;
using BookFair.Interfaces;
using BookFair.Models;
using BookFair.Serializable;
using BookFair.Services;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair
{
    public partial class EditBook : System.Web.UI.Page
    {
        private BookService _bookInstance = BookService.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxPopupControl1.Windows.Single().ShowOnPageLoad = false;
            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Employee)
                {

                    int book_id;
                    if (Request.QueryString["book_id"] != null && int.TryParse(Request.QueryString["book_id"], out book_id))
                    {
                        if (Session["user_id"] != null)
                        {

                            if (Session["user_role"] != null)
                            {
                                UserRole UserRole = (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true);
                                if (UserRole == UserRole.Employee)
                                {
                                    BindSubjectData();
                                    BindAuthorData();

                                    GetData(book_id);


                                }

                            }

                        }
                    }
                    else
                    {
                        ASPxPanelContentContainer.Visible = false;
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

        private async void GetData(int book_id)
        {

            try
            {
                BookInfo book = await _bookInstance.Get_Book_By_ID(book_id);
                if (book != null)
                {
                    ASPxFormLayoutTitle.NullText = book.title;
                    ASPxFormLayoutDescription.NullText = book.description;
                    ASPxFormLayoutPrice.NullText = book.price.ToString();
                    ASPxFormLayoutQuantity.NullText = book.quantity.ToString();
                    ASPxFormLayoutPublisher.NullText = book.publisher;
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


        private async void BindSubjectData()
        {
            try
            {

                List<Subject> subjects = await _bookInstance.Get_Subjects();
                ASPxFormLayoutSubject.DataSource = subjects;
                ASPxFormLayoutSubject.TextField = "title";
                ASPxFormLayoutSubject.ValueField = "subject_id";
                ASPxFormLayoutSubject.DataBind();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private async void BindAuthorData()
        {
            try
            {

                List<Author> authors = await _bookInstance.Get_Authors();

                ASPxFormLayoutAuthor.DataSource = authors;
                ASPxFormLayoutAuthor.TextField = "name";
                ASPxFormLayoutAuthor.ValueField = "author_id";
                ASPxFormLayoutAuthor.DataBind();


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


        protected async void ASPxFormLayout1_E16_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {
                    int author = 0;
                    int subject = 0;
                    string image_url = null;

                    if (ASPxFormLayoutUploadImage.UploadedFiles[0] != null)
                    {
                        var file = ASPxFormLayoutUploadImage.UploadedFiles[0].FileBytes;

                        image_url = await ImageUploader.uploadImageUsingByte(file);
                    }

                    string QuantityText = ASPxFormLayoutQuantity.Text != string.Empty ? ASPxFormLayoutQuantity.Text : ASPxFormLayoutQuantity.NullText;
                    string PriceText = ASPxFormLayoutPrice.Text != string.Empty ? ASPxFormLayoutPrice.Text : ASPxFormLayoutPrice.NullText;
                    string authorValue = ASPxFormLayoutAuthor?.SelectedItem?.Value?.ToString() ?? null;
                    string subjectValue = ASPxFormLayoutSubject?.SelectedItem?.Value?.ToString() ?? null;


                    if (subjectValue != null)
                    {
                        subject = int.Parse(subjectValue);

                    }

                    if (authorValue != null)
                    {
                        author = int.Parse(authorValue);

                    }

                    int quantity = int.Parse(QuantityText);

                    decimal price = decimal.Parse(PriceText);

                    string title = ASPxFormLayoutTitle.Text ?? null;


                    string description = ASPxFormLayoutDescription.Text ?? ASPxFormLayoutDescription.NullText;
                    string publisher = ASPxFormLayoutPublisher.Text ?? ASPxFormLayoutPublisher.NullText;
                    int book_id;
                    if (Request.QueryString["book_id"] != null && int.TryParse(Request.QueryString["book_id"], out book_id))
                    {
                        await _bookInstance.Edit_Book(book_id, title, author, subject, price, quantity, image_url, description, publisher);
                        GetData(book_id);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}