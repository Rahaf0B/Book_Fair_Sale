using BookFair.Models;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Pdf.Native.BouncyCastle.Asn1.Pkcs;
using System.Text;
using BookFair.Enums;
using System.Threading.Tasks;
using DevExpress.DataProcessing;
using BookFair.Controllers;
using DevExpress.Map.Native;
using BookFair.Services;

namespace BookFair
{

    public partial class Register : System.Web.UI.Page
    {
        private UserService _userService = UserService.getInstance();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected async void FL_B_Reg_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {

                await CreateUser(TB_first_name_register.Text, TB_last_name_register.Text, TB_email_register.Text, TB_pass_register.Text);
            }

        }

        private async Task CreateUser(string first_name, string last_name, string email, string password)
        {
            try
            {

                await _userService.Register_Customer(first_name, last_name, email, password);
                Response.Redirect("~/Login.aspx");
            }
            catch (DevExpress.Xpo.DB.Exceptions.ConstraintViolationException)
            {

                TB_email_register.IsValid = false;
                TB_email_register.ErrorText = "Email is used";


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

        }
    }
}