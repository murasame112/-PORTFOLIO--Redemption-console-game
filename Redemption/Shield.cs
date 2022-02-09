using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Shield : Item
    {
        public Shield(string name, int armor)
        {
            this.name = name;
            this.stat = armor;
        }
    }
}
