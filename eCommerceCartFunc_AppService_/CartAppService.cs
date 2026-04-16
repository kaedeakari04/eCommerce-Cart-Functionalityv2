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
            int? cartCapacity = dataService.GetCartCapacity();
            if (newProductQuanti <= 0)
            {
                return false;
            }
            if (newProductQuanti >= dataService.maxCartCount)
            {
                return false;
            }
            if ((cartCapacity != null) && (cartCapacity >= dataService.maxCartCount))
            {
                return false;
            }

            isProductExist(newProductCode, newProductQuanti);
            return true;
        }

        public bool isProductValid(string newProductCode)
        {
            return dataService.isProductValid(newProductCode);
        }
        public bool isProductExist(string newProductCode, int newProductQuantity)
        {
            if (dataService.isProductExist(newProductCode, newProductQuantity))
            {
                dataService.updateQuantity(newProductCode, newProductQuantity);
            }
            else
            {
                dataService.AddItem(newProductCode, newProductQuantity);
            }
            return true;
        }

        public bool isInCart(string newProductCode, int newProductQuantity)
        {
            if (!dataService.isProductExist(newProductCode, newProductQuantity))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void removeItem(string newProductCode)
        {
            dataService.RemoveItem(newProductCode);
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