using DevExpress.XtraScheduler.iCalendar.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair.CustomeComponents
{
    public partial class CustomeCardView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public int Element_ID
        {
            get => (int)ASPxHiddenFieldId["ID"];
            set
            {
                ASPxHiddenFieldId["ID"] = value;
            }
        }


        public string Image_Url
        {
            set
            {
                ASPxElementImage.ImageUrl = value;
            }

        }
        public string TitleText
        {
            get => ASPxElementLabelTitle.Text;
            set
            {
                ASPxElementLabelTitle.Text = value;
            }
        }

        public string SubjectText
        {
            get => ASPxElementLabelSubject.Text;
            set
            {
                ASPxElementLabelSubject.Text = value;
            }

        }

        public string AuthorText
        {
            get => ASPxElementLabelAuthor.Text;
            set
            {
                ASPxElementLabelAuthor.Text = value;

            }
        }

        public decimal PriceText
        {

            get => decimal.Parse(ASPxElementLabelPrice.Text);
            set
            {
                ASPxElementLabelPrice.Text = value.ToString();

            }
        }
        public string OptionText
        {
            set
            {
                ASPxButtonOption.Text = value;
            }
        }

        public event EventHandler ButtonClick;

        protected void CustomControl_ButtonClick(object sender, EventArgs e)
        {

            if (ButtonClick != null)
            {
                ButtonClick(this, EventArgs.Empty);
            }

        }


    }
}