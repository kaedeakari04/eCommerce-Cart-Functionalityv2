using System;
namespace eCommerceCartFunctionality
{
    internal class Program
    {
        //static string cart = "empty";
        static string[] userCart = new string[99];
        static string[] productType = { "Fashion", "Electronics", "Groceries" };
        static string[] productName = {"Uniqlo Ultra Light Jacket", "Nike Air Max 270", "Samsung Galaxy Watch8 Smartwatch",
            "HUAWEI MatePad 11.5\" Tablet", "Nescafé Gold Coffee", "Jack N' Jill Cloud 9 Classic Bars"};
        static int[] productPrice = { 2490, 7000, 21890, 14499, 350, 165 };
        static int productQuantity = 0;

        static void Main(string[] args)
        {
            //TITLE STUFF 
            Console.WriteLine("E-Commerce App  |  CART FUNCTIONALITY\n===============================");
            productList();
            Console.WriteLine("===============================\n-- SELECT A COMMAND --" + "\nA | Add Item\nB | Remove Item \nC | View Cart");
            //MAIN BLOCK STUFF
            string userInput;

            Console.Write("===============================\nENTER A COMMAND: ");
            userInput = Console.ReadLine();
            Console.WriteLine();
            switch (userInput)
            {
                case "A":
                case "a":
                    addItem();
                    toAddMoreItem();
                    break;
                case "B":
                case "b":
                    removeItem();
                    break;
                case "C":
                case "c":
                    viewCart();
                    break;
                default:
                    Console.WriteLine("INVALID COMMAND. SYSTEM WILL EXIT...");
                    Environment.Exit(0);
                    break;
            }
        }

        static bool toAddMoreItem()
        {
            Console.Write("ADD MORE ITEMS? (Y/N): ");
            string addMoreInput = Console.ReadLine();

            bool addMore = false;

            while (addMore)
            {
                switch (addMoreInput)
                {
                    case "Y":
                    case "y":
                        addMore = true;
                        break;
                    case "N":
                    case "n":
                        addMore = false;
                        break;
                    default:
                        Console.WriteLine("INVALID INPUT. SYSTEM WILL NOW EXIT...");
                        Environment.Exit(0);
                        break;
                }
            }

            return addMore;
        }
        static void productList()
        {
            //Dis is for my reference, Im gon use to add items to the cart
            Console.WriteLine("--- PRODUCTS ---\n=========");
            Console.WriteLine("FASHION\n> Uniqlo Ultra Light Jacket  |  Php2,490\n> Nike Air Max 270  |  Php7,000\n=========");
            Console.WriteLine("ELECTRONICS\n> Samsung Galaxy Watch8 Smartwatch  |  Php21,890\n> HUAWEI MatePad 11.5\" Tablet  |  Php14,499\n=========");
            Console.WriteLine("GROCERIES\n> Nescafé Gold Coffee   | Php350\n> Jack N' Jill Cloud 9 Classic Bars  |  Php165");
        }
        static void addItem()
        {
            Console.Write("PRODUCT TYPE: ");
            string productTypeInput = Console.ReadLine();
            Console.Write("PRODUCT NAME: ");
            string productNameInput = Console.ReadLine();
            Console.Write("QUANTITY: ");
            int productQuantityInput = Console.Read();
        }

        static void removeItem()
        {
        }

        static void viewCart()
        {
        }
    }
}