using eCommerceCartFunc_Models_;

namespace eCommerceCartFunc_DataService_
{
    public interface ICartDataService
    {
        public void AddItem(string productInCode, int productInQuanti);
        public string GetProductName(string productInCode);
        public int? GetCartCapacity();
        public bool isProductValid(string productInCode);
        public bool isProductExist(string productInCode, int productInQuanti);
        public void updateQuantity(string productInCode, int productInQuanti);
        public void RemoveItem(string productIncode);
        public List<Product> viewCart();
}}
