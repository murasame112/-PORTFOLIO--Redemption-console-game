using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Location
    {

        public List<string> locationStrings = new List<string>();
        public List<Action> locationActions = new List<Action>();
        public string name {get; set;}
        public string[] places { get; set; }
        public bool civilized { get; set; }
        public int locationLevel { get; set; }


        public Location()
        {
            this.name = "Town";
            this.civilized = true;
            this.places = new string[1];
            places[0] = "Forest";

        }

        public void CreateLocation(string locationName, Action locationMethod)
        {
            //list 1 add string
            //list 2 add action (parametry places?)
        }

        public void ChooseLocation()
        {
            Location location = this;
            int i = 1;
            Console.WriteLine();
            Console.WriteLine("So, where do you want to go?");
            foreach(string place in this.places)
            {
                Console.WriteLine("{0}. {1}", i, place);
                i++;
            }
            Console.Write("Your choice: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            GenerateLocation(places[answer-1], location);

        }

        public void GenerateLocation(string locationName, Location location)
        {
            Console.WriteLine("You travel to {0}", locationName);
            int index = locationStrings.FindIndex(locationStrings => locationStrings.Contains(locationName));
            locationActions[index]();

        }

        public void GoToTown(Location location)
        {
            location.name = "Town";
            location.civilized = true;
            location.places = new string[1];
            location.places[0] = "Forest";
            location.locationLevel = 1;
            
        }
        
        public void GoToForest(Location location)
        {
            location.name = "Forest";
            location.civilized = false;
            location.places = new string[2];
            location.places[0] = "Town";
            location.places[1] = "Cave";
            location.locationLevel = 1;

        }

        public void GoToCave(Location location)
        {
            location.name = "Cave";
            location.civilized = false;
            location.places = new string[1];
            location.places[0] = "Forest";
            location.locationLevel = 3;

        }

        public void Idle(Character character, Mob mob, List<Item> shopItemList)
        {
            Console.WriteLine();
            Console.WriteLine("What now? You are in {0}", this.name);
            if (this.civilized != true) { Console.WriteLine("1. Search for a monster."); }
            else { Console.WriteLine("1. Go to shop."); }
            Console.WriteLine("2. Go to another place.");
            Console.WriteLine("3. Show your stats.");
            Console.Write("Your choice: ");
            int answer = Convert.ToInt32(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    if(this.civilized != true) { character.SpotEnemy(mob, this.locationLevel); }
                    else if(this.civilized==true) { character.GoShopping(shopItemList); }
                    break;
                case 2:
                    this.ChooseLocation();
                    break;
                case 3:
                    character.ShowStats();
                    break;
            }


        }


    }
}
