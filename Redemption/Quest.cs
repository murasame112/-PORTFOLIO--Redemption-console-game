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
            /*
            {Imię}, the Paladin. On the one hand, you find the sound of it pretty proud... but on the other, in your brotherhood it doesn't really mean anything. Most of the knights have their own titles, for which they are known - like master Buzan the Fearless, master Aurrius the Pure or lieutenant Guts the Dragonslayer. Getting a honorary title from the grandmaster means, that you have achieved something worth remembering - therefore, being just "the Paladin" equals not being worthy of any attention. 
            And yet, you will change that state of affairs pretty soon. You've been traveling for the last week to reach Reefsville - small town, somewhere on the kingdom's borderland. It has been known for quite long, since any caravan hans't returned from it's forest for a months. Merchants are terrified and have to travel through mountains, where bad weather doesn't allow any fragile goods to survive more than a day.
            Lepart Gemeaux, your senior-paladin has warned you before starting this quest. He didn't tell you that you shouldn't go, but he said that he feels something "purely bad and dark" coming from these woods... Well. You are a paladin, thus you must not be afraid. After expressing gratitude towards your senior, you've started preparing for the travel.
            They were already waiting for you in the town. Rumors about traveling knight must have been faster than your steed. Anyway, as soon as you walked through the gates, the town elder have reached you and started talking about frightening cave inside the forest and a monster that lives there. Well then, it seems like it's going to be a quick job. This is the day, when mere paladin named {imię} will become a well known knight!
            */

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("{0}, the Paladin", character.name);
            Console.ResetColor();
            Console.WriteLine(". On the one hand, you find the sound of it pretty proud... but on the other,");
            Console.WriteLine("in your brotherhood it doesn't really mean anything. Most of the knights have their own titles,");
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
            Console.WriteLine("lieutenant");
            Console.Write("Guts the Dragonslayer");
            Console.ResetColor();
            Console.WriteLine(". Getting a honorary title from the grandmaster means, that you have achieved");
            Console.Write("something worth remembering - therefore, being just " );
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
            Console.WriteLine("quite long, since any caravan hasn't returned from it's forest for a months. Merchants are terrified");
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
            Console.Write("then, it seems like it's going to be a quick job. This is the day, when mere paladin named ");
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
            Console.WriteLine();

            /*
            But... after killing this monster you feel something dark affecting your spirit.
            You know, that it's not a good power... but you also know, that this is what you've been always
            looking for. Now, even ghosts in nearby ruins won't be strong enough to stop you. 
            */

            Console.Write("But... after killing this monster you feel something ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("dark");
            Console.ResetColor();
            Console.WriteLine(" affecting your spirit.");
            Console.WriteLine("You know, that it's not a good power... but you also know, that this is what you've been always");
            Console.WriteLine("looking for. Now, even ghosts in nearby ruins won't be strong enough to stop you.");
            Console.WriteLine();

            Console.Write("You've received a new spell - ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Dark Surge [+4 damage, 2 hp] (enchance your sword with dark energy, coming from your soul).");
            Console.ResetColor();
            character.spells.Add(() => character.DarkSurge(target));
            character.spellsString.Add("Dark Surge [+4 damage, 2 hp] (enchance your sword with dark energy, coming from your soul).");
            this.finished = true;
        }

    }
}
