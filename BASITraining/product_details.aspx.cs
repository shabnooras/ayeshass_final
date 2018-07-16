using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BASITraining.Models;
using System.Web.ModelBinding;

namespace BASITraining
{
    public partial class product_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //This code shows the GetProducts method which is referenced by the ItemType property of the ListView control 
        //in the product_list.aspx page
        public IQueryable<product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new BASITraining.Models.p_context();
            IQueryable<product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}
