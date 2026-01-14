using ProductInventory.APPLICATION.Interfaces;
using ProductInventory.DOMAIN.Dto;
using ProductInventory.DOMAIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.APPLICATION.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _repository;

        public StockService(IStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<StockModel> GetStockAsync(int storeId, int productId)
        {
            return await _repository.GetStockAsync(storeId, productId);
        }

        public async Task<bool> UpdateStockAsync(UpdateStockRequestdto request)
        {
            if (request.NewStockLevel < 0)
            {
                throw new ArgumentException("Stock level cannot be less than zero.");
            }

            var result = await _repository.UpdateStockAsync(request.StoreId, request.ProductId, request.NewStockLevel);

            if (result == -1)
            {
                return false;
            }

            return true;
        }
    }
}
