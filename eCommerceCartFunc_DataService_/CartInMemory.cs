using eCommerceCartFunc_Models_;

namespace eCommerceCartFunc_DataService_
{
    public class CartInMemory
    {
        public List<Product> productList = new List<Product>();
        public int maxCartCount = 99;

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
                new Product { ProductCode = "FN-1", ProductName = "Uniqlo Ultra Light Jacket", ProductPrice = 2490},
                new Product { ProductCode = "FN-2", ProductName = "Nike Air Max 270", ProductPrice = 7000}
            };
        }

        public List<Product> electronicProducts()
        {
            return new List<Product>
            {
                new Product { ProductCode = "ET-1", ProductName = "Samsung Galaxy Watch8 Smartwatch", ProductPrice = 21890 },
                new Product { ProductCode = "ET-2", ProductName = "HUAWEI MatePad 11.5\" Tablet", ProductPrice = 14499 }
            };
        }
        public List<Product> groceryProducts()
        {
            return new List<Product>
            {
                new Product { ProductCode = "GR-1", ProductName = "Nescafé Gold Coffee", ProductPrice = 350 },
                new Product { ProductCode = "GR-2", ProductName = "Jack N' Jill Cloud 9 Classic Bars", ProductPrice = 165 }
            };
        }
        public List<Product> viewCart()
        {
            return productList;
        }
}}