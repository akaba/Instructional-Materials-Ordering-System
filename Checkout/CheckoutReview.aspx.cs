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
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace InstructionalMaterials.Checkout
{
  public partial class CheckoutReview : System.Web.UI.Page
  {
      
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {

            //  Prevent duplicate order via browser goback button
            if ((string)Session["userCheckoutCompleted"] == "true")
            {
                Response.Redirect("~/Default.aspx");              
            }

            //  Prevent viewing this page before the CheckoutStart.aspx
            if ((string)Session["userSubmittedOrder"] != "true")
            {
                Session["userSubmittedOrder"] = string.Empty;
                Response.Redirect("/Checkout/CheckoutStart.aspx");
            }




            // Get the shopping cart items and process them.
            using (InstructionalMaterials.Logic.ShoppingCartActions usersShoppingCart = new InstructionalMaterials.Logic.ShoppingCartActions())
            {
                List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

                // Display OrderDetails.
                OrderItemList.DataSource = myOrderList;
                OrderItemList.DataBind();


                var myOrder = new Order();
                myOrder.OrderDate = DateTime.Now;
                myOrder.Username = User.Identity.Name;
                myOrder.FirstName = (Session["firstname"]).ToString();
                myOrder.LastName = (Session["lastname"]).ToString();
                myOrder.Email = (Session["email"]).ToString();
                myOrder.Phone = (Session["phone"]).ToString();
                myOrder.CampusID = Convert.ToInt32(Session["campusid"]);
                myOrder.Address = (Session["address"]).ToString();
                myOrder.City = (Session["city"]).ToString();
                myOrder.State = (Session["state"]).ToString();
                myOrder.ZipCode = (Session["zip"]).ToString();
                myOrder.Total = Convert.ToDecimal(Session["payment_amt"]);
                myOrder.Status = 0;

                // Display Order information.
                List<Order> orderList = new List<Order>();
                orderList.Add(myOrder);
                ShipInfo.DataSource = orderList;
                ShipInfo.DataBind();

            }



        }// if !IsPostBack       
       
    }

  

   

    protected void CheckoutConfirm_Click(object sender, EventArgs e)
    {


        var myOrder = new Order();
        myOrder.OrderDate = DateTime.Now;
        myOrder.Username = User.Identity.Name;
        myOrder.FirstName = (Session["firstname"]).ToString();
        myOrder.LastName = (Session["lastname"]).ToString();
        myOrder.Email = (Session["email"]).ToString();
        myOrder.Phone = (Session["phone"]).ToString();
        myOrder.CampusID = Convert.ToInt32(Session["campusid"]);
        myOrder.Address = (Session["address"]).ToString();
        myOrder.City = (Session["city"]).ToString();
        myOrder.State = (Session["state"]).ToString();
        myOrder.ZipCode = (Session["zip"]).ToString();
        myOrder.Total = Convert.ToDecimal(Session["payment_amt"]);
        myOrder.Status = 0;

        try
        {
           // Get DB context.
          ProductContext _db = new ProductContext();

          // Add order to DB.
          _db.Orders.Add(myOrder);
          _db.SaveChanges(); 
          
          
           // Get the shopping cart items and process them.
          using (InstructionalMaterials.Logic.ShoppingCartActions usersShoppingCart = new InstructionalMaterials.Logic.ShoppingCartActions())
          {
              List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

              // Add OrderDetail information to the DB for each product purchased.
              for (int i = 0; i < myOrderList.Count; i++)
              {
                  // Create a new OrderDetail object.
                  var myOrderDetail = new OrderDetail();
                  myOrderDetail.OrderId = myOrder.OrderId;
                  myOrderDetail.Username = User.Identity.Name;
                  myOrderDetail.ProductId = myOrderList[i].ProductId;
                  myOrderDetail.Quantity = myOrderList[i].Quantity;
                  myOrderDetail.UnitPrice = myOrderList[i].Product.UnitPrice;

                  // Add OrderDetail to DB.
                  _db.OrderDetails.Add(myOrderDetail);
                  _db.SaveChanges();
              }

                  // Set OrderId.
                  Session["currentOrderId"] = myOrder.OrderId;
              
          }

          Session["userCheckoutCompleted"] = "true";
          Response.Redirect("~/Checkout/CheckoutComplete.aspx");


        } // try
        catch (DbEntityValidationException ex)
        {
           LabelMsg.Text = "Order could not added to the database..." + ex.Message;
            // Retrieve the error messages as a list of strings.
           // var errorMessages = ex.EntityValidationErrors
           //         .SelectMany(x => x.ValidationErrors)
           //         .Select(x => x.ErrorMessage);

            // Join the list to a single string.
           // var fullErrorMessage = string.Join("; ", errorMessages);

            // Combine the original exception message with the new one.
            //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

            // Throw a new DbEntityValidationException with the improved exception message.
            //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
        }


     



    }



  }
}
