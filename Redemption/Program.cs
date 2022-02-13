using System;
using System.Collections.Generic;
using System.Linq;

namespace Redemption
{

    /*
    mechanika:
        - postać leczy się po każdej walce do full hp
        - każdy item odpowiada za zwiększanie jednej ze statystyk
        - przeciwnicy nie mają itemów, ale mają mocniejsze staty (moga byc defaultowo liczone ze wzoru zaleznie od levela)

    todo:
        - przypisac lokacjom sredni level mobow jakie tam są
        - spot enemy
        - sklep
        - dodanie kropek na końcu wypowiedzi
        - mechanizm ucieczki (jaka kara za ucieczke?)
        - mana? możliwość użycia x spelli na walkę? (tyle ile level lub level *2)?
        - dopilnowac, by tam gdzie gracz cos wprowadza nie bylo bledow (ze np zamiast 1 lub 2 poda liczbe 33 lub napisze "żuraw")
        - dodać mozliwosc anulowania spella zeby np wybrac jednak atak
        
    fabuła:
        - na poczatku cytat nedlima, "asdf asdf" ~ Nedlim the Lightbringer (uzyc innego slowa)
        - po zabiciu jakeigoś bossa mozemy zmienic sie w Dark Paladina - zabijajc bossa wyzwalamy jakas moc czy cos ktora mowi, ze zastapi nam swiatlosc
     */

    class Program
    {
        static void Main(string[] args)
        {
            
            Character playerCharacter = new Character();
            playerCharacter.CreateCharacter(playerCharacter);

            Location location = new Location();
            

            Item basicSword = new Sword("Basic Sword", 2);
            Item greatsword = new Sword("Greatsword", 3);
            Item claymore = new Sword("Claymore", 5);
            Item omniblade = new Sword("Omniblade", 10);
            Mob target = new Mob();
            
            playerCharacter.spells.Add(() => playerCharacter.TideThrust(target));
            playerCharacter.spells.Add(playerCharacter.Rathonhnhaketon);
            playerCharacter.spellsString.Add("Tide Thrust (move your blade like wave, to make lunge stronger than usual attack [+1 damage]).");
            playerCharacter.spellsString.Add("Rathonhnhake-ton (perform a quick ritual, that will restore your health [20% heal]).");
            playerCharacter.ReceiveItem(basicSword);
            

            Mob goblin = new Mob();
            
            goblin.CreateGenericMob( 2, "Goblin named Gobberton");
            target = goblin;
            //playerCharacter.Fight(playerCharacter, target);

            
            location.locationStrings.Add("Town");
            location.locationActions.Add(() => location.GoToTown(location));
            location.locationStrings.Add("Forest");
            location.locationActions.Add(() => location.GoToForest(location));
            location.locationStrings.Add("Cave");
            location.locationActions.Add(() => location.GoToCave(location));
            
            while(true)
            {
                location.Idle(playerCharacter, target);

            }













        }
    }
}
