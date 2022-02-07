namespace TheShop
{
    public class Products
    {
        public string ProductName { get; private set; }
        public string ProductClass { get; private set; }
        public int ProductBarcode { get; private set; }
        public double ProductQuantity { get; private set; }
        public string ProductUnits { get; private set; }
        public double ProductPrice { get; private set; }

        public Products(string productName, string productClass, int productBarcode, double productQuantity, string productUnits, double productPrice)
        {
            ProductName = productName;
            ProductClass = productClass;
            ProductBarcode = productBarcode;
            ProductQuantity = productQuantity;
            ProductUnits = productUnits;
            ProductPrice = productPrice;
        }

    }
}
