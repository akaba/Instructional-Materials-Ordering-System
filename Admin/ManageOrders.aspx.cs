using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstructionalMaterials.Models;
using System.Web.ModelBinding;

namespace InstructionalMaterials.Admin
{
    public partial class ManageOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<Order> GetOrders()
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            IQueryable<Order> query = _db.Orders;
            return query;
        }

        protected string GetStatus(int status)
        {
            if (status == 0) return "Submitted-Under Review";
            else if (status == 1) return "Incomplete-Please Resubmit";
            else if (status == 2) return "Submitted to EMAT";
            else if (status == 3) return "Received";
            else return null;
        }

        protected string GetCampusName(int ID)
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            return _db.Campuses.Where(f => (f.CampusID == ID)).Select(f => f.CampusName).SingleOrDefault();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)           
        {
            if (e.CommandName.Equals("UpdateStatus"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];           
                DropDownList DDlist= (DropDownList)row.FindControl("statusDD");
                Label lblorderid = (Label)row.FindControl("LabelOrderID");         
                int orderid = Convert.ToInt32(lblorderid.Text);
                        var _db = new InstructionalMaterials.Models.ProductContext();
                        Order o = (from x in _db.Orders
                                   where x.OrderId == orderid
                                   select x).First();
                        o.Status = Convert.ToByte(DDlist.SelectedValue);
                        _db.SaveChanges();
                        GridView1.EditIndex = -1;
            }      
              
        }
       
        
    }
}