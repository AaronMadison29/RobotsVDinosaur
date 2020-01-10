using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Fleet : FighterGroups
    {

        public new static List<Fighter> group = new List<Fighter>();

        public Fleet() : base(group)
        {
            Fighter roboOne = new Robot("Bob", 1, 100, 5);
            Fighter roboTwo = new Robot("Frank", 3, 100, 5);
            Fighter roboThree = new Robot("Jim", 5, 100, 5);



            group.Add(roboOne);
            group.Add(roboTwo);
            group.Add(roboThree);
        }

        //public string getFleetStats()
        //{
        //    string fleetStats = "";
            
        //    foreach(Robot robo in group)
        //    {
        //        if(robo.health <= 0)
        //        {
        //            fleetStats = fleetStats + robo.name + ":KO "; 
        //        }
        //        else
        //        {
        //            fleetStats = fleetStats + robo.name + ":" + robo.health + "HP " + robo.energy + "P ";
        //        }
                
        //    }

        //    return fleetStats;
        //}
        
        //public bool checkHealth(Robot roboIn)
        //{
        //    if (roboIn.health <= 0)
        //    {
        //        return false ;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public bool checkPowerLevel(Robot roboIn)
        //{
        //    if (roboIn.energy <= 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}


        public override void AttackSequence(FighterGroups fighters)
        {
            bool playerRunning = true;

            if(player)
            {
                for (int i = 0; i < group.Count(); i++)
                {
                    do
                    {

                        if(CheckHealth(group[i]))
                        {
                            break;
                        }
                        if(CheckEnergy(group[i]))
                        {
                            break;
                        }

                        Console.WriteLine("Who should " + group[i].name + " attack?");

                        foreach (Fighter fighter in fighters.group)
                        {
                            if (fighter.health > 0)
                            {
                                Console.WriteLine("-" + fighter.name + "-" + "(" + fighter.health + " HP " + fighter.energy + "E)");
                            }
                            else
                            {
                                Console.WriteLine("-" + fighter.name + "-" + "(KO)");
                            }
                        }

                        string target = Console.ReadLine();
                        for(int j = 0; j <= fighters.group.Count() - 1; j++)
                        {
                            if(target.ToLower() == fighters.group[j].name.ToLower())
                            {
                                if (fighters.group[j].health > 0)
                                {
                                    group[i].Attack(fighters.group[j], group[i], player);
                                    playerRunning = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\n" + fighters.group[j].name + " has already been defeated, please choose another dino");
                                    break;
                                }
                            }
                        }
                        if(playerRunning)
                        {
                            Console.WriteLine("Please enter a valid choice.\n");
                        }

                    } while (playerRunning);

                    if (!playerRunning)
                    {
                        Recharge(group[i]);
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < group.Count; i++)
                {
                    if (!CheckHealth(group[i]) && !CheckEnergy(group[i]))
                    {
                        foreach(Fighter fighter in fighters.group)
                        {
                            if (fighter.health > 0)
                            {
                                group[i].WeaponSwap(player);
                                group[i].Attack(fighter, group[i], player);
                                Recharge(group[i]);
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
