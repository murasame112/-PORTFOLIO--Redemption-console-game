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
        public List<string> genericMobNames;
        public string name {get; set;}
        public string[] places { get; set; }
        public bool civilized { get; set; }
        public int locationLevel { get; set; }

        // Starting location
        public Location()
        {
            this.name = "Town";
            this.civilized = true;
            this.places = new string[1];
            places[0] = "Forest [level 1]";
            this.genericMobNames = new List<string>();
        }

        // Current location (and "what to do")
        public void Idle(Character character, Mob mob, Shop shop, Quest quest)
        {
            // You are in {place name}. What now?
            Console.ResetColor();
            Console.Write("You are in ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}", this.name);
            Console.ResetColor();
            Console.WriteLine(". What now?");
            if (this.civilized != true) { Console.WriteLine("1. Search for a monster"); }
            else { Console.WriteLine("1. Go to shop"); }
            Console.WriteLine("2. Go to another place");
            Console.WriteLine("3. Show your stats");
            Console.WriteLine();
            int answer = 1;
            do
            {   
                Console.Write("Your choice: ");
                if(answer != 1 && answer != 2 && answer != 3) { Console.Write("(choose correct number) "); }
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());
                }catch (FormatException)
                {
                    answer = 0;
                }
                

            } while (answer != 1 && answer != 2 && answer != 3);
            Console.WriteLine();         
            switch (answer)
            {
                case 1:
                    if (this.civilized != true) { character.SpotEnemy(mob, this, quest); }
                    else if (this.civilized == true) { character.GoShopping(shop); }
                    break;
                case 2:
                    this.ChooseLocation();
                    break;
                case 3:
                    character.ShowStats();
                    break;
            }
        }

        // Choose place to go
        public void ChooseLocation()
        {
            int i = 1;
            Console.WriteLine("So, where do you want to go?");
            foreach(string place in this.places)
            {
                // {i}. {place}.
                Console.ResetColor();
                Console.Write("{0}. ", i);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("{0}", place);
                Console.ResetColor();
                Console.WriteLine(".");
                i++;
            }
            Console.WriteLine();

            int answer = 1;
            do
            {
                Console.Write("Your choice: ");
                if (answer < 1 || answer > i) { Console.Write("(choose correct number) "); }
                try
                {
                    answer = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    answer = 0;
                }
            } while (answer < 1 || answer > i);

            this.GenerateLocation(places[answer-1]);
        }

        // Travelling to another location
        public void GenerateLocation(string locationName)
        {
            int index = locationStrings.FindIndex(locationStrings => locationStrings.Contains(locationName));
            locationActions[index]();

            // You travel to {location name}.
            Console.ResetColor();
            Console.Write("You travel to ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}", this.name);
            Console.ResetColor();
            Console.WriteLine(".");
            Console.WriteLine();
        }

        // Go to the Town (called by GenerateLocation)
        public void GoToTown(Location location)
        {
            location.name = "Town";
            location.civilized = true;
            location.places = new string[1];
            location.places[0] = "Forest [level 1]";
            location.locationLevel = 1;
        }

        // Go to the Forest (called by GenerateLocation)
        public void GoToForest(Location location)
        {
            location.name = "Forest";
            location.civilized = false;
            location.places = new string[3];
            location.places[0] = "Town";
            location.places[1] = "Cave [level 3]";
            location.places[2] = "Old Ruins [level 5]";
            // ^ levele?
            location.locationLevel = 1;
            this.genericMobNames.Clear();
            this.genericMobNames.Add("Goblin Gatherer");
            this.genericMobNames.Add("Feral Wolf");
            this.genericMobNames.Add("Goblin Soldier");
        }

        // Go to the Cave (called by GenerateLocation)
        public void GoToCave(Location location)
        {
            location.name = "Cave";
            location.civilized = false;
            location.places = new string[1];
            location.places[0] = "Forest [level 1]";
            location.locationLevel = 3;
            this.genericMobNames.Clear();
            this.genericMobNames.Add("Goblin Guardian");
            this.genericMobNames.Add("Goblin Warrior");
        }

        // Go to the Old Ruins (called by GenerateLocation)
        public void GoToOldRuins(Location location)
        {
            location.name = "Old Ruins";
            location.civilized = false;
            location.places = new string[1];
            location.places[0] = "Forest [level 1]";
            location.locationLevel = 5;
            this.genericMobNames.Clear();
            this.genericMobNames.Add("Ghost of the Scribe");
            this.genericMobNames.Add("Ghost of the Servant");
            this.genericMobNames.Add("Ghost of the Squire");
        }




    }
}
