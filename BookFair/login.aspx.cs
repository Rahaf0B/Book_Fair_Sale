using BookFair.Controllers;
using BookFair.Enums;
using BookFair.Models;
using BookFair.Services;
using DevExpress.Data.Filtering;
using DevExpress.DataAccess.Native.Web;
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
    public partial class login : System.Web.UI.Page
    {
        private UserService _userService = UserService.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxLabelError.Visible = false;

        }

        protected async void ASPxFormLayout1_E2_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {

                string password = FL_pass_login.Text;
                string email = FL_email_login.Text;
                try
                {
                    await Check_User(email, password);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }



        private async Task Check_User(string email, string password)
        {
            try
            {

                User user = await _userService.Get_User(email);

                if (user != null && _userService.Check_Password(password, user.Password))
                {


                    Session["user_id"] = user.User_id;
                    Session["user_role"] = user.User_Role.ToString();
                    Session["emp_role"] = null;
                    if (user.User_Role == UserRole.Employee)
                    {
                        EmployeeRole? employeeRole = await _userService.Get_Employee_Role(user.User_id) ?? null;
                        Session["emp_role"] = employeeRole.ToString();
                    }
                    Response.Redirect("~/HomePage.aspx", false);



                }
                else
                {
                    ASPxLabelError.Visible = true;

                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

        }
    }
}