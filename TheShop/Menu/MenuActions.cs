using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class MenuActions
    {
        public double DialogWelcomeToTheShop()
        {
            double userWallet;
            Console.WriteLine("Hi! Welcome to my shop. How much cash do you have?");
            Console.Write("Cash: ");
            string userCashInput = Console.ReadLine();
            userCashInput = userCashInput.Replace(',', '.');
            while (!Double.TryParse(userCashInput, out userWallet))
            {
                Console.Clear();
                Console.WriteLine($"Hey!? What da heck is this? What do think you would buy buy with {userCashInput}?");
                Console.WriteLine("Think again!");
                Console.Write("Cash: ");
                userCashInput = Console.ReadLine();
                userCashInput = userCashInput.Replace(',', '.');
            }

            return userWallet;
        }

        public void DialogUserWalletCheckMenuLoad(int walletCheckCode, List<Products> listOfAllProducts, RepositoryService repositoryService)
        {
            if (walletCheckCode == 1)
            {
                Console.WriteLine("Very good. So, what do you want?");
                Console.WriteLine();
            }
            else
            {

                Console.WriteLine("Oh... OK, you can look around. But dont touch anything!");
                Console.WriteLine();
                repositoryService.PrintSelectedRepositoryList(listOfAllProducts);
                Console.WriteLine();
                Console.WriteLine("Press any key to Exit...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public int RemoveProductsFromCurrentShopingCart(CartService cartService)
        {
            int userSelectionInput;
            string productRemovedSucess = "";
            cartService.PrintShoppingCartAdvanced();
            Console.WriteLine();
            Console.WriteLine("To remove product from cart please enter the barcode.");
            Console.WriteLine("To select menu action, please enter number from below...");
            Console.WriteLine("[0] - MAIN MENU   [5] - EXIT");
            Console.Write("Your input: ");
            string productToRemove = Console.ReadLine();
            while (!Int32.TryParse(productToRemove, out userSelectionInput))
            {
                Console.WriteLine("Wrong input. Try again...");
                Console.Write("Your input: ");
                productToRemove = Console.ReadLine();
            }
            if (userSelectionInput == 0)
            {
                return userSelectionInput;
            }
            else if (userSelectionInput == 5)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                productRemovedSucess = cartService.UserShoppingCartRemove(userSelectionInput, cartService.userShoppingCart);
                cartService.PrintShoppingCartAdvanced();
                if (productRemovedSucess != "")
                {
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to main menu...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No products were removed from the shopping cart...");
                    Console.WriteLine("Press any key to return to main menu...");
                    Console.ReadKey();
                }

            }
            return 0;
        }

    }
}
