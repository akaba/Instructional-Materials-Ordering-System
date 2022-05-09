using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstructionalMaterials.Models;
using System.Web.ModelBinding;

namespace InstructionalMaterials
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["categoryDD"] != null)
                {
                     categoryDD.SelectedIndex = (int)Session["categoryDD"];
                }
            }

        }

        public IQueryable<Category> GetCategories()
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;
            return query;
        } 

        protected void categoryDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["categoryDD"] = categoryDD.SelectedIndex;
            Response.Redirect("/ProductList.aspx?id=" + categoryDD.SelectedValue);
        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }

    }
}