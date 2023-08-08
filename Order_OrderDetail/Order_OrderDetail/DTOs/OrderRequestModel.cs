using Order_OrderDetail.Entities;

namespace Order_OrderDetail.DTOs
{
    public class OrderRequestModel
    {
        public int ID_ORDER { get; set; }
        public string LOCATION { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public int ITEM_COUNT { get; set; }
        public decimal ORDER_PRICE { get; set; }
        public List<OrderDetailRequestModel> OrderDetails { get; set; }

    }
}
