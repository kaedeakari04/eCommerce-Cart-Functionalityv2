using eCommerceCartFunc_Models_;

namespace eCommerceCartFunc_DataService_
{
    public interface ICartDataService
    {
        public void AddItem(string productInCode, int productInQuanti);
        public int? GetCartCapacity();
        public bool isProductValid(string productInCode);
        //public void removeItem();
        public List<Product> viewCart();
}}
