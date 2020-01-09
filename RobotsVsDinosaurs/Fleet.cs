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
            Robot roboOne = new Robot("Bob", 1);
            Robot roboTwo = new Robot("Frank", 3);
            Robot roboThree = new Robot("Jim", 5);
            


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
                    fleetStats = fleetStats + robo.name + ":" + robo.health + "HP " + robo.powerLevel +" Energy";
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

        public void attackSequence(Herd targetHerd)
        {
            bool playerRunning = true;

            if(player)
            {
                for (int i = 0; i < roboFleet.Count(); i++)
                {
                    do
                    {

                        playerRunning = true;

                        if(!checkHealth(roboFleet[i]))
                        {
                            break;
                        }
                        if(!checkPowerLevel(roboFleet[i]))
                        {
                            break;
                        }

                        Console.WriteLine("Who should " + roboFleet[i].name + " attack?");
                        if (targetHerd.dinoHerd[0].health >= 0)
                        {
                            Console.WriteLine("1:" + targetHerd.dinoHerd[0].type + "(" + targetHerd.dinoHerd[0].health + " HP)");
                        }
                        else
                        {
                            Console.WriteLine("1:" + targetHerd.dinoHerd[0].type + "(KO)");
                        }

                        if (targetHerd.dinoHerd[1].health >= 0)
                        {
                            Console.WriteLine("2:" + targetHerd.dinoHerd[1].type + "(" + targetHerd.dinoHerd[1].health + " HP)");
                        }
                        else
                        {
                            Console.WriteLine("2:" + targetHerd.dinoHerd[1].type + "(KO)");
                        }
                        if (targetHerd.dinoHerd[2].health >= 0)
                        {
                            Console.WriteLine("3:" + targetHerd.dinoHerd[2].type + "(" + targetHerd.dinoHerd[2].health + " HP)");
                        }
                        else
                        {
                            Console.WriteLine("3:" + targetHerd.dinoHerd[2].type + "(KO)");
                        }
                        string target = Console.ReadLine();

                        

                        switch (target)
                        {
                            case "1":
                                if (targetHerd.dinoHerd[0].health > 0)
                                {
                                    roboFleet[i].Attack(targetHerd.dinoHerd[0], player);
                                    playerRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine(targetHerd.dinoHerd[0].type + " has already been defeated, please choose another dino");
                                }
                                break;
                            case "2":
                                if (targetHerd.dinoHerd[1].health > 0)
                                {
                                    roboFleet[i].Attack(targetHerd.dinoHerd[1], player);
                                    playerRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine(targetHerd.dinoHerd[1].type + " has already been defeated, please choose another dino");
                                }
                                break;
                            case "3":
                                if (targetHerd.dinoHerd[2].health > 0)
                                {
                                    roboFleet[i].Attack(targetHerd.dinoHerd[2], player);
                                    playerRunning = false;
                                }
                                else
                                {
                                    Console.WriteLine(targetHerd.dinoHerd[2].type + " has already been defeated, please choose another dino");
                                }
                                break;
                            default:
                                Console.WriteLine("Please choose a valid Dino");
                                break;
                        }

                    } while (playerRunning);

                    if (!playerRunning)
                    {
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
                        if (targetHerd.dinoHerd[0].health > 0)
                        {
                            roboFleet[i].weaponSwap(player);
                            roboFleet[i].Attack(targetHerd.dinoHerd[0], player);
                            break;
                        }
                        else if (targetHerd.dinoHerd[1].health > 0)
                        {
                            roboFleet[i].weaponSwap(player);
                            roboFleet[i].Attack(targetHerd.dinoHerd[1], player);
                            break;
                        }
                        else if (targetHerd.dinoHerd[2].health > 0)
                        {
                            roboFleet[i].weaponSwap(player);
                            roboFleet[i].Attack(targetHerd.dinoHerd[2], player);
                            break;
                        }
                    }
                }
            }


            

            return;
        }

    }
}
