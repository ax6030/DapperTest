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


        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(contentType: "application/json")]
        public IEnumerable<Card> GetList()
        {
            return _cardRepository.GetList();
        }


        ///<summary>
        /// 查詢卡片
        /// </summary>
        /// <remarks>我是附加說明</remarks>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        /// /// <response code="200">回傳對應的卡片</response>
        /// <response code="404">找不到該編號的卡片</response> 
        // GET: api/<CardController>
        [HttpGet("{id}")]
        [Produces(contentType: "application/json")]
        [ProducesResponseType(typeof(Card), 200)]
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

        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        // POST api/<CardController>
        [HttpPost]
        public IActionResult Create([FromBody] CardParameter parameter)
        {
            var result = _cardRepository.Create(parameter);
            if (result > 0)
                return Ok();

            return StatusCode(500);
        }


        /// <summary>
        /// 更新卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="parameter"></param>
        /// <returns></returns>
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


        /// <summary>
        /// 刪除卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _cardRepository.Delect(id);
            return Ok();
        }

        
    }
}
