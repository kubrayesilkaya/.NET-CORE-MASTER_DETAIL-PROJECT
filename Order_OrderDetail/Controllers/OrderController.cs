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

        [HttpPost("AddOrder")]
        public ActionResult<IEnumerable<string>> AddOrder([FromBody] OrderRequestModel orderRequestModel)
        {
            var response = _orderService.AddOrder(orderRequestModel);

            return Ok(response);
        }

        //GET**********************************************************************************************

        //[Route("[action]")]
        //[HttpGet("GetOrderDetail")]
        //public IActionResult GetOrderDetail()
        //{
        //    var orders = _orderService.GetOrderDetail();
        //    return Ok(orders);
        //}

        //GET by ID*****************************************************************************************

        [HttpGet("GetOrderDetailByID")]
        public ActionResult<OrderEntity> GetOrderDetailByID(int id)
        {
            var order = _orderService.GetOrderDetail(id);
            return Ok(order);
        }

        //GET v2*******************************************************************************************

        [HttpGet("GetOrderDetailv2")]
        public IActionResult GetOrderDetailv2(int id)
        {
            var orderDetails = _orderService.GetOrderDetailv2(id);

            return Ok(orderDetails);
        }




    }


}
