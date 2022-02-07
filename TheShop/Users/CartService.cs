using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class CartService
    {

        public List<ShoppingCart> userShoppingCart = new();

        public void UserShoppingCartAdd(List<Products> listToAddFrom, int productBarcode, double quantityToBuy)
        {
            foreach (var item in listToAddFrom)
            {
                if (item.ProductBarcode == productBarcode)
                {
                    userShoppingCart.Add(new ShoppingCart(item.ProductName, item.ProductBarcode, Math.Round(item.ProductQuantity * quantityToBuy, 3), item.ProductUnits, item.ProductPrice, Math.Round(item.ProductPrice * quantityToBuy, 2)));
                }
            }
        }

        public string UserShoppingCartRemove(int productBarcode)
        {
            string messageSuccess = "";
            foreach (var item in userShoppingCart)
            {
                if (item.ProductToBuyBarcode == productBarcode)
                {
                    userShoppingCart.Remove(item);
                    messageSuccess = "Selected product removed";
                }
            }
            return messageSuccess;
        }

        public void PrintShoppingCart()
        {
            foreach (var item in userShoppingCart)
            {
                Console.WriteLine();
                Console.WriteLine($"{item.ProductToBuyName} {item.ProductToBuyBarcode} {item.QuantityToCart} {item.ProductToBuyPrice}/{item.UnitsProductToBuy} {item.PriceToCart}");
            }
        }

        public void PrintShoppingCartAdvanced()
        {
            int i = 2;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Product name");
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("Product Barcode");
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("Quantity To Buy");
            Console.SetCursorPosition(60, 0);
            Console.WriteLine("Price / Unit");
            Console.SetCursorPosition(80, 0);
            Console.WriteLine("Price");
            foreach (var item in userShoppingCart)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine($"{item.ProductToBuyName}");
                Console.SetCursorPosition(20, i);
                Console.WriteLine($"{item.ProductToBuyBarcode}");
                Console.SetCursorPosition(40, i);
                Console.WriteLine($"{item.QuantityToCart}");
                Console.SetCursorPosition(60, i);
                Console.WriteLine($"{item.ProductToBuyPrice}/{item.UnitsProductToBuy}");
                Console.SetCursorPosition(80, i);
                Console.WriteLine($"{item.PriceToCart}");
                i = i + 1;
            }
        }

        public double UserShoppingCartTotalSumToPay()
        {
            double sum = 0;
            foreach (var item in userShoppingCart)
            {
                sum = sum + item.PriceToCart;
            }
            return sum;
        }

        public void UserShoppingReceipt()
        {
            Console.Clear();
            double sumTotal = UserShoppingCartTotalSumToPay();
            PrintShoppingCartAdvanced();
            Console.WriteLine();
            Console.Write($"Total sum to pay:");
            Console.SetCursorPosition(80, Console.CursorTop);
            Console.WriteLine($"{sumTotal}");
        }
    }
}
