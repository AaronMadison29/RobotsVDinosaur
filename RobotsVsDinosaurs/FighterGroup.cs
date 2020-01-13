using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class FighterGroup
    {
        public bool player;
        public List<Fighter> group = new List<Fighter>();



        public FighterGroup(List<Fighter> groupIn)
        {
            group = groupIn;
        }

        public void Recharge(Fighter fighterIn)
        {
            foreach (Fighter fighter in group)
            {
                if (!fighter.attacker)
                {
                    if (fighter.energy < fighter.maxEnergy)
                    {
                        fighter.energy++;
                    }
                }
                else
                {
                    fighterIn.attacker = false;
                }
            }
        }

        public string GetStats()
        {
            string stats = "";

            foreach (Fighter fighter in group)
            {
                if (fighter.health <= 0)
                {
                    stats = stats + fighter.name + ":KO ";
                }
                else
                {
                    stats = stats + fighter.name + ":" + fighter.health + "HP " + fighter.energy + "P ";
                }

            }

            return stats;
        }

        public bool CheckHealth(Fighter fighterIn)
        {
            if (fighterIn.health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEnergy(Fighter fighterIn)
        {
            if (fighterIn.energy <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AttackSequence(FighterGroup fighters)
        {
            bool playerRunning = true;

            if (player)
            {
                for (int i = 0; i < group.Count(); i++)
                {
                    do
                    {

                        if (CheckHealth(group[i]))
                        {
                            break;
                        }
                        if (CheckEnergy(group[i]))
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
                        for (int j = 0; j <= fighters.group.Count() - 1; j++)
                        {
                            if (target.ToLower() == fighters.group[j].name.ToLower())
                            {
                                if (fighters.group[j].health > 0)
                                {
                                    if(group[i].isDino)
                                    {
                                        group[i].Attack(fighters.group[j], group[i]);
                                    }
                                    else
                                    {
                                        group[i].Attack(fighters.group[j], player);
                                    }
                                    playerRunning = false;
                                    break;
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine(fighters.group[j].name + " has already been defeated.");
                                    break;
                                }
                            }
                        }
                        if (playerRunning)
                        {
                            Console.Clear();
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
                        foreach (Fighter fighter in fighters.group)
                        {
                            if (fighter.health > 0)
                            {
                                group[i].WeaponSwap(player);
                                if (group[i].isDino)
                                {
                                    group[i].Attack(fighter, group[i]);
                                }
                                else
                                {
                                    group[i].Attack(fighter, player);
                                }
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
