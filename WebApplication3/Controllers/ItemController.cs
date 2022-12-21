using Persistence.Entities;
using Persistence.Repository;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        private readonly IRepository<ITEM> itemRepository;

        public ItemController(IRepository<ITEM> _itemRepository)
        {
            itemRepository = _itemRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<ITEM>>> GetAll()
        {
            return Ok(await itemRepository.GetAll());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ITEM>> GetById(int id)
        {
            var item = await itemRepository.GetById(id);
            if (item == null)
                return BadRequest("Item not found.");
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<ITEM>>> Add(ITEM item)
        {
            await itemRepository.Add(item);

            return Ok(await itemRepository.GetAll());
        }

        [HttpPut]
        public async Task<ActionResult<List<ITEM>>> UpdateItem(ITEM item)
        {
            itemRepository.Update(item);

            return Ok(await itemRepository.GetAll());
        }

        [HttpDelete]
        public async Task<ActionResult<List<ITEM>>> Delete(ITEM id)
        {
            itemRepository.Delete(id);

            return Ok(await itemRepository.GetAll());
        }

    }
}
