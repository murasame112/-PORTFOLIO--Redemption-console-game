using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Mob : Unit
    {
        public int questMob { get; set; }
        
        public Mob()
        {
            this.name = "Unknown Monster";
            this.level = 1;
            this.baseArmor = 1;
            this.baseAtk = 2;
            this.baseHp = 5;
            this.currentHp = this.baseHp;
            this.experience = 1;
            this.gold = 1;
            this.questMob = 0;

        }

        // Creating mob with "typical" stats (based on mob's level)
        public void CreateGenericMob(int level, string name)
        {
            this.level = level;
            this.name = name;
            this.baseArmor = (1 * level)/2;
            this.baseAtk = 2 * level;
            this.baseHp = 7 * level;
            this.currentHp = this.baseHp;
            this.experience = 1 * level;
            this.questMob = 0;
            Random rand = new Random();
            this.gold = rand.Next(level, (3 * level)-1);
        }

        // Creating custom mob, with all stats from parameters
        public void CreateCustomMob(int level, string name, int baseArmor, int baseAtk, int baseHp, int experience, int gold, int questNumber)
        {
            this.level = level;
            this.name = name;
            this.baseArmor = baseArmor;
            this.baseAtk = baseAtk;
            this.baseHp = baseHp;
            this.currentHp = this.baseHp;
            this.experience = experience;
            this.gold = gold;
            this.questMob = questNumber;
        }
        
        // Returns experience points dropped by mob
        public int DropExp()
        {
            return this.experience;
        }

        // Returns gold points dropped by mob
        public int DropGold()
        {
            return this.gold;
        }

    }
}
