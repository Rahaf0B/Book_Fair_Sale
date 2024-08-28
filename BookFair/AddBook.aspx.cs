using BookFair.Classes;
using BookFair.Controllers;
using BookFair.Enums;
using BookFair.Models;
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
    public partial class AddBook : System.Web.UI.Page
    {
        BookService _bookInstance = BookService.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Employee)
                {
                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = false;

                    BindSubjectData();
                    BindAuthorData();
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
                throw;
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
                throw;
            }
        }




        protected async void ASPxFormLayout1_E16_Click(object sender, EventArgs e)
        {
            try
            {
                string image_url = null;
                if (ASPxFormLayoutUploadImage.UploadedFiles[0] != null)
                {
                    var file = ASPxFormLayoutUploadImage.UploadedFiles[0].FileBytes;

                    image_url = await ImageUploader.uploadImageUsingByte(file);
                }
                if (IsValid)
                {
                    int author;
                    int subject;
                    decimal price;
                    int quantity;

                    if (int.TryParse(ASPxFormLayoutQuantity.Text, out quantity) && decimal.TryParse(ASPxFormLayoutPrice.Text, out price) && int.TryParse(ASPxFormLayoutAuthor.SelectedItem.Value.ToString(), out author) && int.TryParse(ASPxFormLayoutSubject.SelectedItem.Value.ToString(), out subject))
                    {

                        string title = ASPxFormLayoutTitle.Text;
                        string description = ASPxFormLayoutDescription.Text ?? null;
                        string publisher = ASPxFormLayoutPublisher.Text;
                        (bool status, string status_text) = await _bookInstance.Add_Book(title, subject, author, price, quantity, publisher, description, image_url);


                        ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                        ASPxPopupControl1.Windows.Single().Text = status_text;
                    }
                }

            }
            catch (Exception ex)
            {

                ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                ASPxPopupControl1.Windows.Single().Text = "Error Occurred";
            }
        }

        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/HomePage.aspx", false);
        }
    }
}