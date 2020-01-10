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
            Dinosaur dinoOne = new Dinosaur("trex", 2);
            Dinosaur dinoTwo = new Dinosaur("raptor", 4);
            Dinosaur dinoThree = new Dinosaur("turkey", 6);

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
            bool playerRunning = true;
            if (player == false)
            {
                

                for (int i = 0; i < dinoHerd.Count; i++)
                {
                    if (checkHealth(dinoHerd[i]) && checkEnergy(dinoHerd[i]))
                    {
                        foreach (Robot robo in targetFleet.roboFleet)
                        {
                            if (robo.health > 0)
                            {
                                dinoHerd[i].weaponSwap();
                                dinoHerd[i].Attack(robo);
                                rest(dinoHerd[i]);
                                playerRunning = false;
                                break;
                            }
                        }
                        if(!playerRunning)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {

                for (int i = 0; i < dinoHerd.Count(); i++)
                {
                    do
                    {

                        Console.WriteLine("Who should " + dinoHerd[i].type + " attack?");

                        foreach (Robot robo in targetFleet.roboFleet)
                        {
                            if (robo.health >= 0)
                            {
                                Console.WriteLine(robo.name + "(" + robo.health + " HP " + robo.powerLevel + "E)");
                            }
                            else
                            {
                                Console.WriteLine(robo.name + "(KO)");
                            }
                        }

                        string target = Console.ReadLine();

                        for (int j = 0; j <= targetFleet.roboFleet.Count() - 1; j++)
                        {
                            if (target == targetFleet.roboFleet[j].name.ToLower())
                            {
                                if (targetFleet.roboFleet[j].health > 0)
                                {
                                    dinoHerd[i].Attack(targetFleet.roboFleet[j]);
                                    playerRunning = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(targetFleet.roboFleet[j].name + " has already been defeated, please choose another dino");
                                    break;
                                }
                            }
                        }
                        if (playerRunning)
                        {
                            Console.WriteLine("Please enter a valid choice.");
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
