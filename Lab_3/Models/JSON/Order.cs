using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Models.JSON
{
    internal class Order
    {
        public Set set { get; set; }
        public int sushiCount { get; set; }
        public int sauceCount { get; set; }
    }
}
