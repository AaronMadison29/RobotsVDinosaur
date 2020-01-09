using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Herd
    {
        public List<Dinosaur> dinoHerd = new List<Dinosaur>();
        public bool player;

        public Herd()
        {
            Dinosaur dinoOne = new Dinosaur("T-Rex", 2);
            Dinosaur dinoTwo = new Dinosaur("Raptor", 4);
            Dinosaur dinoThree = new Dinosaur("Pteradactyl", 6);

            dinoHerd.Add(dinoOne);
            dinoHerd.Add(dinoTwo);
            dinoHerd.Add(dinoThree);


        }

        public string getHerdStats()
        {
            string herdStats = "";

            foreach (Dinosaur dino in dinoHerd)
            {
                if (dino.health <= 0)
                {
                    herdStats = herdStats + dino.type + ":KO ";
                }
                else
                {
                    herdStats = herdStats + dino.type + ":" + dino.health + "HP ";
                }

            }

            return herdStats;
        }

        public void attackSequence(Fleet targetFleet)
        {

            if (player == false)
            {
                for (int i = 0; i < dinoHerd.Count; i++)
                {
                    if (dinoHerd[i].health > 0)
                    {
                        if (targetFleet.roboFleet[0].health > 0)
                        {
                            dinoHerd[i].Attack(targetFleet.roboFleet[0]);
                            break;
                        }
                        else if (targetFleet.roboFleet[1].health > 0)
                        {
                            dinoHerd[i].Attack(targetFleet.roboFleet[1]);
                            break;
                        }
                        else if (targetFleet.roboFleet[2].health > 0)
                        {
                            dinoHerd[i].Attack(targetFleet.roboFleet[2]);
                            break;
                        }
                    }
                }
            }
            else
            {
                bool playerRunning = true;
                

                for (int i = 0; i < dinoHerd.Count(); i++)
                {
                    do
                    {

                        playerRunning = true;

                        Console.WriteLine("Who should " + dinoHerd[i].type + " attack?");
                        if (targetFleet.roboFleet[0].health >= 0)
                        {
                            Console.WriteLine("1:" + targetFleet.roboFleet[0].name + "(" + targetFleet.roboFleet[0].health + " HP)");
                        }
                        else
                        {
                            Console.WriteLine("1:" + targetFleet.roboFleet[0].name + "(KO)");
                        }

                        if (targetFleet.roboFleet[1].health >= 0)
                        {
                            Console.WriteLine("2:" + targetFleet.roboFleet[1].name + "(" + targetFleet.roboFleet[1].health + " HP)");
                        }
                        else
                        {
                            Console.WriteLine("2:" + targetFleet.roboFleet[1].name + "(KO)");
                        }
                        if (targetFleet.roboFleet[2].health >= 0)
                        {
                            Console.WriteLine("3:" + targetFleet.roboFleet[2].name + "(" + targetFleet.roboFleet[2].health + " HP)");
                        }
                        else
                        {
                            Console.WriteLine("3:" + targetFleet.roboFleet[2].name + "(KO)");
                        }
                        string target = Console.ReadLine();

                        switch (target)
                        {
                            case "1":
                                if (targetFleet.roboFleet[0].health > 0)
                                {
                                    dinoHerd[i].Attack(targetFleet.roboFleet[0]);
                                    playerRunning = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine(targetFleet.roboFleet[0].name + " has already been defeated, please choose another dino");
                                }
                                break;
                            case "2":
                                if (targetFleet.roboFleet[1].health > 0)
                                {
                                    dinoHerd[i].Attack(targetFleet.roboFleet[1]);
                                    playerRunning = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine(targetFleet.roboFleet[1].name + " has already been defeated, please choose another dino");
                                }
                                break;
                            case "3":
                                if (targetFleet.roboFleet[2].health > 0)
                                {
                                    dinoHerd[i].Attack(targetFleet.roboFleet[2]);
                                    playerRunning = false;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine(targetFleet.roboFleet[2].name + " has already been defeated, please choose another dino");
                                }
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Please choose a valid Dino");
                                break;
                        }

                    } while (playerRunning);

                    if (!playerRunning)
                    {
                        break;
                    }
                }

                return;
            }
            
            return;
        }
    }
}
