using System.ComponentModel;

namespace DapperTest.Models
{
    public class Card
    {
        /// <summary>
        /// 卡片編號
        /// </summary>
        [DisplayName("卡片編號")]
        public int Id { get; set; }

        /// <summary>
        /// 卡片名稱
        /// </summary>
        [DisplayName("卡片名稱")]
        public string Name { get; set; }

        /// <summary>
        /// 卡片描述
        /// </summary>
        [DisplayName("卡片描述")]
        public string Description { get; set; }

        /// <summary>
        /// 攻擊力
        /// </summary>
        [DisplayName("攻擊力")] 
        public int Attack { get; set; }

        /// <summary>
        /// 血量
        /// </summary>
        [DisplayName("血量")] 
        public int Health { get; set; }

        /// <summary>
        /// 花費
        /// </summary>
        [DisplayName("花費")]
        public int Cost { get; set; }
    }
}
