using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Fleet
    {

        public List<Robot> roboFleet = new List<Robot>();
        public bool player;

        public Fleet()
        {
            Robot roboOne = new Robot("bob", 1);
            Robot roboTwo = new Robot("frank", 3);
            Robot roboThree = new Robot("jim", 5);
            


            roboFleet.Add(roboOne);
            roboFleet.Add(roboTwo);
            roboFleet.Add(roboThree);
        }

        public string getFleetStats()
        {
            string fleetStats = "";
            
            foreach(Robot robo in roboFleet)
            {
                if(robo.health <= 0)
                {
                    fleetStats = fleetStats + robo.name + ":KO "; 
                }
                else
                {
                    fleetStats = fleetStats + robo.name + ":" + robo.health + "HP " + robo.powerLevel +"P ";
                }
                
            }

            return fleetStats;
        }
        
        public bool checkHealth(Robot roboIn)
        {
            if (roboIn.health <= 0)
            {
                return false ;
            }
            else
            {
                return true;
            }
        }

        public bool checkPowerLevel(Robot roboIn)
        {
            if (roboIn.powerLevel <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void recharge(Robot roboIn)
        {
            foreach (Robot robo in roboFleet)
            {
                if (!robo.attacker)
                {
                    if (robo.powerLevel < robo.maxPower)
                    {
                        robo.powerLevel++;
                    }
                }
                else
                {
                    roboIn.attacker = false;
                }
            }
        }

        public void attackSequence(Herd targetHerd)
        {
            bool playerRunning = true;

            if(player)
            {
                for (int i = 0; i < roboFleet.Count(); i++)
                {
                    do
                    {

                        if(!checkHealth(roboFleet[i]))
                        {
                            break;
                        }
                        if(!checkPowerLevel(roboFleet[i]))
                        {
                            break;
                        }

                        Console.WriteLine("Who should " + roboFleet[i].name + " attack?");

                        foreach (Dinosaur dino in targetHerd.dinoHerd)
                        {
                            if (dino.health >= 0)
                            {
                                Console.WriteLine(dino.type + "(" + dino.health + " HP " + dino.energy + "E)");
                            }
                            else
                            {
                                Console.WriteLine(dino.type + "(KO)");
                            }
                        }

                        string target = Console.ReadLine();
                        for(int j = 0; j <= targetHerd.dinoHerd.Count() - 1; j++)
                        {
                            if(target == targetHerd.dinoHerd[j].type.ToLower())
                            {
                                if (targetHerd.dinoHerd[j].health > 0)
                                {
                                    roboFleet[i].Attack(targetHerd.dinoHerd[j], player);
                                    playerRunning = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine(targetHerd.dinoHerd[j].type + " has already been defeated, please choose another dino");
                                    break;
                                }
                            }
                        }
                        if(playerRunning)
                        {
                            Console.WriteLine("Please enter a valid choice.");
                        }

                    } while (playerRunning);

                    if (!playerRunning)
                    {
                        recharge(roboFleet[i]);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < roboFleet.Count; i++)
                {
                    if (checkHealth(roboFleet[i]) && checkPowerLevel(roboFleet[i]))
                    {
                        foreach(Dinosaur dino in targetHerd.dinoHerd)
                        {
                            if (dino.health > 0)
                            {
                                roboFleet[i].weaponSwap(player);
                                roboFleet[i].Attack(dino, player);
                                recharge(roboFleet[i]);
                                playerRunning = false;
                                break;
                            }
                        }
                        if (!playerRunning)
                        {
                            break;
                        }
                    }
                }
            }


            

            return;
        }

    }
}
