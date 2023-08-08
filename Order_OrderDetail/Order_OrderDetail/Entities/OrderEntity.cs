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
        public ICollection<OrderDetailEntity> OrderDetails { get; set; } //principal (parent)

        //Bir Order'ın birden fazla orderDetail'i olabilir. Çoğul olduğu için OderDetails.

        //Order'ların birden fazla orderDetail'leri olabileceğinden dolayı, bu Order'a karşılık bir koleksiyon tanımladım,
        //ve bu koleksiyonun ismini de çoğul verdim. Çünkü bu Order'a ait tüm orderDetail'leri öğrenmek istiyor ise, 
        //bunu orderDetails proporty'sinden elde edeceğim.

        //orderDetails tekil olarak Order'a, Order ise çoğul olarak orderDetails'e bağlı. Bire-çok ilişki.
    }
}
