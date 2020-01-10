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

        public void rest(Dinosaur dinoIn)
        {
            foreach (Dinosaur dino in dinoHerd)
            {
                if (!dino.attacker)
                {
                    if(dino.energy < dino.maxEnergy)
                    {
                        dino.energy++;
                    }
                }
                else
                {
                    dinoIn.attacker = false;
                }
            }
        }

        public bool checkHealth(Dinosaur dinoIn)
        {
            if (dinoIn.health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool checkEnergy(Dinosaur dinoIn)
        {
            if (dinoIn.energy <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
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
                    herdStats = herdStats + dino.type + ":" + dino.health + "HP " + dino.energy + "E ";
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
                    if (checkHealth(dinoHerd[i]) && checkEnergy(dinoHerd[i]))
                    {
                        if (targetFleet.roboFleet[0].health > 0)
                        {
                            dinoHerd[i].Attack(targetFleet.roboFleet[0]);
                            rest(dinoHerd[i]);
                            break;
                        }
                        else if (targetFleet.roboFleet[1].health > 0)
                        {
                            dinoHerd[i].Attack(targetFleet.roboFleet[1]);
                            rest(dinoHerd[i]);
                            break;
                        }
                        else if (targetFleet.roboFleet[2].health > 0)
                        {
                            dinoHerd[i].Attack(targetFleet.roboFleet[2]);
                            rest(dinoHerd[i]);
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

                        if(!checkHealth(dinoHerd[i]))
                        {
                            break;
                        }
                        if(!checkEnergy(dinoHerd[i]))
                        {
                            break;
                        }

                        playerRunning = true;

                        Console.WriteLine("Who should " + dinoHerd[i].type + " attack?");
                        if (targetFleet.roboFleet[0].health >= 0)
                        {
                            Console.WriteLine("1:" + targetFleet.roboFleet[0].name + "(" + targetFleet.roboFleet[0].health + " HP " + targetFleet.roboFleet[0].powerLevel + "E)");
                        }
                        else
                        {
                            Console.WriteLine("1:" + targetFleet.roboFleet[0].name + "(KO)");
                        }

                        if (targetFleet.roboFleet[1].health >= 0)
                        {
                            Console.WriteLine("2:" + targetFleet.roboFleet[1].name + "(" + targetFleet.roboFleet[1].health + " HP " + targetFleet.roboFleet[1].powerLevel + "E)");
                        }
                        else
                        {
                            Console.WriteLine("2:" + targetFleet.roboFleet[1].name + "(KO)");
                        }
                        if (targetFleet.roboFleet[2].health >= 0)
                        {
                            Console.WriteLine("3:" + targetFleet.roboFleet[2].name + "(" + targetFleet.roboFleet[2].health + " HP " + targetFleet.roboFleet[2].powerLevel + "E)");
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
                                    Console.WriteLine(targetFleet.roboFleet[2].name + " has already been defeated, please choose another dino");
                                }
                                break;
                            default:
                                Console.WriteLine("Please choose a valid Dino");
                                break;
                        }

                    } while (playerRunning);

                    if (!playerRunning)
                    {
                        rest(dinoHerd[i]);
                        break;
                    }
                }

                return;
            }
            
            return;
        }
    }
}
