using eCommerceCartFunc_Models_;

namespace eCommerceCartFunc_DataService_
{
    public class CartInMemory
    {
        public List<Product> productList = new List<Product>();
        public List<Product> productMenu = new List<Product>();
        public List<Product> fashionProducts = new List<Product>();
        public List<Product> electronicProducts = new List<Product>();
        public List<Product> groceryProducts = new List<Product>();
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
        public void ProductMenu()
        {
            fashionProducts.Add(new Product { ProductCode = "FN-1", ProductName = "Uniqlo Ultra Light Jacket" });
            fashionProducts.Add(new Product { ProductCode = "FN-2", ProductName = "Nike Air Max 270" });

            electronicProducts.Add(new Product { ProductCode = "ET-1", ProductName = "Samsung Galaxy Watch8 Smartwatch" });
            electronicProducts.Add(new Product { ProductCode = "ET-2", ProductName = "HUAWEI MatePad 11.5\" Tablet " });

            groceryProducts.Add(new Product { ProductCode = "GR-1", ProductName = "Nescafé Gold Coffee" });
            groceryProducts.Add(new Product { ProductCode = "GR-2", ProductName = "Jack N' Jill Cloud 9 Classic Bars" });

            productMenu = fashionProducts.Concat(electronicProducts).Concat(groceryProducts).ToList();
        }

        //public bool removeItem(string itemToRemove)
        //{
        //    if ()
        //    {

        //    }
        //    return true;
        //}
        public List<Product> viewCart()
        {
            return productList;
        }
}}