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

        public async Task<StockResponseDto> GetStockAsync(int storeId, int productId)
        {
            var stock = await _repository.GetStockAsync(storeId, productId);

            if (stock == null) return null;

            return new StockResponseDto
            {
                Store = new StoreDto
                {
                    StoreId = stock.StoreId,
                    StoreName = stock.StoreName,
                    Address = stock.Address
                },
                Product = new ProductDto
                {
                    ProductId = stock.ProductId,
                    ProductName = stock.ProductName,
                    Category = stock.Category
                },
                StockLevel = stock.StockLevel
            };
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
