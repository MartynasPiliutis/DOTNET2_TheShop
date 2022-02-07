using System.Collections.Generic;

namespace TheShop
{
    internal class DrinksRepository
    {
        public readonly List<Products> drinks;

        public DrinksRepository()
        {
            drinks = new List<Products>();
            FileService.FileReaderService(drinks, DataFiles.drinksFile);
        }
    }
}
