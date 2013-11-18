using System.Collections.Generic;

namespace Repository
{
    public interface IInventoryRepository
    {
        int GetNumberOfProductItems(int productId);
        bool ProductExists(int productId);
        void SetNumberOfAvailableProductItems(int productId, int numberOfItems);
        string GetProductName(int productId);
        List<int> GetAllProductIds();
    }
}