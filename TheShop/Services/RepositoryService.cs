using System;
using System.Collections.Generic;

namespace TheShop
{
    public class RepositoryService
    {
        public void PrintRepositoryList(List<Products> listToPrint)
        {
            foreach (var item in listToPrint)
            {
                Console.WriteLine($"{item.ProductName} {item.ProductClass} {item.ProductBarcode} {item.ProductQuantity} {item.ProductUnits} {item.ProductPrice}");
            }

        }
        public List<Products> ListLoadAllProductToReview(List<Products> drinks, List<Products> vegetables, List<Products> sweets, List<Products> meat)
        {
            List<Products> backendList = new();
            AddProductsToList(drinks, backendList);
            AddProductsToList(vegetables, backendList);
            AddProductsToList(sweets, backendList);
            AddProductsToList(meat, backendList);
            return backendList;
        }

        public void AddProductsToList(List<Products> listToAdd, List<Products> listToUpdate)
        {
            foreach (var item in listToAdd)
            {
                listToUpdate.Add(new Products(item.ProductName, item.ProductClass, item.ProductBarcode, item.ProductQuantity, item.ProductUnits, item.ProductPrice));
            }
        }

        public void PrintSelectedRepositoryList(List<Products> listToPrint)
        {
            int i = 2;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Product name");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Product class");
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("Barcode");
            Console.SetCursorPosition(60, 0);
            Console.WriteLine("Quantity");
            Console.SetCursorPosition(80, 0);
            Console.WriteLine("Units");
            Console.SetCursorPosition(90, 0);
            Console.WriteLine("Price");
            foreach (var item in listToPrint)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine($"{item.ProductName}");
                Console.SetCursorPosition(20, i);
                Console.WriteLine($"{item.ProductClass}");
                Console.SetCursorPosition(40, i);
                Console.WriteLine($"{item.ProductBarcode}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{item.ProductQuantity}");
                Console.SetCursorPosition(80, i);
                Console.WriteLine($"{item.ProductUnits}");
                Console.SetCursorPosition(90, i);
                Console.WriteLine($"{item.ProductPrice}");
                i = i + 1;
            }
        }
        public string MainMenuSelectProductsSection(double userWalletInput)
        {
            string userSelectionInputTemp;
            Console.WriteLine($"Your wallet: {userWalletInput}");
            Console.WriteLine("Please select what products section you choose:");
            Console.WriteLine("[1] * Drinks");
            Console.WriteLine("[2] * Meat products");
            Console.WriteLine("[3] * Sweets");
            Console.WriteLine("[4] * Vegetables and Fruits");
            Console.WriteLine();
            Console.WriteLine("[5] * Exit shop");
            Console.WriteLine();
            Console.WriteLine("[6] * Remove product from shopping cart");


            userSelectionInputTemp = Convert.ToString(Console.ReadKey().KeyChar);
            return userSelectionInputTemp;
        }

        public int ProductsListMenuSelection(string userInput)
        {
            int userProductsListMenuSelection;
            while (!Int32.TryParse(userInput, out userProductsListMenuSelection))
            {
                Console.WriteLine("Incorrect selection... Please try again!");
                Console.Write("Your input: ");
                userInput = Console.ReadLine();
                userProductsListMenuSelection = ProductsListMenuSelection(userInput);
            }
            return userProductsListMenuSelection;
        }

        public double SelectedProductQuantityCheck(List<Products> listToSelectFrom, int selectedProductBarcode, string userQuantityInput)
        {
            double q;
            while (!Double.TryParse(userQuantityInput, out q))
            {
                Console.WriteLine("Incorrect quantity... Please try again!");
                Console.Write("Your input: ");
                userQuantityInput = Console.ReadLine();
                SelectedProductQuantityCheck(listToSelectFrom, selectedProductBarcode, userQuantityInput);
            }
            q = Math.Round(q, 3);

            foreach (var item in listToSelectFrom)
            {
                if (selectedProductBarcode == item.ProductBarcode)
                {
                    if (item.ProductUnits == "ltr" || item.ProductUnits == "pcs")
                    {
                        q = Math.Round(q, 0);
                    }
                }
            }
            return q;
        }

    }
}
