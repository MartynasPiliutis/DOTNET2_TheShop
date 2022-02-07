using System;
using System.Collections.Generic;

namespace TheShop
{
    static class Program
    {
        public static void Main(string[] _)
        {
            RepositoryService repositoryService = new();
            DrinksRepository drinksRepository = new();
            MeatRepository meatRepository = new();
            SweetsRepository sweetsRepository = new();
            VegetablesRepository vegetablesRepository = new();
            CartService cartService = new();
            UserService userService = new();
            List<Products> allList = new();
            allList = repositoryService.LoadBackendProductsList(drinksRepository.drinks, meatRepository.meat, sweetsRepository.sweets, vegetablesRepository.vegetables);

            double userWallet;
            int userSelectedListToBuyFrom;

            userWallet = DialogWelcomeToTheShop();
            int walletCheckCode = userService.UserValletCheckWhenEnterTheShop(userWallet);
            DialogUserWalletCheckMenuLoad(walletCheckCode, allList, repositoryService);
            userWallet = Math.Round(userWallet, 2);
            userSelectedListToBuyFrom = MainMenuLoadAndListSelection(repositoryService, userWallet);
            LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userSelectedListToBuyFrom, userWallet, cartService);

            static void LoadMenuToAddProductsToCart(RepositoryService repositoryService, DrinksRepository drinksRepository, MeatRepository meatRepository, SweetsRepository sweetsRepository, VegetablesRepository vegetablesRepository, int userMainMenuSelection, double userWalletTemp, CartService cartService)
            {
                List<Products> listToSelectProductsFrom = new();
                int userProductsListMenuSelection;
                double quantityToAddToCart;

                if (userMainMenuSelection == 0)
                {
                    Console.Clear();
                    userProductsListMenuSelection = MainMenuLoadAndListSelection(repositoryService, userWalletTemp);
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
                    userProductsListMenuSelection = RemoveProductsFromCurrentShopingCart(cartService);
                    LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userProductsListMenuSelection, userWalletTemp, cartService);
                }
                else if (userMainMenuSelection == 5)
                {
                    cartService.UserShoppingReceipt();
                    Environment.Exit(0);
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

            static int MainMenuLoadAndListSelection(RepositoryService repositoryService, double userWalletInput)
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

            static double DialogWelcomeToTheShop()
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

            static void DialogUserWalletCheckMenuLoad(int walletCheckCode, List<Products> listOfAllProducts, RepositoryService repositoryService)
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

            static int RemoveProductsFromCurrentShopingCart(CartService cartService)
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
}