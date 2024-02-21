using AutoMapper;
using DapperTest.Models;
using DapperTest.Parameter;
using DapperTest.Service.Dtos;
using DapperTest.Service.Implement;
using DapperTest.Service.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DapperTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICardService _cardService;
        public CardController(CardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }


        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(contentType: "application/json")]
        public IEnumerable<CardViewModel> GetList([FromQuery]CardSearchParameter parameter)
        {
            var info = _mapper.Map<CardSearchInfo>(parameter);

            var cards = _cardService.GetList(info);

            var result = _mapper.Map<IEnumerable<CardViewModel>>(cards);
            return result;
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
        [ProducesResponseType(typeof(CardViewModel), 200)]
        public CardViewModel Get([FromRoute] int id)
        {
            var card = _cardService.Get(id);

            var result = _mapper.Map<CardViewModel>(card);

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
            var info = _mapper.Map<CardInfo>(parameter);

            var isInsertSuccess = _cardService.Insert(info);
            if (isInsertSuccess)
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
            var targetCard = _cardService.Get(id);
            if(targetCard is null)
            {
                return NotFound();
            }

            var info = _mapper.Map<CardInfo>(parameter);

            var isUpdateSuccess = _cardService.Update(id, info);
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
            _cardService.Delete(id);
            return Ok();
        }

        
    }
}
