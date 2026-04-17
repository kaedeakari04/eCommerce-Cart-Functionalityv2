using eCommerceCartFunc_Models_;

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
        public string GetProductName(string productInCode)
        {
            return dataService.GetProductName(productInCode);
        }
        public int? GetCartCapacity()
        {
            return dataService.GetCartCapacity();
        }
        public double? GetTotalPrice()
        {
            return dataService.GetTotalPrice();
        }
        public bool isProductExist(string productInCode, int productInQuanti)
        {
            return dataService.isProductExist(productInCode, productInQuanti);
        }
        public bool isProductValid(string productInCode)
        {
            return dataService.isProductValid(productInCode);
        }
        public void updateQuantity(string productInCode, int productInQuanti)
        {
            dataService.updateQuantity(productInCode, productInQuanti);
        }
        public void AddItem(string productInCode, int productInQuanti)
        {
            dataService.AddItem(productInCode, productInQuanti);
        }
        public void RemoveItem(string productIncode)
        {
            dataService.RemoveItem(productIncode);
        }
        public bool cartHasItems()
        {
            return dataService.cartHasItems();
        }
        public bool clearCart()
        {
            return dataService.clearCart();
        }
        public List<Product> viewCart()
        {
            return dataService.viewCart();
        }  
}}
