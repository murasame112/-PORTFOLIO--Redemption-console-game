using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Mob : Unit
    {
        

        public Mob()
        {
            this.name = "Unknown monster";
            this.level = 1;
            this.baseArmor = 1;
            this.baseAtk = 1;
            this.baseHp = 5;
            this.currentHp = this.baseHp;
            this.experience = 1;

        }

        public void CreateGenericMob(int level, string name)
        {
            
            this.name = name;
            this.level = level;
            this.baseArmor = (1 * level)/2;
            this.baseAtk = 1 * level;
            this.baseHp = 5 * level;
            this.currentHp = this.baseHp;
            this.experience = 1 * level;


        }
        
        public int dropExp()
        {
            return this.experience;

        }

    }
}
