using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.DOMAIN.Dto
{
    public class UpdateStockRequestdto
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int NewStockLevel { get; set; }
    }
}
