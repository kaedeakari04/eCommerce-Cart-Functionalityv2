using System;
using System.Collections.Generic;
using System.Text;
using eCommerceCartFunc_Models;
using eCommerceCartFunc_AppService;

namespace eCommerceCartFunc_DataService
{
    public class CartDataService
    {
        public List<Product> productList = new List<Product>();
        public int maxCartCount = 99;

        public void AddItem(string productInCode, int productInQuanti)
        {
            if (productList.Count >= maxCartCount)
            {
                return;
            }
            Product item = new Product
            {
                ProductCode = productInCode,
                ProductQuantity = productInQuanti
            };
            productList.Add(item);
        }

        public void removeItem()
        {

        }

        public List<Product> viewCart()
        {
            return productList;
        }
    }
}