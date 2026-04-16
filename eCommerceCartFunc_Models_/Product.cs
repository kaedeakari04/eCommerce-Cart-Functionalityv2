using System.ComponentModel.DataAnnotations;

namespace eCommerceCartFunc_Models_
{
    public class Product
    {
        public string ProductName { get; set; }
        public required string ProductCode { get; set; }
        public string Category { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice {get; set;}
}}