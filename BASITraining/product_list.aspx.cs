using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BASITraining.Models;
using System.Web.ModelBinding;
using System.Data.SqlClient;
using System.Configuration;

namespace BASITraining
{
    public partial class product_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public IQueryable<product> GetProducts([QueryString("id")] int? CategoryID)
        {
            var _db = new BASITraining.Models.p_context();
            IQueryable<product> query = _db.Products;
            if (CategoryID.HasValue && CategoryID > 0)
            {
                query = query.Where(p => p.CategoryID == CategoryID);
            }
            return query;
        }
    }
}