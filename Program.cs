using System;

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


        static int maxCartCount = 2, productCounter = 0;
        //--------------------
        static List<string> userCartProduct = new List<string>();
        static List<int> productQuantity = new List<int>();
        static List<string> fashionProduct = new List<string>();
        static List<string> electronicsProduct = new List<string>();
        static List<string> groceriesProduct = new List<string>();
   
        static void Main(string[] args)
        {
            //TITLE STUFF 
            Console.WriteLine("E-Commerce App  |  CART FUNCTIONALITY\n===============================");
            productDisplay();
            Console.WriteLine("===============================\n-- SELECT A COMMAND --" + "\nA | Add Item\nB | Remove Item \nC | View Cart"); 
            //MAIN BLOCK STUFF
            cartMenu();
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
        static void addItem () 
        {
            Console.WriteLine("ADD ITEM TO CART\n===================\n");
            Console.Write("PRODUCT CODE: ");
            string productNameInput = Console.ReadLine().ToUpper();


            if ( productNameInput == "FN-1"
              || productNameInput == "FN-2"
              || productNameInput == "ET-1"
              || productNameInput == "ET-2"
              || productNameInput == "GR-1"
              || productNameInput == "GR-2") 
            {
                userCartProduct.Add(productNameInput);
                Console.Write("PRODUCT QUANTITY: ");
                int productQuantityInput = int.Parse(Console.ReadLine()); //i added int.Parse here to convert the input to an integer, since the product quantity is displaying 49 when entered 1 and etc. I searched to fix this issue!
                productQuantity.Add(productQuantityInput);

                Console.WriteLine(productNameInput + " ADDED TO CART SUCCESSFULLY!");

                if (userCartProduct.Count >= maxCartCount)
                {
                    Console.Write("YOUR CART HAS REACHED ITS MAXIMUM LIMIT. PLEASE CHECK-OUT OR REMOVE ITEMS.\n\n");
                    viewCart();
                    Environment.Exit(0);
                }
                else 
                {
                    //LOOP FOR ADDING MOREEE ITEMSSS
                    bool toAddMore = true;
                    while (toAddMore)
                    {
                        Console.Write("\n===================\nWOULD YOU LIKE TO ADD MORE ITEMS? [Y/N]? ");
                        string moreItemInput = Console.ReadLine().ToUpper();

                        switch (moreItemInput)
                        {
                            case "Y":

                                addItem();
                                break;
                            case "N":
                                viewCart();
                                Console.WriteLine("\n===================\nTHANK YOU. HAVE A GREAT DAY.");
                                toAddMore = false;
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("INVALID COMMAND. SYSTEM WILL EXIT...");
                                Environment.Exit(0);
                                break;
                        }
                    }
                }
            } else
            {
                Console.WriteLine("ERROR! PLEASE ENTER A VALID PRODUCT CODE.\n\n");
            }
               
           
        }
        static void removeItem()
        {

        }
        static void viewCart()
        {
            if (userCartProduct.Count > 0)
            {
                Console.WriteLine("\n===================\nMY CART");
                Console.WriteLine("PRODUCT NAME  |  QUANTITY");
                for (int i = 0; i < userCartProduct.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {userCartProduct[i]}   {productQuantity[i]}");
                }
            }
            else
            {
                Console.WriteLine("ERROR! YOUR CART IS CURRENTLY EMPTY.");
                cartMenu();
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