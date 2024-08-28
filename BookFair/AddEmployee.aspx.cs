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
    public partial class AddEmployee : System.Web.UI.Page
    {
        private UserService _userInstance = UserService.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user_id"] != null)
            {
                if (Session["user_role"] != null && Session["emp_role"] != null && (UserRole)Enum.Parse(typeof(UserRole), Session["user_role"].ToString(), true) == UserRole.Employee && (EmployeeRole)Enum.Parse(typeof(EmployeeRole), Session["emp_role"].ToString(), true) == EmployeeRole.Admin)
                {

                    if (!IsPostBack)
                    {
                        ASPxPopupControl1.Windows.Single().ShowOnPageLoad = false;

                        ASPxFormLayoutEmployeeType.DataSource = Enum.GetValues(typeof(EmployeeRole)).Cast<EmployeeRole>().ToList();
                        ASPxFormLayoutEmployeeType.DataBind();
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

        protected async void ASPxFormLayout1_E16_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid)
                {

                    string firstName = ASPxFormLayoutFirstName.Text;
                    string lastName = ASPxFormLayoutLastName.Text;
                    string email = ASPxFormLayoutEmail.Text;
                    string password = ASPxFormLayoutPassword.Text;
                    decimal salary;
                    decimal.TryParse(ASPxFormLayoutSalary.Text, out salary);
                    EmployeeRole empRole = (EmployeeRole)Enum.Parse(typeof(EmployeeRole), ASPxFormLayoutEmployeeType.SelectedItem.Text.ToString());

                    (bool status, string status_text) = await _userInstance.Add_Employee(firstName, lastName, email, password, empRole, salary);
                    ASPxPopupControl1.Windows.Single().ShowOnPageLoad = true;
                    ASPxPopupControl1.Windows.Single().Text = status_text;


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