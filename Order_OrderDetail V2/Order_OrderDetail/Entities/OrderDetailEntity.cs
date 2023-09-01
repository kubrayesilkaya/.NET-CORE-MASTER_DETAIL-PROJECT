using System.ComponentModel.DataAnnotations;

namespace Order_OrderDetail.Entities
{
    public class OrderDetailEntity
    {
        [Key]
        public int ORDER_DETAIL_ID { get; set; }
        public string ITEM_NAME { get; set; }
        public int ITEM_QUANTITY { get; set; }
        public string ITEM_UNIT { get; set; }
        public int ID_ORDER { get; set; }
        public decimal PRODUCT_PRICE { get; set; }
        public OrderEntity Order { get; set; }


        // orderDetail 1 tane Order'a sahip. Order navigation proportysini tekil olarak oluşturuyorum.
        //
        // Oder ise orderDetail'e çoğul olarak bağlı.
        //
        //Her bir orderDetail'in sadece 1 tane Order'ı olacağından dolayı, Order isminde bir navigation proporty tanımladım
        //(ve tekil olacak şekilde tanımladım).
    }
}
