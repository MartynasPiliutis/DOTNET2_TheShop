using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TheShop
{
    public class FileService
    {
        public static void FileReaderService(List<Products> productsList, string fileToRead)
        {
            var fileReader = File.ReadAllLines(fileToRead);
            List<string> listas = new();
            foreach (var item in fileReader)
            {
                listas.Add(item);
            }
            int linesCount = listas.Count;
            object[,] theGoods = new object[linesCount, 6];
            int lines = 0;

            foreach (var item in fileReader)
            {
                var split = item.Split(',');
                string productName = split[0];
                string productClass = split[1];
                string productBarcode = split[2];
                string productQuantity = split[3];
                string productUnits = split[4];
                string productPrice = split[5];
                theGoods[lines, 0] = productName;
                theGoods[lines, 1] = productClass;
                theGoods[lines, 2] = productBarcode;
                theGoods[lines, 3] = productQuantity;
                theGoods[lines, 4] = productUnits;
                theGoods[lines, 5] = productPrice;
                lines++;
            }

            for (int i = 1; i < linesCount; i++)
            {
                string productName = Convert.ToString(theGoods[i, 0]);
                string productClass = Convert.ToString(theGoods[i, 1]);
                int productBarcode = Convert.ToInt32(theGoods[i, 2]);
                double productQuantity = Convert.ToDouble(theGoods[i, 3]);
                string productUnits = Convert.ToString(theGoods[i, 4]);
                double productPrice = Convert.ToDouble(theGoods[i, 5]);
                productsList.Add(new Products(productName, productClass, productBarcode, productQuantity, productUnits, productPrice));
            }
        }

    }
}
