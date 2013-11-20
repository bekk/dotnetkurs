using System;
using System.Collections.Generic;
using ExcelExport;
using Repository;

namespace Service
{
    public class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;
         
        public InventoryService()
        {
            _inventoryRepository = new InventoryRepository();
        }

        public List<int> GetProducts()
        {
            return _inventoryRepository.GetAllProductIds();
        }
    }
}
