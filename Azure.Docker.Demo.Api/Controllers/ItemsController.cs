using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Docker.Datalayer;
using Azure.Docker.Datalayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Azure.Docker.Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
       private readonly IItemRepository _repo;
       public ItemsController(IItemRepository repo)
       {
           _repo = repo;
       }    

       [HttpGet("{id:int}")]
       public IActionResult Get(int id)
       {
           return Ok(_repo.GetItemById(id));
       }

       [HttpGet("all")]
       public IActionResult Get()
       {
           return Ok(_repo.GetItems());
       }

       [HttpPost]
       public IActionResult Post(Item item)
       {
           _repo.SaveItem(item);
           return Ok();
       }

       [HttpGet("item")]
       public IActionResult GetItem()
       {
           return Ok(new Item 
           {
               Id = 999,
               Name = "Test"
           });
       }

       [HttpGet("work")]
       public IActionResult Work()
       {
           //simulate 2 minutes of 100% work accross all threads.
           for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                Task.Run(() => 
                {
                    var timer = new Stopwatch();
                    timer.Start();
                    while(true)
                    {
                        if (timer.ElapsedMilliseconds == 120000)
                        {
                            break;
                        }
                    }
                    timer.Stop();
                });
            }
           
           return Ok();
       }
    }
}
