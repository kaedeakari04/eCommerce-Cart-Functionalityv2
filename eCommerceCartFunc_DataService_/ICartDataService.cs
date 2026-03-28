using eCommerceCartFunc_Models_;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceCartFunc_DataService_
{
    public interface ICartDataService
    {
        public List<Product> productList { get; }

        public int maxCartCount { get; }
        public void AddItem(string productInCode, int productInQuanti);
        public List<Product> viewCart();
    }
}
