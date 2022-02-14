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


        public void AddToShop(Item item)
        {
            this.shopItemList.Add(item);
        }

        public void RemoveFromShop(Item item)
        {
            this.shopItemList.Remove(item); 
        }

        public int ShowShopItemsList(int i)
        {
            Console.WriteLine("Swords: ");
            foreach (Item item in this.shopItemList)
            {

                if (item.GetType() == typeof(Sword))
                {
                    Console.WriteLine("{0}. {1}, attack value: {2}, {3} gold", i, item.name, item.stat, item.price);
                    i++;
                }

            }

            Console.WriteLine("Shields: ");
            foreach (Item item in this.shopItemList)
            {

                if (item.GetType() == typeof(Shield))
                {
                    Console.WriteLine("{0}. {1}, armor value: {2}, {3} gold", i, item.name, item.stat, item.price);
                    i++;
                }

            }

            Console.WriteLine("Breastplates: ");
            foreach (Item item in this.shopItemList)
            {

                if (item.GetType() == typeof(Breastplate))
                {
                    Console.WriteLine("{0}. {1}, hp value: {2}, {3} gold", i, item.name, item.stat, item.price);
                    i++;
                }

            }

            return i;
        }
    }
}
