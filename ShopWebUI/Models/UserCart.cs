using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopWebUI.Models
{
    public class UserCart
    {
        List<Cart> carts;
        public UserCart()
        {
            carts = new List<Cart>();
        }
        public List<Cart> Carts
        {
            get
            {
                return carts;
            }
            set
            {
                carts = value;
            }
        }
    }
}