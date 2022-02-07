using System.Collections.Generic;

namespace TheShop
{
    internal class SweetsRepository
    {
        public readonly List<Products> sweets;
        public SweetsRepository()
        {
            sweets = new List<Products>();
            FileService.FileReaderService(sweets, DataFiles.sweetsFile);
        }
    }
}
