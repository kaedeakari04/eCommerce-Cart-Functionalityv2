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
        CartInMemory productDisplay = new CartInMemory();

        public CartAppService()
        {
            cart_JSON_Data cartJson = new cart_JSON_Data();
        }
        public bool addToCart(string newProductCode, int newProductQuanti)
        {

            isProductValid(newProductCode);
            int? cartCapacity = dataService.GetCartCapacity();
            if (newProductQuanti >= dataService.maxCartCount)
            {
                return false;
            }
            if ((cartCapacity != null) && (cartCapacity >= dataService.maxCartCount))
            {
                return false;
            }

            dataService.AddItem(newProductCode, newProductQuanti);
            return true;
        }

        public bool isProductValid(string newProductCode)
        {
            if (!dataService.isProductValid(newProductCode))
            {
                return false;
            }
            return true;
        }

        public bool removeFromCart(string productCode)
        {
            return true;
        }
        public List<Product> viewMyCart()
        {
            return dataService.viewCart();
        }

        public List<Product> getFashionProducts()
        {
            return productDisplay.fashionProducts();
        }
        public List<Product> getElectronicProducts()
        {
            return productDisplay.electronicProducts();
        }
        public List<Product> getGroceryProducts()
        {
            return productDisplay.groceryProducts();
        }
    
}}