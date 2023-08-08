using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Order_OrderDetail.Entities
{
    public class OrderEntity
    {
        [Key]
        public int ID_ORDER { get; set; }
        public string LOCATION { get; set; }
        //[Column(TypeName = "Date")]
        public DateTime ORDER_DATE { get; set; }
        public int ITEM_COUNT { get;set; }
        public decimal ORDER_PRICE { get; set; }
    }
}
