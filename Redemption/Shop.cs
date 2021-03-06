using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Shop
    {
        public List<Item> shopItemList { get; set; }

        public Shop()
        {
            this.shopItemList = new List<Item>();
        }


        // Adds item to shop
        public void AddToShop(Item item)
        {
            this.shopItemList.Add(item);
        }

        // Remove item from shop
        public void RemoveFromShop(Item item)
        {
            this.shopItemList.Remove(item); 
        }

        //List items from shop (returns number of last item + 1, for the purpose of "{num}. Leave shop" option)
        public int ShowShopItemsList(int i)
        {
            Console.ResetColor();
            Console.WriteLine("Swords: ");
            foreach (Item item in this.shopItemList)
            {
                if (item.GetType() == typeof(Sword))
                {
                    // {item number}. {item name}, attack value: {stat}, {gold} gold.
                    Console.Write("{0}. ", i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("{0}", item.name);
                    Console.ResetColor();
                    Console.Write(", attack value: ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("{0}", item.stat);
                    Console.ResetColor();
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("{0} ", item.price);
                    Console.ResetColor();
                    Console.WriteLine("gold.");
                    Console.ResetColor();
                    i++;
                }
            }

            Console.ResetColor();
            Console.WriteLine("Shields: ");
            foreach (Item item in this.shopItemList)
            {
                if (item.GetType() == typeof(Shield))
                {
                    // {item number}. {item name}, armor value: {stat}, {gold} gold.
                    Console.Write("{0}. ", i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("{0}", item.name);
                    Console.ResetColor();
                    Console.Write(", armor value: ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write("{0}", item.stat);
                    Console.ResetColor();
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("{0} ", item.price);
                    Console.ResetColor();
                    Console.WriteLine("gold.");
                    Console.ResetColor();
                    i++;
                }
            }

            Console.ResetColor();
            Console.WriteLine("Breastplates: ");
            foreach (Item item in this.shopItemList)
            {
                if (item.GetType() == typeof(Breastplate))
                {
                    // {item number}. {item name}, hp value: {stat}, {gold} gold.
                    Console.Write("{0}. ", i);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("{0}", item.name);
                    Console.ResetColor();
                    Console.Write(", hp value: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("{0}", item.stat);
                    Console.ResetColor();
                    Console.Write(", ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("{0} ", item.price);
                    Console.ResetColor();
                    Console.WriteLine("gold.");
                    Console.ResetColor();
                    i++;
                }
            }
            Console.ResetColor();


            return i;
        }
    }
}
