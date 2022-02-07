using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class MenuActionsLoading
    {
        public void LoadMenuToAddProductsToCart(RepositoryService repositoryService, DrinksRepository drinksRepository, MeatRepository meatRepository, SweetsRepository sweetsRepository, VegetablesRepository vegetablesRepository, int userMainMenuSelection, double userWalletTemp, CartService cartService)
        {
            List<Products> listToSelectProductsFrom = new();
            MenuActions menuActions = new();
            int userProductsListMenuSelection;
            double quantityToAddToCart;

            if (userMainMenuSelection == 0)
            {
                Console.Clear();
                userProductsListMenuSelection = LoadMainMenu(repositoryService, userWalletTemp);
                LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userProductsListMenuSelection, userWalletTemp, cartService);
            }
            if (userMainMenuSelection == 1)
            {
                repositoryService.PrintSelectedRepositoryList(drinksRepository.drinks);
                listToSelectProductsFrom = drinksRepository.drinks;
            }
            if (userMainMenuSelection == 2)
            {
                repositoryService.PrintSelectedRepositoryList(meatRepository.meat);
                listToSelectProductsFrom = meatRepository.meat;
            }
            if (userMainMenuSelection == 3)
            {
                repositoryService.PrintSelectedRepositoryList(sweetsRepository.sweets);
                listToSelectProductsFrom = sweetsRepository.sweets;
            }
            if (userMainMenuSelection == 4)
            {
                repositoryService.PrintSelectedRepositoryList(vegetablesRepository.vegetables);
                listToSelectProductsFrom = vegetablesRepository.vegetables;
            }
            if (userMainMenuSelection == 6)
            {
                Console.Clear();
                userProductsListMenuSelection = menuActions.RemoveProductsFromCurrentShopingCart(cartService);
                LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userProductsListMenuSelection, userWalletTemp, cartService);
            }
            else if (userMainMenuSelection == 5)
            {
                ExitOrBuyShoppingCartAndLeave(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userWalletTemp, cartService);
            }

            Console.WriteLine();
            Console.WriteLine("To add product to cart please enter the barcode.");
            Console.WriteLine("To select another products section or menu action, please enter number from below...");
            Console.WriteLine("[1] - DRINKS   [2] - MEAT   [3] - SWEETS   [4] - VEGETABLES   [5] - EXIT   [0] - MAIN MENU   [6] - REMOVE PRODUCTS FROM CART");
            Console.Write("Your input: ");
            userProductsListMenuSelection = repositoryService.ProductsListMenuSelection(Console.ReadLine());
            if (0 <= userProductsListMenuSelection && 6 >= userProductsListMenuSelection)
            {
                LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userProductsListMenuSelection, userWalletTemp, cartService);
            }
            else
            {
                foreach (var item in listToSelectProductsFrom)
                {
                    if (userProductsListMenuSelection == item.ProductBarcode)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Our selected product is: {item.ProductName}");
                        Console.Write("Please enter quantity of the product you are buying: ");
                        quantityToAddToCart = repositoryService.SelectedProductQuantityCheck(listToSelectProductsFrom, item.ProductBarcode, Console.ReadLine());
                        cartService.UserShoppingCartAdd(listToSelectProductsFrom, item.ProductBarcode, quantityToAddToCart);
                    }
                }
                Console.Clear();
                cartService.PrintShoppingCartAdvanced();
                Console.WriteLine("Product added. Pressany key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userMainMenuSelection, userWalletTemp, cartService);
        }

        private void ExitOrBuyShoppingCartAndLeave(RepositoryService repositoryService, DrinksRepository drinksRepository, MeatRepository meatRepository, SweetsRepository sweetsRepository, VegetablesRepository vegetablesRepository, double userWalletTemp, CartService cartService)
        {
            cartService.UserShoppingReceipt();
            Console.WriteLine();
            Console.WriteLine("Would you like to buy these products?");
            Console.WriteLine("To buy pres [y]. If you want to drop the cart and leave, pres [n]");
            Console.Write("Your input: ");
            string finalResponse = Convert.ToString(Console.ReadKey().KeyChar);
            if (finalResponse == "n" || finalResponse == "N")
            {
                Environment.Exit(0);
            }
            else if (finalResponse == "y" || finalResponse == "Y")
            {
                double totalSum = cartService.UserShoppingCartTotalSumToPay();
                double userCashAvailable = userWalletTemp;
                if (userCashAvailable >= totalSum)
                {
                    cartService.UserShoppingReceipt();
                    Console.WriteLine();
                    Console.WriteLine("Thank you dfor buying. Your receipt above.");
                    Console.WriteLine($"Your balance: {userCashAvailable - totalSum}");
                    DateTime timeForFileName = new();
                    timeForFileName = DateTime.Now;
                    string filename = timeForFileName.Year.ToString() + timeForFileName.Month.ToString() + timeForFileName.Day.ToString() + timeForFileName.Hour.ToString() + timeForFileName.Minute.ToString();
                    filename = filename + ".txt";
                    string path = DataFiles.receipts + filename;
                    FileStream fs = new FileStream(path, FileMode.Create);
                    TextWriter tmpTxt = Console.Out;
                    StreamWriter sw = new StreamWriter(fs);
                    Console.SetOut(sw);
                    cartService.UserShoppingReceiptPrintToFile();
                    Console.SetOut(tmpTxt);
                    sw.Close();
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);

                }
            }
            else
            {
                int userProductsListMenuSelection = 5;
                LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userProductsListMenuSelection, userWalletTemp, cartService);
            }
        }

        public int LoadMainMenu(RepositoryService repositoryService, double userWalletInput)
        {
            string userMenuSelectionInputString = "";
            int userMenuSelectionInput;
            userMenuSelectionInputString = repositoryService.MainMenuSelectProductsSection(userWalletInput);

            while (!Int32.TryParse(userMenuSelectionInputString, out userMenuSelectionInput) || 1 > userMenuSelectionInput || 6 < userMenuSelectionInput)
            {
                Console.Clear();
                Console.WriteLine("Incorrect selection... Please try again!");
                Console.WriteLine();
                userMenuSelectionInputString = repositoryService.MainMenuSelectProductsSection(userWalletInput);
            }
            return userMenuSelectionInput;
        }
    }
}
