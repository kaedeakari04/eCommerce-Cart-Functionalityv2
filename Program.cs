using System;
using eCommerceCartFunc_AppService;


namespace eCommerceCartFunc {
    internal class Program
    {

        //!NOTE TO SELF!
        //UPDATE | 02.21:
        // > added the basic structure of the program. Still need to work on the adding, removing item and view cart function...
        //------------------
        //UPDATE | 02.28:
        // > removed some features, to avoid myself being overwhelmed and focus on the basic agendas, before moving on with adding more features!
        // > REMOVE ITEM & VIEW CART Function is not yet available. After adding item -> view cart will be shown automatically.
        // > cannot calculate the product total price yet in accordance to quantity.
        // ADDED 02.28_v2
        // > added loop for adding more items
        // > fixed view cart function
        //------------------
        //UPDATE  |  03.13:
        // > added maximum cart limit/threshold + checker
        // > created product code instead of typing the whole product name

        //--------------------
        static CartAppService serviceAccess = new CartAppService();

        static List<string> fashionProduct = new List<string>();
        static List<string> electronicsProduct = new List<string>();
        static List<string> groceriesProduct = new List<string>();


   
        static void Main(string[] args)
        {
            //TITLE STUFF 
            Console.WriteLine("E-Commerce App  |  CART FUNCTIONALITY\n===============================");
            productDisplay();

            //MAIN BLOCK STUFF
            while (true)
            {
                Console.WriteLine("===============================\n-- SELECT A COMMAND --" + "\nA | Add Item\nB | Remove Item \nC | View Cart");
                cartMenu();
            }
        }

        static void cartMenu()
        {
            string userInput;
            Console.Write("===============================\nENTER A COMMAND: ");
            userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();
            switch (userInput)
            {
                case "A":
                    addItem();
                    break;
                case "B":
                    removeItem();
                    break;
                case "C":
                    viewCart();
                    break;
                default:
                    Console.WriteLine("INVALID COMMAND. SYSTEM WILL EXIT...");
                    Environment.Exit(0);
                    break;
            }
        }
        static void addItem()
        {
            Console.Write("ENTER PRODUCT CODE: ");
            string productInput = Console.ReadLine().ToUpper();
            Console.Write("ENTER " + productInput + " QUANTITY : ");
            if (int.TryParse(Console.ReadLine(), out int quantityInput)) {
                bool isSuccessful = serviceAccess.addToCart(productInput, quantityInput);

                if (isSuccessful)
                {
                    Console.WriteLine(productInput + " IS SUCCESSFULLY ADDED TO CART!");
                }

                else {
                    Console.WriteLine("ERROR! YOUR CART HAS REACHED ITS MAXIMUM LIMIT");
                }
            } 
        }
        static void removeItem()
        {

        }
        static void viewCart()
        {
            Console.WriteLine("\n===================\nMY CART");
            Console.WriteLine("PRODUCT NAME  |  QUANTITY");

            var cartItems = serviceAccess.viewMyCart();

            if (cartItems.Count == 0 )
            {
                Console.WriteLine("ERROR! YOUR CART IS EMPTY!");
            }
            else
            {
                foreach (var item in cartItems) 
                {
                    Console.WriteLine($"[ {item.ProductCode} ]     x {item.ProductQuantity}");
                }
            }
        }
        private static void productDisplay()
        {
            //Dis is for my reference, Im gon use to add items to the cart
            Console.WriteLine("--- PRODUCTS ---\nkindly type in the product code to add to Cart!\n=========");
            Console.WriteLine("FASHION\n> FN-1: Uniqlo Ultra Light Jacket  |  Php2,490\n> FN-2: Nike Air Max 270  |  Php7,000\n=========");
            Console.WriteLine("ELECTRONICS\n> ET-1: Samsung Galaxy Watch8 Smartwatch  |  Php21,890\n> ET-2: HUAWEI MatePad 11.5\" Tablet  |  Php14,499\n=========");
            Console.WriteLine("GROCERIES\n> GR-1: Nescafé Gold Coffee   | Php350\n> GR-2: Jack N' Jill Cloud 9 Classic Bars  |  Php165");
            //
            fashionProduct.Add("Uniqlo Ultra Light Jacket");
            fashionProduct.Add("Nike Air Max 270");
            electronicsProduct.Add("Samsung Galaxy Watch8 Smartwatch");
            electronicsProduct.Add("HUAWEI MatePad 11.5\" Tablet");
            groceriesProduct.Add("Nescafé Gold Coffee");
            groceriesProduct.Add("Jack N' Jill Cloud 9 Classic Bars");
        }
}}