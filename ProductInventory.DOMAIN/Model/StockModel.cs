using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.DOMAIN.Model
{
    public class StockModel
    {
        public int StockId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int StockLevel { get; set; }
        public string StoreName { get; set; }
        public string ProductName { get; set; }
    }
}
