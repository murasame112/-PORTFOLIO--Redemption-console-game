using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Breastplate : Item
    {
        public Breastplate(string name, int hp, int price)
        {
            this.name = name;
            this.stat = hp;
            this.price = price;
        }
    }
}
