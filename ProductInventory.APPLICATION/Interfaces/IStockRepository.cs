using ProductInventory.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.APPLICATION.Interfaces
{
    public interface IStockRepository
    {
        Task<StockModel> GetStockAsync(int storeId, int productId);
        Task<int> UpdateStockAsync(int storeId, int productId, int newStockLevel);
    }
}
