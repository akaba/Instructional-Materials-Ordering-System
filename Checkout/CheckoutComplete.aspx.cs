using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstructionalMaterials.Models;
using InstructionalMaterials.Logic;

namespace InstructionalMaterials.Checkout
{
    public partial class CheckoutComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verify user has completed the checkout process.
                if ((string)Session["userCheckoutCompleted"] != "true")
                {
                    Session["userCheckoutCompleted"] = string.Empty;
                   // Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
                }

                OrderID.Text = Session["currentOrderId"].ToString();

                // Clear shopping cart.
                using (InstructionalMaterials.Logic.ShoppingCartActions usersShoppingCart =
                    new InstructionalMaterials.Logic.ShoppingCartActions())
                {
                    usersShoppingCart.EmptyCart();
                }

                // Clear order id.
                Session["currentOrderId"] = string.Empty;

            }
        }




        protected void Continue_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}