namespace Order_OrderDetail.DTOs
{
    public class OrderDetailRequestModel
    {
        public int ORDER_DETAIL_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public int ITEM_QUANTITY { get; set; }
        public string ITEM_UNIT { get; set; }
        public int ID_ORDER { get; set; }
        //public int PRODUCT_PRICE { get; set; }
        //public OrderRequestModel Order { get; set; }
    }
}
