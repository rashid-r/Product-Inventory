using Dapper;
using ProductInventory.APPLICATION.Interfaces;
using ProductInventory.DOMAIN.Model;
using ProductInventory.INFRASTRUCTURE.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.INFRASTRUCTURE.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly DapperContext _context;

        public StockRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<StockModel> GetStockAsync(int storeId, int productId)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("StoreId", storeId, DbType.Int32);
                parameters.Add("ProductId", productId, DbType.Int32);

                var stock = await connection.QuerySingleOrDefaultAsync<StockModel>(
                    "sp_GetStock",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return stock;
            }
        }

        public async Task<int> UpdateStockAsync(int storeId, int productId, int newStockLevel)
        {
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("StoreId", storeId, DbType.Int32);
                parameters.Add("ProductId", productId, DbType.Int32);
                parameters.Add("NewStockLevel", newStockLevel, DbType.Int32);

                var result = await connection.QuerySingleOrDefaultAsync<StockModel>(
                    "sp_UpdateStock",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );


                return result != null ? result.StockLevel : -1;
            }
        }
    }
}
