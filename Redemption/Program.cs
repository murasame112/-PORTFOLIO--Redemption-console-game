using System;
using System.Linq;

namespace Redemption
{

    /*
    mechanika:
        - postać leczy się po każdej walce do full hp
        - każdy item odpowiada za zwiększanie jednej ze statystyk
        - przeciwnicy nie mają itemów, ale mają mocniejsze staty (moga byc defaultowo liczone ze wzoru zaleznie od levela)

    todo:
        - generowanie miejsc? (miastezcko ze sklepem, pobliski dungeon czy inny las)
        - generowanie przeciwników i walka z nimi
        

    fabuła:
        - na poczatku cytat nedlima, "asdf asdf" ~ Nedlim the Lightbringer (uzyc innego slowa)
        - po zabiciu jakeigoś bossa mozemy zmienic sie w Dark Paladina - zabijajc bossa wyzwalamy jakas moc czy cos ktora mowi, ze zastapi nam swiatlosc
     */

    public abstract class Item
    {
        /*
        [0] - sword
        [1] - shield
        [2] - breastplate
         */
        public string name { get; set; }
        public int stat { get; set; }

    }

    public class Sword : Item
    {
        public Sword(string name, int atk)
        {
            this.name = name;
            this.stat = atk;
        }
    }
    public class Shield : Item
    {
        public Shield(string name, int armor)
        {
            this.name = name;
            this.stat = armor;
        }
    }
    public class Breastplate : Item
    {
        public Breastplate(string name, int hp)
        {
            this.name = name;
            this.stat = hp;
        }
    }

    public abstract class Unit
    {
        public string name { get; set; }
        public int level { get; set; }
        public int baseHp { get; set; }
        public int baseArmor { get; set; }
        public int baseAtk { get; set; }
        public Item[] items;

    }

    public class Mob : Unit
    {

    }

    public class Character : Unit
    {
        public int currentAtk { get; set; }
        public int currentArmor { get; set; }
        public int currentHp { get; set; }
        public Item[] items = new Item[3];
        public Character()
        {
            this.name = "Gustaw";
            this.level = 1;
            this.baseArmor = 0;
            this.baseAtk = 1;
            this.baseHp = 10;
            
        }

        public Character CreateCharacter(Character defaultCharacter)
        {

            Console.Write("Your name: ");
            this.name = Console.ReadLine();

            return defaultCharacter ;
        }
        
        public void UpdateStats()
        {
            this.currentAtk = baseAtk;
            this.currentHp = baseHp;
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
                this.currentHp += items[2].stat;
            }

        }

        public void ShowStats()
        {
            string[] itemNames = new string[3];
            itemNames[0] = "No sword equipped!";
            itemNames[1] = "No shield equipped!";
            itemNames[2] = "No breastplate equipped!";

            for(int i = 0; i< itemNames.Length; i++)
            {
                if (CheckForItems(i))
                {
                    itemNames[i] = this.items[i].name;
                }
                
            }
            Console.WriteLine("Your stats");
            Console.WriteLine();
            Console.WriteLine("Name: {0}",this.name);
            Console.WriteLine("Base stats");
            Console.WriteLine("  Hp: {0}", this.baseHp);
            Console.WriteLine("  Armor: {0}", this.baseArmor);
            Console.WriteLine("  Attack: {0}", this.baseAtk);

            Console.WriteLine("Current stats (with items equipped)");
            Console.WriteLine("  Hp ({0}): {1}", itemNames[2], this.currentHp);
            Console.WriteLine("  Armor ({0}): {1}", itemNames[1], this.currentArmor);
            Console.WriteLine("  Attack ({0}): {1}",  itemNames[0], this.currentAtk);
            
            

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
            int type=0;
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

    }

    class Program
    {
        static void Main(string[] args)
        {
            Character playerCharacter = new Character();
            playerCharacter.CreateCharacter(playerCharacter);
            

            Item basicSword = new Sword("Basic Sword", 2);
            Item brokenSword = new Sword("Broken Sword", 1);
            Item omniblade = new Sword("Omniblade", 10);


            playerCharacter.ReceiveItem(basicSword);
            playerCharacter.ShowStats();

            playerCharacter.ReceiveItem(brokenSword);
            playerCharacter.ShowStats();

            playerCharacter.ReceiveItem(omniblade);
            playerCharacter.ShowStats();










        }
    }
}
