using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BASITraining.Models;
using BASITraining.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;


namespace BASITraining
{
    public partial class shoppingcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["previous"] = "cart";
            if (Session["a"] != null)
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())

                {
                    decimal cartsum = 0;

                    cartsum = usersShoppingCart.Getsum();
                    if (cartsum > 0)
                    {
                        // Display Total.
                        lblTotal.Text = String.Format("{0:c}", cartsum);
                    }
                    else
                    {
                        LabelTotalText.Text = "";
                        lblTotal.Text = "";
                        ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
                        Updatebutton.Visible = false;
                    }
                }
            }
        }
        public List<cartitem> Getcoursecartitems()
        {
           // if (Session["a"] != null)
           // {
                ShoppingCartActions actions = new ShoppingCartActions();
                return actions.GetCartItems();
         //  }
           // else
               // return null;

        }
        public List<cartitem> UpdateCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                   // TextBox quantityTextBox = new TextBox();
                   // quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                   // cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.Getsum());
                return usersShoppingCart.GetCartItems();
            }
        }


        public List<cartitem> delteCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                for (int i = 0; i < usersShoppingCart.GetTotal(); i++)
                {
                   
                    usersShoppingCart.DeleteShoppingCartDatabase(cartId);
                }
               
               // lblTotal.Text = "0";
                return usersShoppingCart.GetCartItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }


        protected void CartList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void updatebutton_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            var a = Context.User.Identity.GetUserName();
            if (Session["a"] == null )
            {
                Response.Redirect("Account/Login.aspx");
            }
            else
            { Response.Redirect("Contact.aspx"); }

        }
    }
}