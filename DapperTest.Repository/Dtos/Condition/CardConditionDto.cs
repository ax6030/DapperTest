using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Repository.Dtos.Condition
{
    public class CardConditionDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        public int Cost { get; set; }
    }
}
