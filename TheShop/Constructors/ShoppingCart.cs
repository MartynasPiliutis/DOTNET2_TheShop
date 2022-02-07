using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheShop
{
    public class ShoppingCart
    {
        public string ProductToBuyName { get; set; }
        public int ProductToBuyBarcode { get; set; }
        public double QuantityToCart { get; set; }
        public string UnitsProductToBuy { get; set; }
        public double ProductToBuyPrice { get; set; }
        public double PriceToCart { get; set; }
        public ShoppingCart(string productToBuyName, int productToBuyBarcode, double quantityToCart, string unitsProductToBuy, double productToBuyPrice, double priceToCart)
        {
            ProductToBuyName = productToBuyName;
            ProductToBuyBarcode = productToBuyBarcode;
            QuantityToCart = quantityToCart;
            UnitsProductToBuy = unitsProductToBuy;
            ProductToBuyPrice = productToBuyPrice;
            PriceToCart = priceToCart;
        }

    }
}
