using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Order_OrderDetail.DATA;
using Order_OrderDetail.DTOs;
using Order_OrderDetail.Entities;
using Order_OrderDetail.Services;

namespace Order_OrderDetail.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderDBContext _dbcontext;
        private readonly OrderService _orderService;

        public OrderController(OrderDBContext dbcontext, OrderService orderService)
        {
            _dbcontext = dbcontext;
            _orderService = orderService;
        }

        //POST********************************************************************************************

        [Route("[action]")]
        [HttpPost]
        public ActionResult<IEnumerable<string>> AddOrder([FromBody] OrderRequestModel orderRequestModel)
        {
            var response = _orderService.AddOrder(orderRequestModel);

            return Ok(response);
        }

        //GET**********************************************************************************************

        [Route("[action]")]
        [HttpGet]
        public IActionResult GetOrderDetail()
        {
            var orders = _orderService.GetOrderDetail();
            return Ok(orders);
        }

        //GET by ID*****************************************************************************************

        [Route("[action]/{id}")]
        [HttpGet]
        public ActionResult<OrderEntity> GetOrderDetail(int id)
        {
            var order = _orderService.GetOrderDetail(id);
            return Ok(order);
        }
    }
}
