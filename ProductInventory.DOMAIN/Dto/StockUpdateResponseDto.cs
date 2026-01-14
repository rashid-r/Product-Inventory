namespace ProductInventory.DOMAIN.Dto
{
    public class StockUpdateResponseDto
    {
        public string Message { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int UpdatedStockLevel { get; set; }
    }
}
