using System;
using System.Linq;

namespace Redemption
{

    /*
    mechanika:
        - postać leczy się po każdej walce do full hp
        - każdy item odpowiada za zwiększanie jednej ze statystyk
        - przeciwnicy nie mają itemów, ale mają mocniejsze staty (moga byc defaultowo liczone ze wzoru zaleznie od levela)

    todo:
        - generowanie miejsc? (miastezcko ze sklepem, pobliski dungeon czy inny las)
        - generowanie przeciwników i walka z nimi
        - dodanie kropek na końcu wypowiedzi
        - loot
        - spelle (https://stackoverflow.com/questions/23437970/how-to-create-a-list-of-methods-then-execute-them/23437985)
        - mechanizm ucieczki (jaka kara za ucieczke?)
        - exp (i bohater i moby mogą mieć exp. zabijając moba bohater dostaje jego exp). bohater posiada max exp (skalowany z levelem). po walce sprawdzanie max expa i jak przekroczony to level up

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
            

            Item basicSword = new Sword("Basic Sword", 2);
            Item brokenSword = new Sword("Broken Sword", 1);
            Item omniblade = new Sword("Omniblade", 10);


            playerCharacter.ReceiveItem(basicSword);
            

            Mob goblin = new Mob();
            goblin.CreateGenericMob( 1, "Goblin named Gayer");

            playerCharacter.Fight(playerCharacter, goblin);

            

            










        }
    }
}
