using System;
using System.Collections.Generic;
using System.Text;
using eCommerceCartFunc_Models;
using eCommerceCartFunc_DataService;


namespace eCommerceCartFunc_AppService
{
    public class CartAppService
    {
        CartDataService dataService = new CartDataService();
        Product product = new Product();
        public bool addToCart(string newProductCode, int newProductQuanti)
        {

            if (product.ProductQuantity <= 0)
            {
                return false;
            }
            dataService.AddItem(newProductCode, newProductQuanti);
            return true;
        }
    }
}