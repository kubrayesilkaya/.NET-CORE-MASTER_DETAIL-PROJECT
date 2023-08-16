namespace Order_OrderDetail.DTOs
{
    public class OrderDetailResponseModel
    {
        public int id_order { get; set; }
        public int id_order_detail { get; set; }
        public string item_name { get; set; }
        public int item_quantity { get; set; }
        public string item_unit { get; set; }
        public decimal total_price { get; set; }
        public string customer_name { get; set; }
        public string location { get; set; }
    }
}
