using System;
using System.Collections.Generic;

namespace Repository
{
    public class InventoryRepository : IInventoryRepository
    {
        private const string ErrorMessage = "Could not connect to inventory database";

        public int GetNumberOfProductItems(int productId)
        {
            throw new Exception(ErrorMessage);
        }

        public bool ProductExists(int productId)
        {
            throw new Exception(ErrorMessage);
        }

        public void SetNumberOfAvailableProductItems(int productId, int numberOfItems)
        {
            throw new Exception(ErrorMessage);
        }

        public string GetProductName(int productId)
        {
            throw new Exception(ErrorMessage);
        }

        public List<int> GetAllProductIds()
        {
            throw new Exception(ErrorMessage);
        }
    }
}
