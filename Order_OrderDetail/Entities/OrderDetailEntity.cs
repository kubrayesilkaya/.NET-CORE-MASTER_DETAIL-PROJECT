using System.ComponentModel.DataAnnotations;

namespace Order_OrderDetail.Entities
{
    public class OrderDetailEntity
    {
        [Key]
        public int ORDER_ID_DETAIL { get; set; }
        public string ITEM_NAME { get; set; }
        public int ITEM_QUANTITY { get; set; }
        public string ITEM_UNIT { get; set; }
        public int ID_ORDER { get; set; }

    }
}
