using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Sword : Item
    {
        public Sword(string name, int atk)
        {
            this.name = name;
            this.stat = atk;
        }
    }
}
