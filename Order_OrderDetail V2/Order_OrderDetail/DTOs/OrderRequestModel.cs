using Order_OrderDetail.Entities;

namespace Order_OrderDetail.DTOs
{
    public class OrderRequestModel
    {
        public string location { get; set; }
        public List<OrderDetailRequestModel> OrderDetails { get; set; }

    }
}
