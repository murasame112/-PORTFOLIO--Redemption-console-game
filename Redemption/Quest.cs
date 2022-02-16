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


        public void SetKill5CaveMonsters()
        {
            this.name = "Clear the Cave";
            this.finished = false;
            this.counter = 0;
            this.counterMax = 5;
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
