using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public abstract class Item
    {
        /*
        [0] - sword
        [1] - shield
        [2] - breastplate
         */
        public string name { get; set; }
        public int stat { get; set; }
        public int price { get; set; }

    }
}
