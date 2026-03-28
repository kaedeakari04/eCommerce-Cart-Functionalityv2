using eCommerceCartFunc_Models_;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceCartFunc_DataService_
{
    public interface ICartDataService
    {
        public void AddItem(string productInCode, int productInQuanti);
        public List<Product> viewCart();
    }
}
