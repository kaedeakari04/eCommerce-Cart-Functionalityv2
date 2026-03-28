using eCommerceCartFunc_Models_;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceCartFunc_DataService_
{
    internal class CartDataService
    {
        ICartDataService dataService;
        CartDataService(ICartDataService cartDataService)
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
