using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragon_Game
{
    class Game
    {
        Boolean slaying = true;

        int playerHP = 30;
        int heroicStrike = 3;
        int mortalStrike = 5;

        int dragonHP = 50;
        int dragonHit = 3;

        public void startGame()
        {
            string answer;

            Console.WriteLine("Welcome! Are you brave enough to fight what lies within this dungeon?");
            answer = Console.ReadLine();

            if (answer == "Yes" || answer == "yes")
            {
                yesAnswer();
            }
            else
            {
                Console.WriteLine("Wise choice - this is a dangerous place!");
            }
        }

        public void yesAnswer()
        {
            string name;

            Console.WriteLine("\nYou're a brave one! What should I call you?");
            name = Console.ReadLine();
            Console.WriteLine("\nAlright, " + name + ", let's enter the dungeon.\n");
            Console.WriteLine("We've found the dragon! Take it down and you will be rewarded!\n");

            while (slaying == true)
            {
                string ability;
                int playerDamage = 0;

                Console.WriteLine("Do you wish to use Heroic Strike or Mortal Strike?");
                ability = Console.ReadLine();

                for (int i = 0; i < 1000; i++)
                {
                    if (ability == "Heroic Strike" || ability == "Mortal Strike")
                    {
                        i = 1000;
                    }
                    else
                    {
                        Console.WriteLine("\nYou didn't chose one of the two options. Pick again.");
                        ability = Console.ReadLine();
                    }
                }

                if (ability == "Heroic Strike")
                {
                    dragonHP -= heroicStrike;
                    playerDamage = heroicStrike;
                }
                else if (ability == "Mortal Strike")
                {
                    dragonHP -= mortalStrike;
                    playerDamage = mortalStrike;
                }

                Console.WriteLine("\nYou hit the dragon for " + playerDamage + " with " + ability + "!");
                Console.WriteLine("The dragon has " + dragonHP + " health left.\n");

                if(dragonHP <= 0)
                {
                    slaying = false;

                    Console.WriteLine("You slayed the dragon and took its head as a prize!");
                }
                
                if(dragonHP > 0)
                {
                    playerHP -= dragonHit;

                    Console.WriteLine("The dragon hit you for " + dragonHit + " with its giant claw!");
                    Console.WriteLine("You have " + playerHP + " health left.\n");

                    if(playerHP <= 0)
                    {
                        Console.WriteLine("The dragon devours you!");
                        slaying = false;
                    }
                }
            }
        }
    }
}
