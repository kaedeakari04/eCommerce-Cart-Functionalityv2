using eCommerceCartFunc_Models_;

namespace eCommerceCartFunc_DataService_
{
    public class CartDataService
    {
        ICartDataService dataService;

        public List<Product> productList = new List<Product>();
        public int maxCartCount = 2;

        public CartDataService(ICartDataService cartDataService)
        {
            dataService = cartDataService;
        }

        public bool isProductValid(string productInCode)
        {
            return dataService.isProductValid(productInCode);
        }
        public int? GetCartCapacity()
        {
            return dataService.GetCartCapacity();
        }

        public void AddItem(string productInCode, int productInQuanti)
        {
            dataService.AddItem(productInCode, productInQuanti);
        }

        //public void removeItem()
        //{

        //}

        public List<Product> viewCart()
        {
            return dataService.viewCart();
        }  
}}
