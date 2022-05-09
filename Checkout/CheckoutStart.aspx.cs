using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstructionalMaterials.Models;
using InstructionalMaterials.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

namespace InstructionalMaterials.Checkout
{
    public partial class CheckoutStart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.InnerText = "Shopping Cart is Empty";

                }
            }
        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartActions actions = new ShoppingCartActions();
            return actions.GetCartItems();
        }

        public IQueryable GetCampuses()
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            IQueryable query = _db.Campuses;
            return query;
        }

        protected void SubmitOrder_Click(object sender, EventArgs e)
        {
            string firstname = FirstName.Text;
            string lastname = LastName.Text;
            string email = Email.Text;
            string phone = Phone.Text;
            int campusid = Convert.ToInt32(Campus.SelectedValue);  //Int32.Parse(Campus.SelectedValue);            
            string campusname = Convert.ToString(Campus.SelectedItem);
            string address = Address.Text;
            string city = City.Text;
            string state = State.Text;
            int zip = Int32.Parse(Zip.Text);

            Session["firstname"] = firstname;
            Session["lastname"] = lastname;
            Session["email"] = email;
            Session["phone"] = phone;
            Session["campusid"] = campusid;
            Session["campusname"] = campusname;
            Session["address"] = address;
            Session["city"] = city;
            Session["state"] = state;
            Session["zip"] = zip;

            Session["userSubmittedOrder"] = "true";

            Response.Redirect("/Checkout/CheckoutReview.aspx");
        }
    }
}