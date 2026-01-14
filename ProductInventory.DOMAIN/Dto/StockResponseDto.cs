namespace ProductInventory.DOMAIN.Dto
{
    public class StockResponseDto
    {
        public StoreDto Store { get; set; }
        public ProductDto Product { get; set; }
        public int StockLevel { get; set; }
    }

    public class StoreDto
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string Address { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
    }
}
