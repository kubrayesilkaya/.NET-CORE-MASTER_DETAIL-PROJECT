using Microsoft.EntityFrameworkCore;
using Order_OrderDetail.Entities;
using Order_OrderDetail.DTOs;
using Order_OrderDetail.DATA;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace Order_OrderDetail.Services
{
    public class OrderService
    {
        private readonly OrderDBContext _dbContext;

        public OrderService(OrderDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add 

        //POST*************************************************************
        public string AddOrder(OrderRequestModel orderRequestModel)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (orderRequestModel.OrderDetails == null || orderRequestModel.OrderDetails.Count() == 0)
                    {
                        return "Sipariş Kalemleri Eksiktir!";
                    }

                    OrderEntity orderEntity = new OrderEntity();

                    orderEntity.LOCATION = orderRequestModel.location;
                    orderEntity.ORDER_DATE = DateTime.Now;
                    orderEntity.ITEM_COUNT = orderRequestModel.OrderDetails.Sum(x => x.itemQuantity);
                    orderEntity.ORDER_PRICE = orderRequestModel.OrderDetails.Sum(x => x.productPrice * x.itemQuantity);

                    _dbContext.Orders.Add(orderEntity);
                    _dbContext.SaveChanges();

                    //int value = Convert.ToInt32("value");

                    List<OrderDetailEntity> tempOrderDetail = new List<OrderDetailEntity>();


                    foreach (var order_detail in orderRequestModel.OrderDetails)
                    {

                        OrderDetailEntity orderDetailEntity = new OrderDetailEntity();

                        orderDetailEntity.ITEM_NAME = order_detail.itemName;
                        orderDetailEntity.ITEM_QUANTITY = order_detail.itemQuantity;
                        orderDetailEntity.ITEM_UNIT = order_detail.itemUnit;
                        orderDetailEntity.PRODUCT_PRICE = order_detail.productPrice;
                        orderDetailEntity.ID_ORDER = orderEntity.ID_ORDER;

                        tempOrderDetail.Add(orderDetailEntity);
                    }

                    _dbContext.OrderDetails.AddRange(tempOrderDetail);
                    _dbContext.SaveChanges();


                    transaction.Commit();
                    return "Sipariş kaydedildi.";
                }
                catch (Exception ex)
                {
                    transaction.Dispose(); // = transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    return "Sipariş kaydedilirken hata oluştu; sipariş kaydedilemedi!";
                }
            }
        }
        #endregion


        #region Getv1
        //GET By ID***********************************************************

        public OrderEntity GetOrderDetail(int id)
        {
            var orderAndDetail = _dbContext.Orders
                .Where(o => o.ID_ORDER == id)
                .Include(o => o.OrderDetails)
                .FirstOrDefault();

            return orderAndDetail;
        }
        #endregion

        #region GetV2

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
        #endregion


    }
}