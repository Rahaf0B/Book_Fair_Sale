using DevExpress.CodeParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookFair.CustomeComponents
{
    public partial class CartOrderItemCustomeComponent : System.Web.UI.UserControl
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


        public decimal PriceText
        {

            get => decimal.Parse(ASPxElementLabelPrice.Text);
            set
            {
                ASPxElementLabelPrice.Text = value.ToString();

            }
        }

        public int Quntity
        {
            get => int.Parse(ASPxTextBoxItemNumber.Text);
            set
            {
                ASPxTextBoxItemNumber.Text = value.ToString();
            }
        }

        public bool setQuantityOptionVisability
        {
            set
            {
                QuantityOptionContainer.Visible = value;

            }
        }

        public bool setRemoveBtnVisabilty
        {
            set
            {
                ASPxButtonRemove.Visible = value;
            }
        }

        public bool setItemOptionVisability
        {
            set
            {
                ItemOptionsContainer.Visible = value;
            }
        }
        public event EventHandler ButtonClickAdd;
        public event EventHandler ButtonClickDecrese;
        public event EventHandler ButtonClickRemove;
        protected void CustomControlAdd_ButtonClick(object sender, EventArgs e)
        {

            if (ButtonClickAdd != null)
            {
                ButtonClickAdd(this, EventArgs.Empty);
            }

        }

        protected void CustomControlDecrease_ButtonClick(object sender, EventArgs e)
        {

            if (ButtonClickDecrese != null)
            {
                ButtonClickDecrese(this, EventArgs.Empty);
            }

        }

        protected void CustomControlRemove_ButtonClick(object sender, EventArgs e)
        {

            if (ButtonClickRemove != null)
            {
                ButtonClickRemove(this, EventArgs.Empty);
            }

        }
    }
}