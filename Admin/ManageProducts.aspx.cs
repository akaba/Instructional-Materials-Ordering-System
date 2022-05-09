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
    public partial class ManageProducts : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod == "POST")
            {
               // DataBind();
            }

            if (!IsPostBack)
            {
                if (Session["CategoryDD"] != null)                
                    CategoryDD.SelectedIndex = (int)Session["CategoryDD"];
                
                if (Session["SubjectAreaDD"] != null)                
                    SubjectAreaDD.SelectedIndex = (int)Session["SubjectAreaDD"];              
            }
        }


        public IQueryable<Product> GetProducts(
            [Control("CategoryDD", "SelectedValue")] int? categoryId, [Control("SubjectAreaDD", "SelectedValue")] string subarea)
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            
            //return (categoryId ?? 0) == 0 ? _db.Products: _db.Products.Where(p => p.CategoryID == categoryId);
            if ((categoryId == null || categoryId == 0) && (subarea == null || subarea == "All"))
            {
                return _db.Products;
            }
            else if ((categoryId == null || categoryId == 0) && (subarea != null || subarea != "All"))
            {
                return _db.Products.Where(p => p.SubjectArea == subarea).OrderBy(p => p.Grade);
            }
            else if ((categoryId != null || categoryId != 0) && (subarea == null || subarea == "All"))
            {
                return _db.Products.Where(p => p.CategoryID == categoryId).OrderBy(p => p.Grade);
            }
            else { 
                return _db.Products.Where(p => p.CategoryID == categoryId).Where(p => p.SubjectArea == subarea).OrderBy(p => p.Grade); 
            }
             
         }

      


        protected void ProductListView_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //set current page startindex, max rows and rebind to false
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            
        }

        public IQueryable<Category> GetCategories()
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            IQueryable<Category> query = _db.Categories;
            return query;
           
        }

        protected void CategoryDD_DataBound(object sender, EventArgs e)
        {
            DropDownList dd = sender as DropDownList;
            dd.Items.Insert(0, new ListItem("All", "0"));
        }
      

        protected void CategoryDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CategoryDD"] = CategoryDD.SelectedIndex;
           // Response.Redirect("/Admin/ManageProducts.aspx?catid=" + categoryDD.SelectedValue);
            ProductListView.DataBind();
        }

        public IEnumerable<string> GetSubjectArea()
        {
            var _db = new InstructionalMaterials.Models.ProductContext();  
            return new string[] { "All" }.Concat(_db.Products.Select(p => p.SubjectArea).Distinct().OrderBy(c => c));

        }

        protected void SubjectAreaDD_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["SubjectAreaDD"] = SubjectAreaDD.SelectedIndex;
           // Response.Redirect("/Admin/ManageProducts.aspx?sub=" + SubjectAreaDD.SelectedValue);
            ProductListView.DataBind();
        }

        protected void ButtonReset_Click(object sender, EventArgs e)
        {
            CategoryDD.SelectedIndex = 0;
            SubjectAreaDD.SelectedIndex = 0;           
        }

    }
}