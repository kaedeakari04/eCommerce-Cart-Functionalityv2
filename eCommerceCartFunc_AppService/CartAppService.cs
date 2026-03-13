using eCommerceCartFunc_DataService;
using eCommerceCartFunc_Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace eCommerceCartFunc_AppService
{
    public class CartAppService
    {
        CartDataService dataService = new CartDataService();
        Product product = new Product();
        public bool addToCart(string newProductCode, int newProductQuanti)
        {


            if (dataService.productList.Count >= dataService.maxCartCount)
            {
                return false;
            }
            dataService.AddItem(newProductCode, newProductQuanti);
            return true;

       
        }

        public List <Product> viewMyCart(){
            return dataService.viewCart();
        }
    }
}