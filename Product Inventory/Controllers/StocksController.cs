using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductInventory.APPLICATION.Interfaces;
using ProductInventory.DOMAIN.Dto;
using ProductInventory.DOMAIN.Model;

namespace Product_Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StocksController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStock([FromQuery] int storeId, [FromQuery] int productId)
        {
            var stock = await _stockService.GetStockAsync(storeId, productId);

            if (stock == null)
            {
                return NotFound(new ApiResponse<object>(404, "Stock information not found for the given Store and Product."));
            }

            return Ok(new ApiResponse<StockResponseDto>(200, "Stock retrieved successfully", stock));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockRequestdto request)
        {
            try
            {
                var success = await _stockService.UpdateStockAsync(request);

                if (!success)
                {
                    return NotFound(new ApiResponse<object>(404, "Store or Product not found, or update failed."));
                }

                var updatedStock = await _stockService.GetStockAsync(request.StoreId, request.ProductId);
                return Ok(new ApiResponse<StockResponseDto>(200, "Stock updated successfully", updatedStock));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ApiResponse<object>(400, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(500, "An error occurred while updating stock.", ex.Message));
            }
        }
    }
}
