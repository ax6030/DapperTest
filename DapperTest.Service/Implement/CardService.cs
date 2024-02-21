using AutoMapper;
using DapperTest.Repository.Dtos.Condition;
using DapperTest.Repository.Implement;
using DapperTest.Repository.Interface;
using DapperTest.Service.Dtos;
using DapperTest.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Service.Implement
{
    /// <summary>
    /// 卡片管理
    /// </summary>
    /// <seealso cref="DapperTest.Service.Interface.ICardService" />
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;
        public CardService(CardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;

            /*var config = new MapperConfiguration(cfg =>
            cfg.AddProfile<ServiceMappings>());
            _mapper = config.CreateMapper();*/

            _mapper = mapper;
        }
        
        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        public CardResultModel Get(int id)
        {
            var card = _cardRepository.Get(id);
            var result = _mapper.Map<CardResultModel>(card);

            return result;
        }

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IEnumerable<CardResultModel> GetList(CardSearchInfo info)
        {
            var condition = _mapper.Map<CardSearchConditionDto>(info);
            var cards = _cardRepository.GetList(condition);

            var result = _mapper.Map<IEnumerable<CardResultModel>>(cards);

            return result;
        }


        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(CardInfo info)
        {
            var condition = _mapper.Map<CardConditionDto>(info);
            var result = _cardRepository.Insert(condition);

            return result;
        }

        /// <summary>
        /// 更新卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(int id, CardInfo info)
        {
            var condition = _mapper.Map<CardConditionDto>(info);
            var result = _cardRepository.Update(id, condition);

            return result;
        }


        /// <summary>
        /// 刪除卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var result = _cardRepository.Delete(id);
            return result;
        }
    }
}
