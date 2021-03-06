using System;
using System.Collections.Generic;
using System.Linq;

namespace Redemption
{
    // I know that quests don't look as they should... but I don't really know how to make it proper way :(

    /*
    Blue		- item names
    Cyan 		- experience
    DarkBlue	- mana
    DarkCyan	- atk
    DarkGray 	- mob names
    DarkGreen	- player name, location names
    DarkMagenta - armor
    DarkRed		- hp
    DarkYellow	- gold
    Green 		- "happy" text, heal
    Magenta 	- spell names
    Red			- "angry" text, damage 
    Yellow 		- level up, level
    */


    class Program
    {
        
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("As a paladin I don't fear falling... I look forward to it. - Nedlim the Seeker");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();


            
            Character playerCharacter = new Character();
            playerCharacter.CreateCharacter();
            Location location = new Location();
            Shop shop = new Shop();
            Mob target = new Mob();
            Quest quest = new Quest();

            // Creating few items and adding them to created shop
            Item basicSword = new Sword("Basic Sword", 2, 3);
            Item greatSword = new Sword("Greatsword", 3, 6);
            Item claymore = new Sword("Claymore", 5, 12);
            Item omniblade = new Sword("Omniblade", 10, 35);

            Item buckler = new Shield("Buckler", 1, 8);
            Item spellShield = new Shield("Spell Shield", 2, 15);

            Item leatherArmor = new Breastplate("Leather Armor", 4, 8);
            Item scaleBreastplate = new Breastplate("Scale Breastplate", 8, 16);
            Item chainmail = new Breastplate("Chainmail", 12, 30);

            shop.AddToShop(basicSword);
            shop.AddToShop(greatSword);
            shop.AddToShop(claymore);
            shop.AddToShop(omniblade);
            shop.AddToShop(buckler);
            shop.AddToShop(spellShield);
            shop.AddToShop(leatherArmor);
            shop.AddToShop(scaleBreastplate);
            shop.AddToShop(chainmail);

            // Giving player basic spells
            playerCharacter.spells.Add(() => playerCharacter.TideThrust(target));
            playerCharacter.spells.Add(playerCharacter.Rathonhnhaketon);
            playerCharacter.spellsString.Add("Tide Thrust [+1 damage, 5 mana] (move your blade like wave, to make lunge stronger than usual attack).");
            playerCharacter.spellsString.Add("Rathonhnhake-ton [40% heal, 10 mana] (perform a quick ritual, that will restore your health).");

            // Creating locations
            location.locationStrings.Add("Town");
            location.locationActions.Add(() => location.GoToTown(location));
            location.locationStrings.Add("Forest [level 1]");
            location.locationActions.Add(() => location.GoToForest(location));
            location.locationStrings.Add("Cave [level 3]");
            location.locationActions.Add(() => location.GoToCave(location));
            location.locationStrings.Add("Old Ruins [level 5]");
            location.locationActions.Add(() => location.GoToOldRuins(location));

            playerCharacter.items[0] = basicSword;
            playerCharacter.UpdateStats();
            // Creating quests
            quest.SetKill5CaveMonsters(playerCharacter);

            while (true)
            {
                
                location.Idle(playerCharacter, target, shop, quest);

            }
            








        }
    }
}
