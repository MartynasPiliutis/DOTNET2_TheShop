using System;
using System.Collections.Generic;
using System.IO;

namespace TheShop
{
    static class Program
    {
        public static void Main(string[] _)
        {
            MenuActions menuAct = new();
            MenuActionsLoading menuLoad = new();

            RepositoryService repositoryService = new();
            DrinksRepository drinksRepository = new();
            MeatRepository meatRepository = new();
            SweetsRepository sweetsRepository = new();
            VegetablesRepository vegetablesRepository = new();

            CartService cartService = new();
            UserService userService = new();
            List<Products> allList = new();
            allList = repositoryService.ListLoadAllProductToReview(drinksRepository.drinks, meatRepository.meat, sweetsRepository.sweets, vegetablesRepository.vegetables);

            double userWallet;
            int userSelectedListToBuyFrom;

            userWallet = menuAct.DialogWelcomeToTheShop();
            int walletCheckCode = userService.UserServiceCheckIfUserHasMoney(userWallet);
            menuAct.DialogUserWalletCheckMenuLoad(walletCheckCode, allList, repositoryService);
            userWallet = Math.Round(userWallet, 2);
            userSelectedListToBuyFrom = menuLoad.LoadMainMenu(repositoryService, userWallet);
            menuLoad.LoadMenuToAddProductsToCart(repositoryService, drinksRepository, meatRepository, sweetsRepository, vegetablesRepository, userSelectedListToBuyFrom, userWallet, cartService);
        }

    }
}