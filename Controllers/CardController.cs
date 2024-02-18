using DapperTest.Models;
using DapperTest.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly CardRepository _cardRepository;
        public CardController(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }


        /// 查詢卡片列表
        [HttpGet]
        public IEnumerable<Card> GetList()
        {
            return _cardRepository.GetList();
        }


        /// 查詢卡片
        // GET: api/<CardController>
        [HttpGet("{id}")]
        public Card Get([FromRoute] int id)
        {
            var result = _cardRepository.Get(id);
            if(result is null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return result;
        }

        /// 新增卡片
        // POST api/<CardController>
        [HttpPost]
        public IActionResult Create([FromBody] CardParameter parameter)
        {
            var result = _cardRepository.Create(parameter);
            if (result > 0)
                return Ok();

            return StatusCode(500);
        }


        /// 更新卡片
        // PUT api/<CardController>/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CardParameter parameter)
        {
            Card targetCard = _cardRepository.Get(id);
            if(targetCard is null)
            {
                return NotFound();
            }

            var isUpdateSuccess = _cardRepository.Update(id, parameter);
            if(isUpdateSuccess)
            { 
                return Ok();
            }

            return StatusCode(500);
        }


        /// 刪除卡片
        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cardRepository.Delect(id);
            return Ok();
        }

        
    }
}
