using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWebApi.Data.Model;
using RestWebApi.NetWorking;

namespace RestWebApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class OrdersController : ControllerBase
    {
        private ISocketToDb socketToDb;

        public OrdersController(ISocketToDb socketToDb)
        {
            this.socketToDb = socketToDb;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> getOrdersAsync()
        {
            try
            {
                List<Order> orders = (List<Order>) socketToDb.getOrders();
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
                socketToDb.addOrder(newOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}