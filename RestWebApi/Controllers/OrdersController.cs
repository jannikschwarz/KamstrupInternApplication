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
        private ISqlToDb sqlToDb;

        public OrdersController(ISqlToDb sqlToDb)
        {
            this.sqlToDb = sqlToDb;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> getOrdersAsync()
        {
            try
            {
                List<Order> orders = (List<Order>) sqlToDb.getOrders();
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
                sqlToDb.addOrder(newOrder);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}