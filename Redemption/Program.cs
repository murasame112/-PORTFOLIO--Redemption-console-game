using System;
using System.Collections.Generic;
using System.Linq;

namespace Redemption
{

    /*
    Console.ForegroundColor = ConsoleColor.Green; 
    Console.ResetColor();

    mechanika:
        - postać leczy się po każdej walce do full hp
        - każdy item odpowiada za zwiększanie jednej ze statystyk
        - przeciwnicy nie mają itemów, ale mają mocniejsze staty (moga byc defaultowo liczone ze wzoru zaleznie od levela)

    todo:
        - boss w jaskini? po np zabiciu 5 mobów? (QUESTY)
        
        - kolory w character

        - dopilnowac, by tam gdzie gracz cos wprowadza nie bylo bledow (ze np zamiast 1 lub 2 poda liczbe 33 lub napisze "żuraw")
        - OGÓLNE REDAGOWANIE TEKSTÓW (KROPKI, KOLORY LITER, ODPOWIEDNIE WCIĘCIA ITP.)
        - SPRZĄTANIE KODU (FUNKCJE W ODPOWIEDNIEJ KOLEJNOŚCI, ESTETYKA, REFAKTORYZACJA)
        
    fabuła:
        - na poczatku cytat nedlima, "asdf asdf" ~ Nedlim the Lightbringer (uzyc innego slowa)
        - po zabiciu jakeigoś bossa mozemy zmienic sie w Dark Paladina - zabijajc bossa wyzwalamy jakas moc czy cos ktora mowi, ze zastapi nam swiatlosc
        - dark paladin ma spelle kosztujące hp (nie zawsze, ale niektore)
     */

    class Program
    {
        static void Main(string[] args)
        {

            Character playerCharacter = new Character();
            playerCharacter.CreateCharacter();

            Location location = new Location();
            Shop shop = new Shop();
            Mob target = new Mob();

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

            playerCharacter.spells.Add(() => playerCharacter.TideThrust(target));
            playerCharacter.spells.Add(playerCharacter.Rathonhnhaketon);
            playerCharacter.spellsString.Add("Tide Thrust [+1 damage, 5 mana] (move your blade like wave, to make lunge stronger than usual attack).");
            playerCharacter.spellsString.Add("Rathonhnhake-ton [40% heal, 10 mana] (perform a quick ritual, that will restore your health).");

            location.locationStrings.Add("Town");
            location.locationActions.Add(() => location.GoToTown(location));
            location.locationStrings.Add("Forest");
            location.locationActions.Add(() => location.GoToForest(location));
            location.locationStrings.Add("Cave");
            location.locationActions.Add(() => location.GoToCave(location));


            //playerCharacter.ReceiveItem(basicSword);

            while (true)
            {
                // if( warunek questa) // dzieje sie spotkanie bossa
                location.Idle(playerCharacter, target, shop);

            }













        }
    }
}
