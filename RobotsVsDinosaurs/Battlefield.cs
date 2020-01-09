using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Battlefield
    {
        public Herd dinosaurs; //Dinosaur heard instance
        public Fleet robots; //Robot fl
        

        public Battlefield(Herd dinosCreator, Fleet robosCreator)
        {
            dinosaurs = dinosCreator;
            robots = robosCreator;
        }

        public void setPlayers(Herd dinos, Fleet robos)
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
                



            
        }

        public void Battle()
        {

            

            do
            {

                Console.Clear();
                if(robots.player && dinosaurs.player)
                {
                    Console.WriteLine(robots.getFleetStats());
                    robots.attackSequence(dinosaurs);
                    dinosaurs.attackSequence(robots);
                }
                else if (robots.player)
                {
                    Console.WriteLine(robots.getFleetStats());
                    robots.attackSequence(dinosaurs);
                    dinosaurs.attackSequence(robots);
                }
                else if (dinosaurs.player)
                {
                    Console.WriteLine(dinosaurs.getHerdStats());
                    dinosaurs.attackSequence(robots);
                    robots.attackSequence(dinosaurs);
                }
                



                int deathToll = 0;
                foreach (Dinosaur dino in dinosaurs.dinoHerd)
                {
                    if (dino.health > 0)
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
                    Console.WriteLine("\nRobots win!");
                    break;
                }

                deathToll = 0;
                foreach (Robot robo in robots.roboFleet)
                {
                    if (robo.health > 0)
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
                    Console.WriteLine("\nDinoSaurs win!");
                    break;
                }


                Console.WriteLine("\nPress Enter to start the next turn");
                Console.ReadLine();

            } while (true);
            Console.ReadLine();
            
        }
    }
}
