using eCommerceCartFunc_DataService_;
using eCommerceCartFunc_Models_;
using System;
using System.Collections.Generic;
using System.Text;


namespace eCommerceCartFunc_AppService_
{
    public class CartAppService
    {
        CartDataService dataService = new CartDataService(new CartDB());

        public CartAppService()
        {
            cart_JSON_Data cartJson = new cart_JSON_Data();
        }
       
        public bool addToCart(string newProductCode, int newProductQuanti)
        {

            if (dataService.productList.Count >= dataService.maxCartCount)
            {
                return false;
            }
            dataService.AddItem(newProductCode, newProductQuanti);
            return true;


        }

        public List<Product> viewMyCart()
        {
            return dataService.viewCart();
        }
    }
}