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
    public partial class IMRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string orderid = Request.QueryString["orderid"];                
                if (orderid != null)
                {
                    int id = Convert.ToInt32(orderid); 
                    var _db = new InstructionalMaterials.Models.ProductContext();
                    var query = from o in _db.OrderDetails
                                where o.OrderId == id
                                from p in _db.Products
                                where o.ProductId == p.ProductID
                                select new { 
                                    p.AllotmentType,
                                    p.MLC,
                                    p.Publisher,
                                    p.ProductName,
                                    p.ISBN,
                                    p.Language,
                                    p.SubjectArea,
                                    p.CourseName,
                                    p.MaterialType,
                                    p.GradeLevel,
                                    o.Quantity,
                                    p.CopyrightYear,
                                    p.MediaFormat,
                                    p.TEKS,
                                    o.UnitPrice                                    
                                };

                    GridView1.DataSource = query.ToList();
                    GridView1.DataBind();

                }
               
            }
            
        }

    }
}