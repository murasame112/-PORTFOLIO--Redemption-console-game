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
        
        // Default character
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

        /*
        ==============================================================================
            CHARACTER AND ITEMS
        ==============================================================================
        */


        // Create player character (basically just give him a name, he still has default stats)
        public Character CreateCharacter()
        {
            Console.Write("Your name: ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            this.name = Console.ReadLine();
            Console.WriteLine();
            this.UpdateStats();
            Console.ResetColor();
            return this;
        }

        // Update character's stats
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

        // Show character stats
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
            ====================
            Your stats
                Name: {character name}
                Level: {character level}
                Experience: {character experience}
                Experience needed to level up: {character (max experience - experience)}
                Gold: {character gold}
            */ 
            Console.ResetColor();
            Console.WriteLine("====================");
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
            Console.WriteLine();
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
            //====================
            Console.Write("  Attack (");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("{0}", itemNames[0]);
            Console.ResetColor();
            Console.Write("): ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("{0}", this.currentAtk);
            Console.ResetColor();
            Console.WriteLine("====================");
            Console.WriteLine();
        }

        // Returns string with item stats ("attack/armor/hp bonus: {item stat}")
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

        // Character receives an Item
        public void ReceiveItem(Item item)
        {
            // Get item type
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

            bool noItem = true;
            string newItemStats = ItemStats(item, type);
            string statsToCompare = "which, apparently, you don't have";
            if (CheckForItems(type))
            {
                noItem = false;
                statsToCompare = ItemStats(this.items[type], type);
            }

            // You've received an item! It's a {item type}, which is called {item name} ({item stat}).
            Console.ResetColor();
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
            Console.WriteLine(").");



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
            Console.WriteLine();
            Console.Write("Your choice: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
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


        // Checks, if player has an item on current slot
        public bool CheckForItems(int id)
        {
            return this.items.ElementAtOrDefault(id) != null;

        }

        // Responsible for buying items from shop
        public void GoShopping(Shop shop)
        {
            Console.ResetColor();
            Console.WriteLine("Welcome to the shop! Find yourself something useful.");
            Console.WriteLine();
            int i = 1;
            // Lists items from current shop
            i = shop.ShowShopItemsList(i);
            Console.WriteLine("{0}. Leave", i);

            // Your gold: {character gold}.
            Console.WriteLine();
            Console.Write("Your gold: ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", this.gold);
            Console.ResetColor();
            Console.WriteLine(".");
            Console.WriteLine();
            Console.Write("Your choice: ");

            int answer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            answer -= 1;
            if (answer != shop.shopItemList.Count)
            {
                if (shop.shopItemList[answer].price <= this.gold)
                {
                    // Thanks for buying the {item name from shop's list}!
                    Console.Write("Thanks for buying the ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("{0}", shop.shopItemList[answer].name);
                    Console.ResetColor();
                    Console.WriteLine("!");

                    this.gold -= shop.shopItemList[answer].price;
                    this.ReceiveItem(shop.shopItemList[answer]);
                }
                else
                {
                    Console.WriteLine("You don't even have enough money! Go away!");
                }
                Console.WriteLine();
            }

        }


        /*
        ==============================================================================
            FIGHTING WITH ENEMIES
        ==============================================================================
        */

        // Responsible for generating and spotting an enemy (with function CreateGenericMob)
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
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.WriteLine();
            Console.Write("Your choice: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (answer)
            {
                case 1:
                    this.Fight(mob);
                    break;
                case 2:
                    break;
            }
        }

        // Fighting with mob
        public void Fight(Mob mob)
        {
            bool characterFlee = false;
            // Get ready to fight! You face {mob name}, with level {mob level}.
            Console.ResetColor();
            Console.Write("Get ready to fight! You face ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("{0}", mob.name);
            Console.ResetColor();
            Console.Write(", with level ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", mob.level);
            Console.ResetColor();
            Console.WriteLine(".");
            Console.WriteLine();

            //{mob name} has {mob current hp} hp and {mob base armor} armor
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("{0}", mob.name);
            Console.ResetColor();
            Console.Write(" has ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("{0}", mob.currentHp);
            Console.ResetColor();
            Console.Write(" hp and ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("{0}", mob.baseArmor);
            Console.ResetColor();
            Console.WriteLine(" armor.");

            // Fighting cycle
            while (this.currentHp > 0 && mob.currentHp > 0 && characterFlee == false)
            {
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("What action do you perform?");
                Console.WriteLine("1. Attack");
                Console.Write("2. Use spell (current mana: ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("{0}", this.currentMana);
                Console.ResetColor();
                Console.WriteLine(")");
                Console.WriteLine("3. Flee");
                Console.WriteLine();
                Console.Write("Your choice: ");
                int action = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
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

                if (mob.currentHp > 0 && characterFlee == false) { Attack(mob, this, mob.baseAtk, this.currentArmor); }
            }

            // Result of fight
            if (this.currentHp > 0 && characterFlee == false)
            {
                UpdateStats();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(AnnounceWinner(this, mob));
                Console.ResetColor();
                this.GainExp(mob.DropExp());
                this.GainGold(mob.DropGold());
                Console.WriteLine();
            }
            else if (mob.currentHp > 0 && characterFlee == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(AnnounceWinner(mob, this));
                Console.ResetColor();
            }

        }

        // Unit X attacks unit Y with basic attack
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
            Console.WriteLine();
        }

        // Choose which spell to use as action in fight
        public void ChooseSpell()
        {
            int i = 1;
            Console.ResetColor();
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
            Console.WriteLine();
            Console.Write("Choose spell: ");
            int spellNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();                
            spells[spellNumber - 1]();
            



        }

        // Character flees from a fight (also loses all experience points and some gold)
        public bool Flee(Mob mob)
        {
            this.gold -= mob.gold;
            this.experience = 0;
            // {character name} runs away! All experience and {mob gold} gold lost!
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}", this.name);
            Console.ResetColor();
            Console.Write(" runs away! ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("All");
            Console.ResetColor();
            Console.Write(" experience and ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("{0}", mob.gold);
            Console.ResetColor();
            Console.WriteLine(" gold lost!");
            Console.WriteLine();


            return true;
        }

        // Returns string telling who won the fight
        public string AnnounceWinner(Unit unitWinner, Unit unitLoser)
        {
            string result = unitWinner.name + " was victorious! " + unitLoser.name + " has been slain.";


            return result;
        }

        // Character gains gold from killed mob
        public void GainGold(int goldGained)
        {
            this.gold += goldGained;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            //{gained gold} gold gained.
            Console.Write("{0}", goldGained);
            Console.ResetColor();
            Console.WriteLine(" gold gained.");

        }

        // Character gains experience points from killed mob
        public void GainExp(int expGained)
        {
            // "{character name} has gained {gained experience} experience from this fight.
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}", this.name);
            Console.ResetColor();
            Console.Write(" has gained ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", expGained);
            Console.ResetColor();
            Console.WriteLine(" experience from this fight.");

            this.experience += expGained;
            if (this.experience >= maxExperience)
            {
                this.experience = 0;
                this.LevelUp();
            }
        }

        // Character gains higher level and increases his stats
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

            //{character name} has gained level {gained level}!
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}", this.name);
            Console.ResetColor();
            Console.Write(" has gained level ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}", this.level);
            Console.ResetColor();
            Console.WriteLine("!");
            Console.WriteLine();
        }



        /*
        ==============================================================================
            SPELLS
        ==============================================================================
        */

        // Spell
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
                Console.WriteLine();

            }
            else
            {
                // Tide Thrust fails! {character name} has not enough mana... What a waste of time.
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Tide Thrust");
                Console.ResetColor();
                Console.Write(" fails! ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("{0}", this.name);
                Console.ResetColor();
                Console.WriteLine(" has not enough mana... What a waste of time.");
                Console.WriteLine();
            }


        }

        // Spell
        public void Rathonhnhaketon()
        {
            int manaCost = 10;

            if (this.currentMana >= manaCost)
            {
                this.currentMana -= manaCost;
                int hpHealed = ((this.maxHp / 5)*2);
                if (this.maxHp < this.currentHp + hpHealed) { hpHealed = this.maxHp - this.currentHp; }

                this.currentHp += hpHealed;

                // {character name} heals for {healed hp} hp.

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("{0}", this.name);
                Console.ResetColor();
                Console.Write(" heals for ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("{0}", hpHealed);
                Console.ResetColor();
                Console.WriteLine(" hp.");
                Console.WriteLine();
            }
            else
            {
                // Rathonhnhaketon fails! {character name} has not enough mana... What a waste of time.

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("Rathonhnhaketon");
                Console.ResetColor();
                Console.Write(" fails! ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("{0}", this.name);
                Console.ResetColor();
                Console.WriteLine(" has not enough mana... What a waste of time.");
                Console.WriteLine();
            }
        }

        

        

        


        

        

    }
}
