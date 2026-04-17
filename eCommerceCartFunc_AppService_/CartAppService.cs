using eCommerceCartFunc_DataService_;
using eCommerceCartFunc_Models_;

namespace eCommerceCartFunc_AppService_
{
    public class CartAppService
    {
        CartDataService dataService = new CartDataService(new CartDB());
        CartInMemory productDisplay = new CartInMemory(); //added for the purpose of products display

        //unused for JSON File
        public CartAppService()
        {
            cart_JSON_Data cartJson = new cart_JSON_Data();
        }
        public double? GetTotalPrice()
        {
            return dataService.GetTotalPrice();
        }
        public string GetProductName(string newProductCode)
        {
            return dataService.GetProductName(newProductCode);
        }
        public bool isProductValid(string newProductCode)
        {
            return dataService.isProductValid(newProductCode);
        }
        /* |  this is for to either add the item if not in cart or update quantity instead
           v  */
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
        public bool addToCart(string newProductCode, int newProductQuanti)
        {
            int? cartCapacity = dataService.GetCartCapacity();
            if (newProductQuanti <= 0)
            {
                return false;
            }
            if (newProductQuanti > dataService.maxCartCount)
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
        public bool validateRemove(string newProductCode, int newProductQuantity)
        {
            if(!dataService.isProductValid(newProductCode))
            {
                return false;
            }
            
            if (!dataService.isProductExist(newProductCode, newProductQuantity))
            {
                return false;
            }
            return true;
        }
        public void removeItem(string newProductCode)
        {
            dataService.RemoveItem(newProductCode);
        }
        public bool cartHasItems()
        {
            return dataService.cartHasItems();
        }
        public bool clearCart()
        {
            if (!cartHasItems())
            {
                return false;
            }
            return dataService.clearCart();
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