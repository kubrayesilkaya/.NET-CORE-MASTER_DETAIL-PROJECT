﻿using Microsoft.EntityFrameworkCore;
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
            var _order = _dbContext.Order.FirstOrDefault(o => o.ID_ORDER == orderRequestModel.ID_ORDER);

            if (_order != null)
            {
                return "Sipariş daha önce kaydedilmiş.";
            }

            OrderEntity orderEntity = new OrderEntity();
            orderEntity.LOCATION = orderRequestModel.LOCATION;
            orderEntity.ORDER_DATE = orderRequestModel.ORDER_DATE;
            orderEntity.ITEM_COUNT = orderRequestModel.ITEM_COUNT;
            orderEntity.ORDER_PRICE = orderRequestModel.ORDER_PRICE;


            _dbContext.Order.Add(orderEntity);
            _dbContext.SaveChanges();


            return "Sipariş kaydedildi.";
        }

        //GET****************************************************************

        public List<OrderEntity> GetOrderDetail()
        {
            return _dbContext.Order.ToList();
        }


    }
}