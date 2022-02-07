using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheShop
{
    internal class DataFiles
    {
        public static readonly string drinksFile = Path.GetFullPath(@"..\..\..\csvs\drinks.csv");
        public static readonly string meatFile = Path.GetFullPath(@"..\..\..\csvs\meat.csv");
        public static readonly string sweetsFile = Path.GetFullPath(@"..\..\..\csvs\sweets.csv");
        public static readonly string vegetablesFile = Path.GetFullPath(@"..\..\..\csvs\vegetables.csv");
        public static readonly string receipts = Path.GetFullPath(@"..\..\..\receipts\");
    }
}
