using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Entities;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemODPServiceController : Controller
    {

        IItemService<ITEM> itemService;

        public ItemODPServiceController(IItemService<ITEM> _itemService)
        {
            itemService = _itemService;
        }


        [HttpGet]
        public async Task<ActionResult<List<ITEM>>> GetAllItems()
        {
            return Ok(await itemService.GetAllItems());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ITEM>> GetById(int id)
        {
            var item = await itemService.GetItemById(id);
            if (item == null)
                return BadRequest("Item not found.");
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<ITEM>>> Add(ITEM item)
        {
            itemService.AddItem(item);

            return Ok(await itemService.GetAllItems());
        }

        [HttpPut]
        public async Task<ActionResult<List<ITEM>>> UpdateItem(ITEM item)
        {
            itemService.EditItem(item);

            return Ok(await itemService.GetAllItems());
        }

        [HttpDelete]
        public async Task<ActionResult<List<ITEM>>> Delete(int id)
        {
            itemService.DeleteItem(id);

            return Ok(await itemService.GetAllItems());
        }
    }
}
