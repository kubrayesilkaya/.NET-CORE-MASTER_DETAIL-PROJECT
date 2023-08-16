namespace Order_OrderDetail.DTOs
{
    public class OrderDetailResponseModel
    {
        public int ID_ORDER { get; set; }
        public int ORDER_DETAIL_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public int ITEM_QUANTITY { get; set; }
        public string ITEM_UNIT { get; set; }
        public decimal ORDER_PRICE { get; set; }
        public string LOCATION { get; set; }
    }
}
