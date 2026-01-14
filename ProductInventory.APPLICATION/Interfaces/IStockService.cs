using ProductInventory.DOMAIN.Dto;
using ProductInventory.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.APPLICATION.Interfaces
{
    public interface IStockService
    {
        Task<StockModel> GetStockAsync(int storeId, int productId);
        Task<bool> UpdateStockAsync(UpdateStockRequestdto request);
    }
}
