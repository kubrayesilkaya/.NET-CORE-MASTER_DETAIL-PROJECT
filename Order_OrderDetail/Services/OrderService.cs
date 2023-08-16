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

        public List<OrderEntity> GetOrderDetail()
        {
            return _dbContext.Orders.ToList();
        }

        //GET By ID***********************************************************

        public OrderEntity GetOrderDetail(int id)
        {
            var orderAndDetail = _dbContext.Orders
                .Where(o => o.ID_ORDER == id)
                .Include(o => o.OrderDetails)
                .FirstOrDefault();

            return orderAndDetail;
        }
    }
}
