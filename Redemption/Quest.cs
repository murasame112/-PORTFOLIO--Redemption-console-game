using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redemption
{
    public class Quest
    {
        public string name { get; set; }
        public bool finished { get; set; }
        public int counter { get; set; }
        public int counterMax { get; set; }


        public void SetKill5CaveMonsters(Character character)
        {
            this.name = "Clear the Cave";
            this.finished = false;
            this.counter = 0;
            this.counterMax = 5;
            StartPlotQuest1(character);
        }

        public void StartPlotQuest1(Character character)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}, the Paladin", character.name);
            Console.ResetColor();
            Console.WriteLine(". On the one hand, you find the sound of it pretty proud... but on the other,");
            Console.WriteLine("in your brotherhood it doesn't really mean anything. All these noble knights have their own titles,");
            Console.Write("for which they are known - like ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("master Buzan the Fearless");
            Console.ResetColor();
            Console.Write(", ");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("master Aurrius the Pure");
            Console.ResetColor();
            Console.Write(" or ");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" lieutenant");
            Console.Write("Guts the Dragonslayer");
            Console.ResetColor();
            Console.WriteLine(". Getting a honorary title from the grandmaster means, that you have achieved");
            Console.Write("something worth remembering - therefore, being just" );
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("'the Paladin'");
            Console.ResetColor();
            Console.WriteLine(" equals not being worthy of any ");
            Console.WriteLine("attention.");
            Console.WriteLine("And yet, you will change that state of affairs pretty soon. You've been traveling for the last week ");
            Console.Write("to reach ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("Reefsville");
            Console.ResetColor();
            Console.WriteLine(" - small town, somewhere on the kingdom's borderland. It has been known for");
            Console.WriteLine("quite long, since any caravan has't returned from it's forest for a months. Merchants are terrified");
            Console.WriteLine("and have to travel through mountains, where bad weather doesn't allow any fragile goods to survive ");
            Console.WriteLine("more than a day.");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("Lepart Gemeaux");
            Console.ResetColor();
            Console.WriteLine(", your senior-paladin has warned you before starting this quest. He didn't tell you");
            Console.WriteLine("that you shouldn't go, but he said that he feels something 'purely bad and dark' coming from these");
            Console.WriteLine("woods... Well. You are a paladin, thus you must not be afraid. After expressing gratitude towards");
            Console.WriteLine("your senior, you've started preparing for the travel.");
            Console.WriteLine("They were already waiting for you in the town. Rumors about traveling knight must have been faster");
            Console.WriteLine("than your steed. Anyway, as soon as you walked through the gates, the town elder have reached you ");
            Console.WriteLine("and started talking about frightening cave inside the forest and a monster that lives there. Well");
            Console.Write("then, it seems like it's going to be a quick job. This is the day, when mere paladin named");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("{0}", character.name);
            Console.ResetColor();
            Console.WriteLine("will become a well known knight!");
            Console.WriteLine();
        }

        public void FinishQuest1(Character character, Mob target)
        {
            
            Console.ResetColor();
            Console.Write("Quest ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("'{0}'", this.name);
            Console.ResetColor();
            Console.WriteLine(" finished.");

            Console.WriteLine("But... after killing this monster you feel something [DARK] affecting your spirit.");

            character.spells.Add(() => character.DarkSurge(target));
            character.spellsString.Add("Dark Surge [+4 damage, 2 hp] (enchance your sword with dark energy, coming from your soul).");
            this.finished = true;
        }

    }
}
