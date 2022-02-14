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
        public int maxMana { get; set; } 
        public int currentMana { get; set; }
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
            this.maxMana = 10;
        }

        public Character CreateCharacter()
        {

            Console.Write("Your name: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            this.name = Console.ReadLine();
            this.UpdateStats();
            Console.ResetColor();
            return this;
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
            this.currentMana = this.maxMana;
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
            /*
            Your stats
                Name: {character name}
                Level: {character level}
                Experience: {character experience}
                Experience needed to level up: {character (max experience - experience)}
                Gold: {character gold}
            */ 
             
            Console.ResetColor();
            Console.WriteLine("Your stats");
            Console.WriteLine();
            Console.Write("  Name: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0}", this.name);
            Console.ResetColor();
            Console.Write("  Level: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0}", this.level);
            Console.ResetColor();
            Console.Write("  Experience: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}", this.experience);
            Console.ResetColor();
            Console.Write("  Experience needed to level up: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}", this.maxExperience - this.experience);
            Console.ResetColor();
            Console.Write("  Gold: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("{0}", this.gold);

            /*
            Current stats (with items equipeed)
                Mana: {character max mana}
            */
            Console.ResetColor();
            Console.WriteLine("Current stats (with items equipped)");
            Console.Write("  Mana: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0}", this.maxMana);
            Console.ResetColor();

            // Hp ({item name}): {max hp}
            Console.Write("  Hp (");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}", itemNames[2]);
            Console.ResetColor();
            Console.Write("): ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("{0}", this.maxHp);
            Console.ResetColor();

            // Armor ({item name}): {current armor}
            Console.Write("  Armor (");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}", itemNames[1]);
            Console.ResetColor();
            Console.Write("): ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("{0}", this.currentArmor);
            Console.ResetColor();

            // Attack ({item name}): {current attack}
            Console.Write("  Attack (");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}", itemNames[0]);
            Console.ResetColor();
            Console.Write("): ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0}", this.currentAtk);
            Console.ResetColor();



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

            bool noItem = true;
            string statsToCompare = "which, apparently, you don't have";
            if (CheckForItems(type))
            {
                noItem = false;
                statsToCompare = ItemStats(this.items[type], type);
            }

            // You've received an item! It's a {item type}, which is called {item name} ({item stat})
            Console.ResetColor();
            Console.WriteLine();
            Console.Write("You've received an item! It's a {0}, which is called ", itemType);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}", item.name);
            Console.ResetColor();
            Console.Write(" (");
            if(type == 0) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
            else if(type == 1) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
            else if(type == 2) { Console.ForegroundColor = ConsoleColor.DarkRed; }
            Console.Write("{0}", newItemStats);
            Console.ResetColor();
            Console.WriteLine(")");


            // Do you want to replace your {item type} ({item stat})? 
            Console.Write("Do you want to replace your {0} (", itemType);
            if (noItem == false) 
            {
                if (type == 0) { Console.ForegroundColor = ConsoleColor.DarkCyan; }
                else if (type == 1) { Console.ForegroundColor = ConsoleColor.DarkMagenta; }
                else if (type == 2) { Console.ForegroundColor = ConsoleColor.DarkRed; } 
            }
            Console.Write("{0}", statsToCompare);
            Console.ResetColor();
            Console.WriteLine(")?");
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

            this.UpdateStats();
        }



        public bool CheckForItems(int id)
        {
            return this.items.ElementAtOrDefault(id) != null;

        }

        public void SpotEnemy(Mob mob, int locationLevel, List<string> genericMobNames)
        {
            
            Random rand = new Random();
            int mobNameNumber = rand.Next(0, genericMobNames.Count - 1);
            mob.CreateGenericMob(locationLevel, genericMobNames[mobNameNumber]);
            //You spot a monster! It's {monster name} with level {level}.
            Console.ResetColor();

            Console.Write("You spot a monster! It's ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("{0} ", mob.name);
            Console.ResetColor();
            Console.Write("with level ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mob.level);
            Console.ResetColor();
            Console.WriteLine(".");


            Console.WriteLine("Do you want to fight?");
            Console.WriteLine("1. Yes.");
            Console.WriteLine("2. No.");
            Console.Write("Your answer: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    this.Fight(mob);
                    break;
                case 2:
                    break;
            }
        }

        public void Attack(Unit unitAttacking, Unit unitAttacked, int atk, int armor)
        {
            int damage = (atk - armor);
            unitAttacked.currentHp -= damage;
            if (unitAttacked.currentHp <= 0) { unitAttacked.currentHp = 0; }
            // {unit attacking} attacks for {damage}, {unit attacked} has {current hp of attacked unit} hp left.
            Console.ResetColor();
            if (unitAttacking.GetType() == typeof(Character)) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            else if (unitAttacking.GetType() == typeof(Mob)) { Console.ForegroundColor = ConsoleColor.DarkGray; }
            Console.Write("{0}", unitAttacking.name);
            Console.ResetColor();
            Console.Write(" attacks for ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("{0}", damage);
            Console.ResetColor();
            Console.Write(", ");
            if (unitAttacked.GetType() == typeof(Character)) { Console.ForegroundColor = ConsoleColor.DarkGreen; }
            else if (unitAttacked.GetType() == typeof(Mob)) { Console.ForegroundColor = ConsoleColor.DarkGray; }
            Console.Write("{0}", unitAttacked.name);
            Console.ResetColor();
            Console.Write(" has ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("{0}", unitAttacked.currentHp);
            Console.ResetColor();
            Console.WriteLine(" hp left.");

        }

        public void ChooseSpell()
        {
            int i = 1;
            Console.ResetColor();
            Console.WriteLine();
            // Current mana: {character mana}
            Console.Write("Current mana: ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("{0}", this.currentMana);
            Console.ResetColor();
            Console.WriteLine("Your spells: ");
            
            // {number}. {spell name}
            foreach (string spell in spellsString)
            {


                Console.Write("{0}. ", i);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("{0}", spell);
                Console.ResetColor();
                i++;
            }

            Console.Write("Choose spell: ");
            int spellNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();                
            spells[spellNumber - 1]();
            



        }

        public void TideThrust(Mob target)
        {
            int manaCost = 5;

            if (this.currentMana >= manaCost)
            {
                this.currentMana -= manaCost;
                int damage = (this.currentAtk + 1) - target.baseArmor;
                target.currentHp -= damage;
                if (target.currentHp <= 0) { target.currentHp = 0; }
                // {character name} attacks with Tide Thrust for {damage}, {mob name} has {mob current hp} hp left.
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("{0}", this.name);
                Console.ResetColor();
                Console.Write(" attacks with ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Tide Thrust");
                Console.ResetColor();
                Console.Write(" for ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0}", damage);
                Console.ResetColor();
                Console.Write(", ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("{0}", target.name);
                Console.ResetColor();
                Console.Write(" has ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("{0}", target.currentHp);
                Console.ResetColor();
                Console.WriteLine(" hp left.");

            }
            else
            {
                // Tide Thrust fails! {0} has not enough mana... What a waste of time.
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Tide Thrust");
                Console.ResetColor();
                Console.Write(" fails! ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("{0}", this.name);
                Console.ResetColor();
                Console.Write(" has not enough mana... What a waste of time.");
            }


        }

        public void Rathonhnhaketon()
        {
            int manaCost = 10;

            if (this.currentMana >= manaCost)
            {
                this.currentMana -= manaCost;
                int hpHealed = this.maxHp / 5;
                if (this.maxHp < this.currentHp + hpHealed) { hpHealed = this.maxHp - this.currentHp; }

                this.currentHp += hpHealed;
                Console.WriteLine("{0} heals for {1} hp. ", this.name, hpHealed);
            }
            else
            {
                Console.WriteLine("Rathonhnhaketon fails! {0} has not enough mana... What a waste of time.", this.name);
            }
        }

        public string AnnounceWinner(Unit unitWinner, Unit unitLoser)
        {
            string result = unitWinner.name + " was victorious! " + unitLoser.name + " has been slain.";


            return result;
        }

        public void GainGold(int goldGained)
        {
            this.gold += goldGained;
            Console.WriteLine("{0} gold gained.", goldGained);

        }

        public void GainExp(int expGained)
        {
            Console.WriteLine("{0} has gained {1} experience from this fight.", this.name, expGained);
            this.experience += expGained;
            if (this.experience >= maxExperience)
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
            this.maxMana += 5;
            this.UpdateStats();
            Console.WriteLine("{0} has gained level {1}!", this.name, this.level);
        }

        public bool Flee(Mob mob)
        {
            this.gold -= mob.gold;
            this.experience = 0;
            Console.WriteLine("{0} runs away! All experience and {1} gold lost!", this.name, mob.gold);
            
            return true;
        }

        public void Fight(Mob mob)
        {
            bool characterFlee = false;
            Console.WriteLine("Get ready to fight! You face {0}, with level {1}", mob.name, mob.level);
            Console.WriteLine();
            Console.WriteLine("{0} has {1} hp and {2} armor", mob.name, mob.currentHp, mob.baseArmor);
            while (this.currentHp > 0 && mob.currentHp > 0 && characterFlee == false)
            {
                Console.WriteLine();
                Console.WriteLine("What action do you perform?");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Use spell (current mana: {0})",   this.currentMana);
                Console.WriteLine("3. Flee");
                Console.Write("Your action: ");
                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        Attack(this, mob, this.currentAtk, mob.baseArmor);
                        break;
                    case 2:
                        ChooseSpell();
                        break;
                    case 3:
                        characterFlee = this.Flee(mob);
                        break;
                }

                Console.WriteLine();

                if (mob.currentHp > 0 && characterFlee == false) { Attack(mob, this, mob.baseAtk, this.currentArmor); }
            }
            if (this.currentHp > 0 && characterFlee == false)
            {
                UpdateStats();
                Console.WriteLine(AnnounceWinner(this, mob));
                this.GainExp(mob.DropExp());
                this.GainGold(mob.DropGold());
                
            }else if (mob.currentHp > 0 && characterFlee == false)
            {
                Console.WriteLine(AnnounceWinner(mob, this));
            }
            
            



        }


        public void GoShopping(Shop shop)
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to the shop! Find yourself something useful.");
            int i = 1;
            i = shop.ShowShopItemsList(i);
           
            Console.WriteLine("{0}. Leave.", i);

            Console.WriteLine();
            Console.WriteLine("Your gold: {0}.", this.gold);
            Console.Write("Your answer: ");
            
            int answer = Convert.ToInt32(Console.ReadLine());
            answer -= 1;
            if (answer != shop.shopItemList.Count)
            {
                if (shop.shopItemList[answer].price <= this.gold)
                {
                    this.gold -= shop.shopItemList[answer].price;
                    this.ReceiveItem(shop.shopItemList[answer]);
                    Console.WriteLine("Thanks for buying the {0}!", shop.shopItemList[answer].name);
                }
                else
                {
                    Console.WriteLine("You don't even have enough money! Go away!");
                }
            }
           
        }

        

    }
}
