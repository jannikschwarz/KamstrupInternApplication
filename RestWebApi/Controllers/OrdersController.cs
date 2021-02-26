using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWebApi.Data.Impl;
using RestWebApi.Data.Model;

namespace RestWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrdersController : ControllerBase
    {
        private IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> getOrdersAsync()
        {
            try
            {
                List<Order> orders = await orderService.getOrdersAsync();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task orderAsync([FromBody] Order newOrder)
        {
            try
            {
                await orderService.orderAsync(newOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}