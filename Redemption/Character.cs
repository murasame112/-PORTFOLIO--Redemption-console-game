using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Character : Unit
    {
        public List<Action> spells = new List<Action>();
        public List<string> spellsString = new List<string>();
        public int currentAtk { get; set; }
        public int currentArmor { get; set; }
        public int maxHp { get; set; }
        public Item[] items = new Item[3];
        public int maxExperience { get; set; }
        public Character()
        {
            this.name = "Gustav";
            this.level = 1;
            this.baseArmor = 0;
            this.baseAtk = 1;
            this.baseHp = 10;
            this.experience = 0;
            this.maxExperience = 5;
            this.gold = 0;

        }

        public Character CreateCharacter(Character defaultCharacter)
        {

            Console.Write("Your name: ");
            this.name = Console.ReadLine();
            UpdateStats();
            return defaultCharacter;
        }

        public void UpdateStats()
        {
            this.currentAtk = baseAtk;
            this.maxHp = baseHp;
            this.currentArmor = baseArmor;
            
            if (CheckForItems(0))
            {
                this.currentAtk += items[0].stat;
            }
            if (CheckForItems(1))
            {
                this.currentArmor += items[1].stat;
            }
            if (CheckForItems(2))
            {
                this.maxHp += items[2].stat;
            }

            this.currentHp = this.maxHp;
        }

        public void ShowStats()
        {
            string[] itemNames = new string[3];
            itemNames[0] = "No sword equipped!";
            itemNames[1] = "No shield equipped!";
            itemNames[2] = "No breastplate equipped!";

            for (int i = 0; i < itemNames.Length; i++)
            {
                if (CheckForItems(i))
                {
                    itemNames[i] = this.items[i].name;
                }

            }
            Console.WriteLine("Your stats");
            Console.WriteLine();
            Console.WriteLine("Name: {0}", this.name);
            Console.WriteLine("Base stats");
            Console.WriteLine("  Hp: {0}", this.baseHp);
            Console.WriteLine("  Armor: {0}", this.baseArmor);
            Console.WriteLine("  Attack: {0}", this.baseAtk);

            Console.WriteLine("Current stats (with items equipped)");
            Console.WriteLine("  Hp ({0}): {1}", itemNames[2], this.maxHp);
            Console.WriteLine("  Armor ({0}): {1}", itemNames[1], this.currentArmor);
            Console.WriteLine("  Attack ({0}): {1}", itemNames[0], this.currentAtk);



        }
        public string ItemStats(Item item, int type)
        {
            string result = "";

            switch (type)
            {
                case 0:
                    result = "Attack bonus: ";
                    result += item.stat;
                    break;
                case 1:
                    result = "Armor bonus: ";
                    result += item.stat;
                    break;
                case 2:
                    result = "Hp bonus: ";
                    result += item.stat;
                    break;
            }
            return result;

        }



        public void ReceiveItem(Item item)
        {
            string itemType = item.ToString().Substring(11).ToLower();
            int type = 0;
            if (item.GetType() == typeof(Sword))
            {
                type = 0;
            }
            else if (item.GetType() == typeof(Shield))
            {
                type = 1;
            }
            else if (item.GetType() == typeof(Breastplate))
            {
                type = 2;
            }

            string newItemStats = ItemStats(item, type);


            string statsToCompare = "which, apparently, you don't have";
            if (CheckForItems(type))
            {
                statsToCompare = ItemStats(this.items[type], type);
            }


            Console.WriteLine();
            Console.WriteLine("You've received an item! It's a {0}, which is called {1} ({2})", itemType, item.name, newItemStats);
            Console.WriteLine("Do you want to replace your {0} ({1})? ", itemType, statsToCompare);
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    this.items[type] = item;
                    break;
                case 2:

                    break;
            }





            UpdateStats();
        }



        public bool CheckForItems(int id)
        {
            return this.items.ElementAtOrDefault(id) != null;

        }
        public void SpotEnemy(Mob mob)
        {
            /*
            napotykasz wroga takiego i takiego, chcesz walczyć czy sie wycofac/ominac/cokolwiek?
             */
        }

        public void Attack(Unit unitAttacking, Unit unitAttacked, int atk, int armor)
        {
            int damage = (atk - armor);
            unitAttacked.currentHp -= damage;
            if(unitAttacked.currentHp <= 0) { unitAttacked.currentHp = 0; }
            Console.WriteLine("{0} attacks for {1}, {2} has {3} hp left",unitAttacking.name, damage, unitAttacked.name, unitAttacked.currentHp);

        }

        public void ChooseSpell()
        {
            int i = 1;
            Console.WriteLine();
            Console.WriteLine("Your spells: ");
            //foreach (Action spell in spells)
            foreach(string spell in spellsString)
            {
                

                Console.WriteLine("{0}. {1}",i, spell);
                i++;
            }
            Console.Write("Choose spell: ");
            int spellNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            spells[spellNumber-1]();

            

        }

        public void TideThrust(Mob target)
        {
            int damage = (this.currentAtk + 1) - target.baseArmor;
            target.currentHp -= damage;
            if(target.currentHp <= 0) { target.currentHp = 0; }
            Console.WriteLine("{0} attacks with Tide Thrust for {1}, {2} has {3} hp left", this.name, damage, target.name, target.currentHp);


        }

        public void Rathonhnhaketon()
        {
            int hpHealed = this.maxHp/5;
            if (this.maxHp < this.currentHp + hpHealed) { hpHealed = this.maxHp - this.currentHp; }

            this.currentHp += hpHealed;
            Console.WriteLine("{0} heals for {1} hp. ", this.name, hpHealed);
        }

        public string AnnounceWinner(Unit unitWinner, Unit unitLoser)
        {
            string result = unitWinner.name + " was victorious! " + unitLoser.name + " has been slain." ;

            
            return result;
        }

        public void GainGold(int goldGained)
        {
            Console.WriteLine("{0} gold gained.", goldGained);

        }

        public void GainExp(int expGained)
        {
            Console.WriteLine("{0} has gained {1} experience from this fight.", this.name, expGained);
            this.experience += expGained;
            if(this.experience >= maxExperience)
            {
                this.experience = 0;
                this.LevelUp();
            }
        }

        public void LevelUp()
        {
            this.level += 1;
            if (level % 2 == 0) { this.baseArmor += 1; }
            this.baseAtk += 1;
            this.baseHp += 5;
            this.experience = 0;
            this.maxExperience += 5;
            Console.WriteLine("{0} has gained level {1}!", this.name, this.level);
        }

        public void Fight(Character character, Mob mob)
        {
            Console.WriteLine("Get ready to fight! You face {0}, with level {1}", mob.name, mob.level);
            Console.WriteLine();
            Console.WriteLine("{0} has {1} hp and {2} armor", mob.name, mob.currentHp, mob.baseArmor);
            while (character.currentHp > 0 && mob.currentHp > 0)
            {
                Console.WriteLine();
                Console.WriteLine("What action do you perform?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use spell");
                Console.WriteLine("3. Flee");
                Console.Write("Your action: ");
                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        Attack(character, mob, character.currentAtk, mob.baseArmor);
                        break;
                    case 2:
                        ChooseSpell();
                        break;
                    case 3:
                        break;
                }

                Console.WriteLine();

                if (mob.currentHp > 0) { Attack(mob, character, mob.baseAtk, character.currentArmor); }
            }
            if (character.currentHp > 0)
            {
                UpdateStats();
                Console.WriteLine(AnnounceWinner(character, mob));
                character.GainExp(mob.DropExp());
                character.GainGold(mob.DropGold());
               // mob.dropItemChance();
                
            }else if (mob.currentHp > 0)
            {
                Console.WriteLine(AnnounceWinner(mob, character));
            }
            
            



        }

    }
}
