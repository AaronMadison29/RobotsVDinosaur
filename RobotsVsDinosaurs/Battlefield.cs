using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Battlefield
    {
        public FighterGroup dinosaurs; //Dinosaur heard instance
        public FighterGroup robots; //Robot fl
        

        public Battlefield(Herd dinosCreator, Fleet robosCreator)
        {
            dinosaurs = dinosCreator;
            robots = robosCreator;
        }

        public void SetPlayers(Herd dinos, Fleet robos)
        {
            while(true)
            {
                Console.WriteLine("How many players?: ");
                string players = Console.ReadLine();

                if(players == "2")
                {
                    dinos.player = true;
                    robos.player = true;
                    break;
                }
                else if(players == "1")
                {
                    while(true)
                    {
                        Console.WriteLine("Would you like to play as the Robots or the Dinosaurs?:");
                        Console.WriteLine("1: Robots\n2: Dinosaurs");
                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                robos.player = true;
                                break;
                            case "2":
                                dinos.player = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option");
                                continue;
                        }
                        if(robos.player == true || dinos.player == true)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid option");
                    continue;
                }
                if (robos.player == true || dinos.player == true)
                {
                    break;
                }
            }
            Console.Clear();
        }

        public bool IsGameOver()
        {
            int deathToll = 0;
            foreach (Fighter fighter in dinosaurs.group)
            {
                if (fighter.health > 0)
                {
                    break;
                }
                else
                {
                    deathToll++;
                }

            }
            if (deathToll == 3)
            {
                Console.Clear();
                Console.WriteLine(dinosaurs.GetStats());
                Console.WriteLine(robots.GetStats() + "\n");
                Console.WriteLine("\nRobots win!");
                return true;
            }

            deathToll = 0;
            foreach (Fighter fighter in robots.group)
            {
                if (fighter.health > 0)
                {
                    break;
                }
                else
                {
                    deathToll++;
                }

            }
            if (deathToll == 3)
            {
                Console.WriteLine("\nDinoSaurs win!");
                return true;
            }

            return false;
        }

        public void Battle()
        {

            

            do
            {

                if(robots.player && dinosaurs.player)
                {
                    Console.WriteLine(robots.GetStats()+ "\n");
                    robots.AttackSequence(dinosaurs);
                    Console.WriteLine(dinosaurs.GetStats() + "\n");
                    dinosaurs.AttackSequence(robots);
                }
                else if (robots.player)
                {
                    Console.WriteLine(robots.GetStats() + "\n");
                    robots.AttackSequence(dinosaurs);
                    dinosaurs.AttackSequence(robots);
                }
                else if (dinosaurs.player)
                {
                    Console.WriteLine(dinosaurs.GetStats() + "\n");
                    dinosaurs.AttackSequence(robots);
                    robots.AttackSequence(dinosaurs);
                }

                if(IsGameOver())
                {
                    break;
                }

                Console.WriteLine("\nPress Enter to start the next turn");
                Console.ReadLine();
                Console.Clear();

            } while (true);
            Console.ReadLine();
            
        }
    }
}
