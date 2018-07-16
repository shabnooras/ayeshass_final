using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BASITraining.Models;

namespace BASITraining.Logic
{
    public class ShoppingCartActions : IDisposable
    {
        public string ShoppingCartId { get; set; }

        private p_context _db = new p_context();

        public const string CartSessionKey = "CartId";

        public void AddToCart(int id)
        {
            // Retrieve the product from the database.           
            ShoppingCartId = GetCartId();

            var cartItem = _db.coursecartitems.SingleOrDefault(c => c.CartId == ShoppingCartId
            && c.ProductId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new cartitem
                {
                    ItemId = Guid.NewGuid().ToString(),
                    ProductId = id,
                    CartId = ShoppingCartId,
                    Product = _db.Products.SingleOrDefault(p => p.ProductID == id),
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };

                _db.coursecartitems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity++;
            }
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
                _db = null;
            }
        }

        public string GetCartId()
        {
            if (HttpContext.Current.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
                {
                    HttpContext.Current.Session[CartSessionKey] = HttpContext.Current.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class.     
                    Guid tempCartId = Guid.NewGuid();
                    HttpContext.Current.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return HttpContext.Current.Session[CartSessionKey].ToString();
        }

        public List<cartitem> GetCartItems()
        {
            ShoppingCartId = GetCartId();

            return _db.coursecartitems.Where(
                c => c.CartId == ShoppingCartId).ToList();
        }
        //getsum method to get id of cart for user
        public decimal Getsum()
        {
            ShoppingCartId = GetCartId();
            //using nullable decimal and int
            // calculate sum by checking number of courses selectd and multiply by the price
            //and then sum for total courses taken
            decimal? sum = decimal.Zero;
            sum = (decimal?)(from cartItems in _db.coursecartitems
                             where cartItems.CartId == ShoppingCartId
                             select (int?)cartItems.Quantity * cartItems.Product.UnitPrice).Sum();
            return sum ?? decimal.Zero;
        }
        public ShoppingCartActions GetCart(HttpContext context)
        {
            using (var cart = new ShoppingCartActions())
            {
                cart.ShoppingCartId = cart.GetCartId();
                return cart;
            }
        }

        public void UpdateShoppingCartDatabase(String cartId, ShoppingCartUpdates[] CartItemUpdates)
        {
            using (var db = new BASITraining.Models.p_context())
            {
                try
                {
                    int CartItemCount = CartItemUpdates.Count();
                    List<cartitem> myCart = GetCartItems();
                    foreach (var cartItem in myCart)
                    {
                        // Iterate through all rows within shopping cart list
                        for (int i = 0; i < CartItemCount; i++)
                        {
                            if (cartItem.Product.ProductID == CartItemUpdates[i].ProductId)
                            {
                                if (CartItemUpdates[i].RemoveItem == true)
                                {
                                    RemoveItem(cartId, cartItem.ProductId);
                                }
                                else
                                {
                                    UpdateItem(cartId, cartItem.ProductId);
                                }
                            }
                        }
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void DeleteShoppingCartDatabase(String cartId)
        {
            using (var db = new BASITraining.Models.p_context())
            {
                try
                {
                    DeleteItem(cartId);

                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Database - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void RemoveItem(string removeCartID, int removeProductID)
        {
            using (var _db = new BASITraining.Models.p_context())
            {
                try
                {
                    var myItem = (from c in _db.coursecartitems where c.CartId == removeCartID && c.Product.ProductID == removeProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.coursecartitems.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }
        public void DeleteItem(string removeCartID)
        {
            using (var _db = new BASITraining.Models.p_context())
            {
                try
                {
                    var myItem = (from c in _db.coursecartitems where c.CartId == removeCartID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        // Remove Item.
                        _db.coursecartitems.Remove(myItem);
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Remove Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }

        public void UpdateItem(string updateCartID, int updateProductID)
        {
            using (var _db = new BASITraining.Models.p_context())
            {
                try
                {
                    var myItem = (from c in _db.coursecartitems where c.CartId == updateCartID && c.Product.ProductID == updateProductID select c).FirstOrDefault();
                    if (myItem != null)
                    {
                        
                        _db.SaveChanges();
                    }
                }
                catch (Exception exp)
                {
                    throw new Exception("ERROR: Unable to Update Cart Item - " + exp.Message.ToString(), exp);
                }
            }
        }
        public void EmptyCart()
        {
            ShoppingCartId = GetCartId();
            var cartItems = _db.coursecartitems.Where(
                c => c.CartId == ShoppingCartId);
            foreach (var cartItem in cartItems)
            {
                _db.coursecartitems.Remove(cartItem);
            }
            // Save changes.             
            _db.SaveChanges();
        }

        public int GetCount()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
            int? count = (from cartItems in _db.coursecartitems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null         
            return count ?? 0;
        }

        public int GetTotal()
        {
            ShoppingCartId = GetCartId();

            // Get the count of each item in the cart and sum them up          
           int? count = (from cartItems in _db.coursecartitems                         
                         select (int?)cartItems.Quantity).Sum(); 
            // Return 0 if all entries are null         
            return count ?? 0;
        }


        public struct ShoppingCartUpdates
        {
            public int ProductId;
            public int PurchaseQuantity;
            public bool RemoveItem;
        }
    }
}