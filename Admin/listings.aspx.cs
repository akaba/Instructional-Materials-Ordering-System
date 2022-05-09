using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InstructionalMaterials.Models;
using System.Web.ModelBinding;
using System.Web.Routing;



namespace InstructionalMaterials.Admin
{
      
    public partial class listings : System.Web.UI.Page
    {
        private int pageSize = 4;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IEnumerable<Product> GetProducts()
        {
            return FilterProducts()
                .OrderBy(p => p.ProductID)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        protected int CurrentPage
        {
            get
            {
                int page = GetPageFromRequest();
                return page > MaxPage ? MaxPage : page;
            }
        }

        protected int MaxPage
        {
            get
            {
                int prodCount = FilterProducts().Count();
                return (int)Math.Ceiling((decimal)prodCount / pageSize);
            }
        }

        private IEnumerable<Product> FilterProducts()
        {
            var _db = new InstructionalMaterials.Models.ProductContext();
            IEnumerable<Product> products = _db.Products;
            string currentCategory = (string)RouteData.Values["CategoryID"] ??
                Request.QueryString["CategoryID"];
            return currentCategory == null ? products
                : products.Where(p => p.CategoryID == Convert.ToInt32(currentCategory));
        }

        private int GetPageFromRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ??
                Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }
    }
}