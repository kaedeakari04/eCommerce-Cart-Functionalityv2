using System;
using eCommerceCartFunc_AppService_;
using eCommerceCartFunc_DataService_;
using eCommerceCartFunc_Models_;

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
        //UPDATE  |  03.14:
        // > integrated BL and DL
        // > TO ADD: Remove Function  |  TO FIX: add more Item Loop
        //--------------------
        //UPDATE  |  03.28:
        // > fixed BL and DL -> files uploaded separately
        // > added JSON files and datas along with it 
        //--------------------
        //UPDATE  |  03.29:
        // > connected database: CartDB to SSMS
        // > add DB.bak in Main Class
        //--------------------
        //UPDATE  |  04.15
        // > Fixed Cart Threshold/Capacity
        // > Removed Interface from CartJSON class
        //--------------------
        //UPDATE | 04.16
        // > Added and completed validations for AddItem() - cart capacity & checking if item is valid
        // > Created new table for Products Catalog in the database - for checking if current item exists/valid

        static CartAppService serviceAccess = new CartAppService();
        static string productInput;
        static int quantityInput;

        static void Main(string[] args)
        {
            productDisplay();
           

            while (true)
            {
                cartMenu();
            }
        }

        static void cartMenu()
        {
            string userInput;
            string menuToPrint = """
 
                                ===============================
                                -- SELECT A COMMAND --
                                A | Add Item
                                B | Remove Item
                                C | View Cart
                                X | EXIT PROGRAM
                                """;

            Console.WriteLine(menuToPrint);
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
                case "X":
                    exitProgram();
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
                productInput = Console.ReadLine().ToUpper();

            if (!serviceAccess.isProductValid(productInput))
            {
                Console.WriteLine("ERROR! " + productInput + " IS NOT A VALID PRODUCT CODE.");

                while (true)
                {
                    addItem();
                }
            }

            Console.Write("ENTER " + productInput + " QUANTITY : ");
            string toParseInput = Console.ReadLine();

            bool isParsed = int.TryParse(toParseInput, out quantityInput);

            if (isParsed) 
            {
                    bool isSuccessful = serviceAccess.addToCart(productInput, quantityInput);

                    if (isSuccessful)
                    {
                        Console.WriteLine(productInput + " IS SUCCESSFULLY ADDED TO CART!");
                    }

                    else 
                    {
                        Console.WriteLine("ERROR! YOUR CART HAS REACHED ITS MAXIMUM LIMIT.");
                        cartMenu();
                    }
                }
            else
            {
                Console.WriteLine("ERROR! INVALID NUMBER.");
                Environment.Exit(0);
            }
        }
        static void removeItem()
        {
            Console.Write("ENTER PRODUCT CODE TO REMOVE: ");
            productInput = Console.ReadLine().ToUpper();

            bool isInCart = serviceAccess.removeFromCart(productInput);

            if (isInCart)
            {
                Console.Write("ARE YOU SURE YOU WANT TO REMOVE " + productInput + "? [Y/N]: ");
                string confirmRemove = Console.ReadLine().ToUpper();
                switch (confirmRemove)
                {
                    case "Y":
                        Console.WriteLine(productInput + " IS SUCCESSFULLY REMOVED FROM CART!");
                        cartMenu();
                        break;
                    case "N":
                        Console.WriteLine("UNDERSTOOD. RETURNING TO MAIN MENU...");
                        cartMenu();
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT. Y or N only.\n EXITING PROGRAM...");
                        Environment.Exit(0);
                        break;
                }
            }
            else
            {
                Console.WriteLine("ERROR! " + productInput + " IS NOT ON YOUR CART.");
            }
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

        static void exitProgram()
        {
            Console.WriteLine("THANK YOU! EXITING PROGRAM...");
            Environment.Exit(0);  
        }

        static void productDisplay()
        {
            CartInMemory toDisplay = new CartInMemory();
            toDisplay.ProductMenu();
            var fashionProducts = toDisplay.fashionProducts;
            var electronicProducts = toDisplay.electronicProducts;
            var groceryProducts = toDisplay.groceryProducts;

            string productMenu = """
                                ===============================
                                E-Commerce App  |  CART FUNCTIONALITY
                                ===============================
                                --- PRODUCTS ---
                                kindly type in the product code to add to Cart!
                                =========
                                """;

            Console.WriteLine(productMenu);
            Console.WriteLine("FASHION\n=========");
            foreach (var item in fashionProducts)
            {
                Console.WriteLine($"{item.ProductCode}  | {item.ProductName}");
            }

            Console.WriteLine("\nELECTRONICS\n=========");
            foreach (var item in electronicProducts)
            {
                Console.WriteLine($"{item.ProductCode}  | {item.ProductName}");
            }

            Console.WriteLine("\nGROCERIES\n=========");
            foreach (var item in groceryProducts)
            {
                Console.WriteLine($"{item.ProductCode}  | {item.ProductName}");
            }
        }
}}