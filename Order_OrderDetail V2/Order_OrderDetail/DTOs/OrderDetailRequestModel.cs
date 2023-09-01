namespace Order_OrderDetail.DTOs
{
    public class OrderDetailRequestModel
    {
        public int orderDetailId { get; set; }
        public string itemName { get; set; }
        public int itemQuantity { get; set; }
        public string itemUnit { get; set; }
        public decimal productPrice { get; set; }
    }
}
