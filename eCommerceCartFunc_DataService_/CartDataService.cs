using eCommerceCartFunc_Models_;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceCartFunc_DataService_
{
    public class CartDataService
    {
        ICartDataService dataService;

        public List<Product> productList = new List<Product>();
        public int maxCartCount = 99;
        public CartDataService(ICartDataService cartDataService)
        {
            dataService = cartDataService;
        }

        public void AddItem(string productInCode, int productInQuanti)
        {
            dataService.AddItem(productInCode, productInQuanti);
        }

        public List<Product> viewCart()
        {
            return dataService.viewCart();
        }
    }
}
