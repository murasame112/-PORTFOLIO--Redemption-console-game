using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public abstract class Unit
    {
        public string name { get; set; }
        public int level { get; set; }
        public int baseHp { get; set; }
        public int baseArmor { get; set; }
        public int baseAtk { get; set; }
        public Item[] items;
        public int currentHp { get; set; }
    }
}
