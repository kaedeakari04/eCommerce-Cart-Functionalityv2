using eCommerceCartFunc_Models_;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace eCommerceCartFunc_DataService_
{
    public class cart_JSON_Data : ICartDataService
{
    //NOTES: same file as the Data Service, but the difference is this requires special coding! --> to get JSON file

    public List<Product> products = new List<Product>();

    private string JsonFile;
    public int maxCartCount => 99;

        public List<Product> productList => products;

        public cart_JSON_Data() {
    JsonFile = $"{AppDomain.CurrentDomain.BaseDirectory}/Products.json";

    addToJsonFile();
    }

    private void addToJsonFile()
    {
        if (!File.Exists(JsonFile))
        {
            saveToJsonFile();
        }
        else
        {
            retrieveToJsonFile();
        }
    }

    private void saveToJsonFile()
    {
        using (var outputStream = File.OpenWrite(JsonFile))
        {
            JsonSerializer.Serialize<List<Product>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                { SkipValidation = true, Indented = true })
                , products);
        }
    }

    private void retrieveToJsonFile()
    {
        using (var jsonFileReader = File.OpenText(JsonFile))
        {
            products = JsonSerializer.Deserialize<List<Product>>
                (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true })
                .ToList();
        }
    }

    public void AddItem(string productInCode, int productInQuanti)
    {
            if (products.Count >= maxCartCount)
            {
                return;
            }
            Product item = new Product
            {
                ProductCode = productInCode,
                ProductQuantity = productInQuanti
            };
            products.Add(item);
            saveToJsonFile();
    }

    public List<Product> viewCart()
    {
        retrieveToJsonFile();
        return products;
    }
}}
