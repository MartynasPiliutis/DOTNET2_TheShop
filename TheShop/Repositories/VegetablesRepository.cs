using System.Collections.Generic;

namespace TheShop
{
    public class VegetablesRepository
    {
        public readonly List<Products> vegetables;
        public VegetablesRepository()
        {
            vegetables = new List<Products>();
            FileService.FileReaderService(vegetables, DataFiles.vegetablesFile);
        }
    }
}
