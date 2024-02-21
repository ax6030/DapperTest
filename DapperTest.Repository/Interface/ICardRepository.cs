using DapperTest.Repository.Dtos.Condition;
using DapperTest.Repository.Dtos.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Repository.Interface
{
    public interface ICardRepository
    {
        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <returns></returns>
        IEnumerable<CardDataModel> GetList(CardSearchConditionDto info);

        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>   
        CardDataModel Get(int id);

        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="parameter">卡片參數</param>
        /// <returns></returns>
        bool Insert(CardConditionDto info);

        /// <summary>
        /// 更新卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="parameter">卡片參數</param>
        /// <returns></returns>
        bool Update(int id, CardConditionDto info);

        /// <summary>
        /// 刪除卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
