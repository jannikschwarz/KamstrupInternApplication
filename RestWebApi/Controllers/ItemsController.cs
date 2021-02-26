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
    public class ItemsController : ControllerBase
    {
        private IItemsService itemsService;

        public ItemsController(IItemsService itemsService)
        {
            this.itemsService = itemsService;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Item>>> getItemsAsync()
        {
            try
            {
                List<Item> items = await itemsService.getItemsAsync();
                return Ok(items);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}