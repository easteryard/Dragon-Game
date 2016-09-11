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

        Random rnd = new Random();

        string name;
        string ability;

        int playerDamage;
        int playerHit;
        int playerCrit;

        int heroicStrike;
        int mortalStrike;

        int HSCrit;
        int MSCrit;

        int playerHP = 30;

        int dragonDamage;
        int dragonCritDmg;
        int dragonHit;
        int dragonCrit;

        int dragonHP = 50;



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

            Console.WriteLine("\nYou're a brave one! What should I call you?");
            name = Console.ReadLine();
            Console.WriteLine("\nAlright, " + name + ", let's enter the dungeon.\n");
            Console.WriteLine("We've found the dragon! Take it down and you will be rewarded!\n");

            while (slaying == true)
            {
                heroicStrike = rnd.Next(3, 6);
                mortalStrike = rnd.Next(5, 8);

                HSCrit = heroicStrike * 2;
                MSCrit = mortalStrike * 2;

                playerHit = rnd.Next(10);
                playerCrit = rnd.Next(4);


                dragonDamage = rnd.Next(4, 9);
                dragonCritDmg = dragonDamage * 2;
                dragonHit = rnd.Next(4);
                dragonCrit = rnd.Next(8);

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

                if (playerHit != 0)
                {
                    if (playerCrit != 0)
                    {
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


                    }
                    else
                    {
                        if (ability == "Heroic Strike")
                        {
                            dragonHP -= HSCrit;
                            playerDamage = HSCrit;

                            Console.WriteLine("\nYou got a critical hit on the dragon for " + playerDamage + " with " + ability + "!");
                            Console.WriteLine("The dragon has " + dragonHP + " health left.\n");

                        }
                        else if (ability == "Mortal Strike")
                        {
                            dragonHP -= MSCrit;
                            playerDamage = MSCrit;

                            Console.WriteLine("\nYou got a critical hit on the dragon for " + playerDamage + " with " + ability + "!");
                            Console.WriteLine("The dragon has " + dragonHP + " health left.\n");
                        }
                    }

                    if (dragonHP <= 0)
                    {
                        Console.WriteLine("You slayed the dragon and took its head as a prize!");

                        slaying = false;
                    }
                }
                else
                {
                    Console.WriteLine("\nYour attack missed the dragon!\n");
                }

                if(slaying == true)
                {
                    startDragonAttack();
                }
            }
        }



        public void startDragonAttack()
        {
            if(dragonHit != 0)
            {
                if(dragonCrit != 0)
                {
                    if (dragonHP > 0)
                    {
                        playerHP -= dragonDamage;

                        Console.WriteLine("The dragon hit you for " + dragonDamage + " with its giant claw!");
                        Console.WriteLine("You have " + playerHP + " health left.\n");

                        if (playerHP <= 0)
                        {
                            Console.WriteLine("The dragon devours you!");
                            slaying = false;
                        }
                    }
                }
                else
                {
                    playerHP -= dragonCritDmg;
                    dragonDamage = dragonCritDmg;

                    Console.WriteLine("The dragon got a critical hit on you for " + dragonDamage + "!");
                    Console.WriteLine("You have " + playerHP + " health left.\n");
                }
            }
            else
            {
                Console.WriteLine("The dragon missed you!\n");
            }
        }
                
                
    }
}
