using eCommerceCartFunc_Models_;

namespace eCommerceCartFunc_DataService_
{
    public class CartInMemory
    {
        public List<Product> productList = new List<Product>();
        public int maxCartCount = 2;

        public void AddItem(string productInCode, int productInQuanti)
        {
            if (productList.Count >= maxCartCount)
            {
                return;
            }
            Product item = new Product
            {
                ProductCode = productInCode,
                ProductQuantity = productInQuanti,
            };
            productList.Add(item);
        }

        public List<Product> fashionProducts()
        {
            return new List<Product>
            {
                new Product { ProductCode = "FN-1", ProductName = "Uniqlo Ultra Light Jacket" },
                new Product { ProductCode = "FN-2", ProductName = "Nike Air Max 270" }
            };
        }

        public List<Product> electronicProducts()
        {
            return new List<Product>
            {
                new Product { ProductCode = "ET-1", ProductName = "Samsung Galaxy Watch8 Smartwatch" },
                new Product { ProductCode = "ET-2", ProductName = "HUAWEI MatePad 11.5\" Tablet " }
            };
        }
        public List<Product> groceryProducts()
        {
            return new List<Product>
            {
                new Product { ProductCode = "GR-1", ProductName = "Nescafé Gold Coffee" },
                new Product { ProductCode = "GR-2", ProductName = "Jack N' Jill Cloud 9 Classic Bars" }
            };
        }
        public List<Product> viewCart()
        {
            return productList;
        }
}}