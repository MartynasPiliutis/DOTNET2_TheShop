namespace TheShop
{
    public class Meat : Products
    {
        public Meat (
            string meatName,
            string meatClass,
            int meatBarcode,
            double meatQuantity,
            string meatUnits,
            double meatPrice
            )
        : base (
            meatName,
            meatClass,
            meatBarcode,
            meatQuantity,
            meatUnits,
            meatPrice
            )
        { }
    }
}
