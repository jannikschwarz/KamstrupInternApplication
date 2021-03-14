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
    public class ItemsController : ControllerBase
    {
        private ISqlToDb sqlToDb;

        public ItemsController(ISqlToDb sqlToDb)
        {
            this.sqlToDb = sqlToDb;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Item>>> getItemsAsync()
        {
            try
            {
                List<Item> items = (List<Item>) sqlToDb.getItems();
                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}