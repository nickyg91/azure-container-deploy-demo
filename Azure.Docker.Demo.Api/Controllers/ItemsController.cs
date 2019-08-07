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
    }
}
