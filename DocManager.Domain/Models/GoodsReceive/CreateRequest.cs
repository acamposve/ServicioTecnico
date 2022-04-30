using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioTecnico.Domain.Models.GoodsReceive
{
    public class CreateRequest
    {
        public string Description { get; set; }
        public DateTimeOffset? GoodsReceiveDate { get; set; } = DateTime.Now;
        public Guid PurchaseOrderId { get; set; }
    }
}
