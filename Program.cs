using eCommerceCartFunc_AppService_;

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
        // > Removed Project References of DL and Models from UI Layer(corrected)
        // > added the display function on BL for displaying product lists accordingly, instead of directly calling DL from UI
        // > fixed loop in addItem
        // > added new validation for accepting quantity and incrementing quantity if item already exists in DB table
        // > added remove specific item function | validations: [1] checks if valid product [2] checks if in cart
        // > added "confirm remove" feature in removeItem
        //--------------------
        //UPDATE | 04.17
        // > polished, cleaned layer codes and removed unused usings
        // > started adding Clear Cart Feature
        // > edited view cart (wherein, product name, price and category will also be shown)
        // > removeItem and addItem has been edited as well (wherein, product name will be outputted instead of product name)  |  created new method to getProductName
        // > added total price in view cart
        // > completed Clear Cart Feature
        // > added class diagram
        //--------------------
        //UPDATE | 04.18
        // > fixed logic in removeItem and clearCart 
        // > added product price in productDisplay
        // > final code cleanup check
        // > FINAL REMARKS: JSON File class and InMemory remains not updated and not in-used, used cartDB for all input storage -> except display of products

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
            string userInput,
            menuToPrint = """
 
                            ===============================
                            -- SELECT A COMMAND --
                            A | Add Item
                            B | Remove Item
                            C | Clear Cart
                            D | View Cart
                            X | EXIT PROGRAM
                            ===============================
                            ENTER A COMMAND: 
                            """;

            Console.Write(menuToPrint);
            userInput = Console.ReadLine().ToUpper();
            Console.WriteLine();

            switch (userInput)
            {
                case "A": addItem(); break;
                case "B": removeItem(); break;
                case "C": clearCart(); break;
                case "D": viewCart(); break;
                case "X":
                    Console.WriteLine("THANK YOU! EXITING PROGRAM...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("INVALID COMMAND. PLEASE ENTER ONE OF THE LISTED OPTIONS.");
                    break;
            }
        }
        static void addItem()
        {
            while (true)
            {
                Console.Write("ENTER PRODUCT CODE: ");
                productInput = Console.ReadLine().ToUpper();

                if (!serviceAccess.isProductValid(productInput))
                {
                    Console.WriteLine($"ERROR! {productInput} IS NOT A VALID PRODUCT CODE.");
                    continue;
                }
                break;
            }
            while (true)
            {
                Console.Write("ENTER QUANTITY : ");
                string toParseInput = Console.ReadLine();

                if (!int.TryParse(toParseInput, out quantityInput))
                {
                    Console.WriteLine("ERROR! INVALID NUMBER.");
                    continue;
                }
                break;
            }
            if (!serviceAccess.addToCart(productInput, quantityInput))
            {
                string checkQuantityInput = quantityInput <= 0 ? "ERROR! QUANTITY MUST BE POSITIVE AND GREATER THAN 0."
                                                    : "ERROR! YOUR CART HAS REACHED ITS MAXIMUM LIMIT.";
                Console.WriteLine(checkQuantityInput);
            }
            else
            {
                string ProductName = serviceAccess.GetProductName(productInput);
                Console.WriteLine($"{ProductName} IS SUCCESSFULLY ADDED TO CART!");
            }
        }

        static void removeItem()
        {
            bool cartHasItems = serviceAccess.cartHasItems();
            if (!cartHasItems)
            {
                Console.WriteLine("ERROR! YOUR CART IS EMPTY!");
            }
            else
            {
                while (true)
                {
                    Console.Write("ENTER PRODUCT CODE TO REMOVE: ");
                    productInput = Console.ReadLine().ToUpper();

                    if (!serviceAccess.validateRemove(productInput, quantityInput))
                    {
                        Console.WriteLine("ERROR! " + productInput + " IS NOT A VALID PRODUCT CODE OR NOT IN CART.");
                        continue;
                    }
                    break;
                }
                string ProductName = serviceAccess.GetProductName(productInput);
                Console.Write($"ARE YOU SURE YOU WANT TO REMOVE {ProductName}? [Y/N]: ");
                string confirmRemove = Console.ReadLine().ToUpper();

                switch (confirmRemove)
                {
                    case "Y":
                        serviceAccess.removeItem(productInput);
                        Console.WriteLine($"{ProductName} IS SUCCESSFULLY REMOVED FROM CART!");
                        break;
                    case "N":
                        Console.WriteLine("UNDERSTOOD. RETURNING TO MAIN MENU...");
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT. Y or N only.");
                        break;
                }
            }
        }
        static void clearCart()
        {
            bool cartHasItems = serviceAccess.cartHasItems();
            if (!cartHasItems)
            {
                Console.WriteLine("ERROR! YOUR CART IS EMPTY!");
            }
            else
            {
                Console.Write($"ARE YOU SURE YOU WANT TO CLEAR YOUR CART? [Y/N]: ");
                string confirmRemove = Console.ReadLine().ToUpper();

                switch (confirmRemove)
                {
                    case "Y":
                        serviceAccess.clearCart();
                        Console.WriteLine("YOUR CART HAS BEEN SUCCESSFULLY CLEARED!");
                        break;
                    case "N":
                        Console.WriteLine("UNDERSTOOD. RETURNING TO MAIN MENU...");
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT. Y or N only.");
                        break;
                }
            }   
        }
        static void viewCart()
        {
            var cartItems = serviceAccess.viewMyCart();
            double? totalPrice = serviceAccess.GetTotalPrice();

            if (cartItems.Count != 0 )
            {
                string toPrintView = """
                                ===================
                                MY CART
                                ===================
                                PRODUCT CODE  |            PRODUCT NAME           | QUANTITY |      PRICE      |  CATEGORY
                                """;
                Console.WriteLine(toPrintView);
                foreach (var item in cartItems)
                {
                    Console.WriteLine($"{item.ProductCode,-15} {item.ProductName,-38} {item.ProductQuantity,-10} PHP{item.ProductPrice,-10} {item.Category,-8}");
                }
                Console.WriteLine($"""
                                  ====================================================
                                  TOTAL         |   PHP{totalPrice}          
                                  """);
            }
            else
            {
                Console.WriteLine("ERROR! YOUR CART IS EMPTY!");
            }
        }
        static void productDisplay()
        {
            var fashionProducts = serviceAccess.getFashionProducts();
            var electronicProducts = serviceAccess.getElectronicProducts();
            var groceryProducts = serviceAccess.getGroceryProducts();

            string productMenu = """
                                ===============================
                                E-Commerce App  |  CART FUNCTIONALITY
                                ===============================
                                --- PRODUCTS ---
                                kindly type in the product code to add to Cart!
                                =========
                                """;

            Console.WriteLine(productMenu);
            Console.WriteLine("""
                            FASHION
                            =========
                            """);
            foreach (var item in fashionProducts)
            {
                Console.WriteLine($"{item.ProductCode,-12}  | {item.ProductName,-40} | {item.ProductPrice,-10}");
            }

            Console.WriteLine("""
                            ELECTRONICS
                            =========
                            """);
            foreach (var item in electronicProducts)
            {
                Console.WriteLine($"{item.ProductCode,-12}  | {item.ProductName,-40} | {item.ProductPrice,-10}");
            }

            Console.WriteLine("""
                            GROCERIES
                            =========
                            """);
            foreach (var item in groceryProducts)
            {
                Console.WriteLine($"{item.ProductCode,-12}  | {item.ProductName,-40} | {item.ProductPrice,-10}");
            }
        }
}}