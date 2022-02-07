using System.Collections.Generic;

namespace TheShop
{
    internal class MeatRepository
    {
        public readonly List<Products> meat;
        public MeatRepository()
        {
            meat = new List<Products>();
            FileService.FileReaderService(meat, DataFiles.meatFile);
        }
    }
}
