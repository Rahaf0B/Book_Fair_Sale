using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Google.Apis.Auth.OAuth2;
using System.Threading;
using DevExpress.XtraPrinting.Export;

using System.Threading.Tasks;

using BookFair.Services;

namespace BookFair
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        private UserService _userService = UserService.getInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxLabelError.Visible = false;

        }

        protected async void ASPxButtonSendEmail_Click(object sender, EventArgs e)
        {

            if (IsValid)
            {
                await SendOTPCode(ASPxInputEmail.Text);
            }

        }

        private async Task SendOTPCode(string email)
        {
            try
            {
                bool emailStatus = await _userService.Send_OTP_Code(email);
                if (emailStatus)
                {
                    string encodedEmail = Server.UrlEncode(email);
                    Response.Redirect("~/CheckOTPCode.aspx?email=" + encodedEmail);

                    ASPxLabelError.Visible = false;

                }
                else
                {
                    ASPxLabelError.Visible = true;

                }

            }
            catch (Exception ex) { throw; }
        }

        protected void Goback_ButtonClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx", true);
        }


    }
}