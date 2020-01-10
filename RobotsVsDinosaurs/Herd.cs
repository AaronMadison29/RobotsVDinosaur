using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Herd : FighterGroups
    {
        public new static List<Fighter> group = new List<Fighter>();


        public Herd() : base(group)
        {
            Fighter dinoOne = new Dinosaur("TRex", 2, 50, 3);
            Fighter dinoTwo = new Dinosaur("Raptor", 4, 50, 3);
            Fighter dinoThree = new Dinosaur("Turkey", 6, 50, 3);

            group.Add(dinoOne);
            group.Add(dinoTwo);
            group.Add(dinoThree);


        }


        public override void AttackSequence(FighterGroups fighters)
        {
            bool playerRunning = true;
            if (player == false)
            {
                

                for (int i = 0; i < group.Count; i++)
                {
                    if (!CheckHealth(group[i]) && !CheckEnergy(group[i]))
                    {
                        foreach (Fighter fighter in fighters.group)
                        {
                            if (fighter.health > 0)
                            {
                                group[i].WeaponSwap();
                                group[i].Attack(fighter, group[i]);
                                Recharge(group[i]);
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

                for (int i = 0; i < group.Count(); i++)
                {
                    do
                    {

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
                                    group[i].Attack(fighters.group[j], group[i]);
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
                        if (playerRunning)
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

                return;
            }
            
            return;
        }
    }
}
