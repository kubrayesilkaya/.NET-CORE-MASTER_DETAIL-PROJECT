using Microsoft.EntityFrameworkCore;
using Order_OrderDetail.Entities;
using Order_OrderDetail.DTOs;
using Order_OrderDetail.DATA;
using System.Collections.Generic;
using System.Linq;

namespace Order_OrderDetail.Services
{
    public class OrderService
    {
        private readonly OrderDBContext _dbContext;

        public OrderService(OrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //POST*************************************************************
        public string AddOrder(OrderRequestModel orderRequestModel)
        {
            var _order = _dbContext.Orders.FirstOrDefault(o => o.ID_ORDER == orderRequestModel.ID_ORDER);

            if (_order != null)
            {
                return "Sipariş daha önce kaydedilmiş.";
            }

            OrderEntity orderEntity = new OrderEntity();

            orderEntity.LOCATION = orderRequestModel.LOCATION;
            orderEntity.ORDER_DATE = orderRequestModel.ORDER_DATE;
            orderEntity.ITEM_COUNT = orderRequestModel.ITEM_COUNT;
            orderEntity.ORDER_PRICE = orderRequestModel.ORDER_PRICE;

            _dbContext.Orders.Add(orderEntity);
            _dbContext.SaveChanges();

            List<OrderDetailEntity> tempOrderDetail = new List<OrderDetailEntity>();

            foreach (var order_detail in orderRequestModel.OrderDetails)
            {

                    OrderDetailEntity orderDetailEntity = new OrderDetailEntity();

                    orderDetailEntity.ITEM_NAME = order_detail.ITEM_NAME;
                    orderDetailEntity.ITEM_QUANTITY = order_detail.ITEM_QUANTITY;
                    orderDetailEntity.ITEM_UNIT = order_detail.ITEM_UNIT;
                    orderDetailEntity.PRODUCT_PRICE = order_detail.PRODUCT_PRICE;
                    orderDetailEntity.ID_ORDER = orderEntity.ID_ORDER;

                //int countUniqueQuantity = 0;

                //if (orderDetailEntity.ITEM_QUANTITY >= 1)
                //    countUniqueQuantity++;

                //orderEntity.ITEM_COUNT = countUniqueQuantity;


                    orderEntity.ORDER_PRICE += (orderDetailEntity.ITEM_QUANTITY * orderDetailEntity.PRODUCT_PRICE);


                tempOrderDetail.Add(orderDetailEntity);


                //orderDetailEntity.PRODUCT_PRICE = order_detail.PRODUCT_PRICE;

                //ORDER_PRICE.OrderRequestModel += (ITEM_QUANTITY * PRODUCT_PRICE);

                //orderEntity.OrderDetails.Add(orderDetailEntity);
            }
            
            if(tempOrderDetail != null)
            {
                _dbContext.OrderDetails.AddRange(tempOrderDetail);
                _dbContext.SaveChanges();
            }


            return "Sipariş kaydedildi.";
        }

        //GET****************************************************************

        //public List<OrderEntity> GetOrderDetail()
        //{
        //    return _dbContext.Orders.ToList();
        //}

        //GET By ID***********************************************************

        public OrderEntity GetOrderDetail(int id)
        {
            var orderAndDetail = _dbContext.Orders
                .Where(o => o.ID_ORDER == id)
                .Include(o => o.OrderDetails)
                .FirstOrDefault();


            return orderAndDetail;
        }

        public List<OrderDetailResponseModel> GetOrderDetailv2(int id)
        {
            var list = (from a in _dbContext.Orders
                        where a.ID_ORDER == id
                        join b in _dbContext.OrderDetails
                             on a.ID_ORDER equals b.ID_ORDER into temp
                        from b in temp.DefaultIfEmpty()

                        select new OrderDetailResponseModel
                        {
                            id_order = a.ID_ORDER,
                            id_order_detail = b.ORDER_DETAIL_ID,
                            item_name = b.ITEM_NAME,
                            item_quantity = b.ITEM_QUANTITY,
                            item_unit = b.ITEM_UNIT,
                            total_price = a.ORDER_PRICE,
                            location = a.LOCATION,

                        }).ToList();


            return list;

        }

        //public IEnumerable<OrderEntity> GetOrderDetail(int id)
        //{
        //    var orderAndDetail = _dbContext.Orders
        //        .Where(o => o.ID_ORDER == id)
        //        .Include(o => o.OrderDetails)
        //        .FirstOrDefault();

        //    var orders = orderAndDetail.OrderDetails.Select(o => o.Order).ToList();

        //    return orders;
        //}



        //get metodu düzeltilecek,
        // item count konfigüre edilecek
    }
}
